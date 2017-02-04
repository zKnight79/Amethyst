using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Amethyst.Graphics.OpenGL;

namespace Amethyst.Graphics
{
    /// <summary>
    /// Specify the anti-aliasing level of the GL Context
    /// </summary>
    public enum AntiAliasingLevel
    {
        /// <summary>
        /// No anti-aliasing
        /// </summary>
        None = 0,
        /// <summary>
        /// 2x anti-aliasing
        /// </summary>
        MSAA_2X = 2,
        /// <summary>
        /// 4x anti-aliasing
        /// </summary>
        MSAA_4X = 4,
        /// <summary>
        /// 8x anti-aliasing
        /// </summary>
        MSAA_8X = 8,
        /// <summary>
        /// 16x anti-aliasing
        /// </summary>
        MSAA_16X = 16,
        /// <summary>
        /// 32x anti-aliasing
        /// </summary>
        MSAA_32X = 32
    }

    /// <summary>
    /// Represents the OpenGL context
    /// </summary>
    public class GLContext : IDisposable
    {
        uint m_HWND = 0;
        uint m_HDC = 0;
        uint m_HRC = 0;
        /// <summary>
        /// Get the control bounded by the GLContext
        /// </summary>
        public Control Control { get; private set; }
        /// <summary>
        /// Get the OpenGL rendering context version, computed with major and minor version
        /// </summary>
        public double GLRCVersion { get; private set; }
        /// <summary>
        /// Get OpenGL version, result of glGetString(GL_VERSION)
        /// </summary>
        public string GLVersion { get; private set; }
        /// <summary>
        /// Get the renderer name, result of glGetString(GL_RENDERER)
        /// </summary>
        public string GLRenderer { get; private set; }
        /// <summary>
        /// Get the renderer vendor name, result of glGetString(GL_VENDOR)
        /// </summary>
        public string GLVendor { get; private set; }
        /// <summary>
        /// Get GLSL version, result of glGetString(GL_SHADING_LANGUAGE_VERSION)
        /// </summary>
        public string GLShadingLanguageVersion { get; private set; }

        /// <summary>
        /// Creates a new GLContext for the given Control
        /// </summary>
        /// <param name="control">The control that will be rendered using OpenGL</param>
        /// <param name="colorBits">Number of bits for color, generaly 32</param>
        /// <param name="depthBits">Number of bits for depth buffer</param>
        /// <param name="stencilBits">Number of bits for stencil buffer</param>
        /// <param name="accumBits">Number of bits for accumulation buffer</param>
        /// <param name="msaa">Anti-aliasing level</param>
        public GLContext(Control control, byte colorBits = 32, byte depthBits = 0, byte stencilBits = 0, byte accumBits = 0, AntiAliasingLevel msaa = AntiAliasingLevel.None)
        {
            #region CREE UN CONTEXT OPENGL D'ANCIENNE GENERATION => LE BUT EST DE POUVOIR CHARGER LES EXTENSIONS WGL ET OPENGL
            Logger.WriteLine("Creating old OpenGL Context");
            using (Form f = new Form())
            {
                f.ClientSize = control.ClientSize;

                uint hWND = (uint)f.Handle.ToInt32();
                uint hDC = Win32.GetDC(hWND);
                PIXELFORMATDESCRIPTOR pfd = new PIXELFORMATDESCRIPTOR();
                pfd.nSize = (ushort)Marshal.SizeOf(typeof(PIXELFORMATDESCRIPTOR));
                pfd.nVersion = 1;
                pfd.dwFlags = Win32.PFD_DOUBLEBUFFER | Win32.PFD_SUPPORT_OPENGL | Win32.PFD_DRAW_TO_WINDOW;
                pfd.iPixelType = (byte)Win32.PFD_TYPE_RGBA;
                pfd.cColorBits = colorBits;
                pfd.cDepthBits = depthBits;
                pfd.cStencilBits = stencilBits;
                pfd.cAccumBits = accumBits;
                pfd.iLayerType = (byte)Win32.PFD_MAIN_PLANE;

                int nPixelFormat = Win32.ChoosePixelFormat(hDC, ref pfd);
                if (nPixelFormat == 0)
                {
                    throw new Exception("Can't choose Pixel Format");
                }
                bool bResult = Win32.SetPixelFormat(hDC, nPixelFormat, ref pfd) != 0;
                if (!bResult)
                {
                    throw new Exception("Can't set Pixel Format (err " + Win32.GetLastError() + ")");
                }

                uint tempHRC = WGL.CreateContext(hDC);
                WGL.MakeCurrent(hDC, tempHRC);


                WGL.LoadExtensions();
                GL.LoadExtensions();
                WGL.MakeCurrent(0, 0);
                WGL.DeleteContext(tempHRC);
            }
            #endregion

            Control = control;
            m_HWND = (uint)Control.Handle.ToInt32();
            m_HDC = Win32.GetDC(m_HWND);

            Logger.WriteLine("Creating modern OpenGL Context");
            #region TENTE DE CREER UN CONTEXTE MODERNE
            try
            {
                int[] pixelFormatAttribList = new int[]
                { 
                    WGL.DRAW_TO_WINDOW_ARB, (int)GLConst.GL_TRUE,
                    WGL.SUPPORT_OPENGL_ARB, (int)GLConst.GL_TRUE,
                    WGL.ACCELERATION_ARB, WGL.FULL_ACCELERATION_ARB,
                    WGL.DOUBLE_BUFFER_ARB, (int)GLConst.GL_TRUE,
                    WGL.PIXEL_TYPE_ARB, WGL.TYPE_RGBA_ARB,
                    WGL.COLOR_BITS_ARB, colorBits,
                    WGL.DEPTH_BITS_ARB, depthBits,
                    WGL.STENCIL_BITS_ARB, stencilBits,
                    WGL.ACCUM_BITS_ARB, accumBits,
                    WGL.SAMPLE_BUFFERS_ARB, (int)((msaa != AntiAliasingLevel.None) ? GLConst.GL_TRUE : GLConst.GL_FALSE),
                    WGL.SAMPLES_ARB, (int)msaa,
                    0
                };
                int pixelFormat;
                uint numFormats;
                WGL.ChoosePixelFormat(m_HDC, pixelFormatAttribList, null, 1, out pixelFormat, out numFormats);
                PIXELFORMATDESCRIPTOR pfd = new PIXELFORMATDESCRIPTOR();
                bool bResult = Win32.SetPixelFormat(m_HDC, pixelFormat, ref pfd) != 0;
                if (!bResult)
                {
                    throw new Exception("Can't set Pixel Format. Error code : " + Win32.GetLastError());
                }

                for (int major = 4; major >= 3; --major)
                {
                    for (int minor = major; minor >= 0; --minor)
                    {
                        int[] attributes = {  
                            WGL.CONTEXT_MAJOR_VERSION_ARB, major,
                            WGL.CONTEXT_MINOR_VERSION_ARB, minor,
                            WGL.CONTEXT_FLAGS_ARB, WGL.CONTEXT_FORWARD_COMPATIBLE_BIT_ARB,
                            0
                        };
                        m_HRC = WGL.CreateContextAttribs(m_HDC, 0, attributes);
                        if (m_HRC != 0)
                        {
                            break;
                        }
                        Logger.WriteLine("Failed to create OpenGL " + major + "." + minor);
                    }
                    if (m_HRC != 0)
                    {
                        break;
                    }
                }
                if (m_HRC == 0)
                {
                    throw new Exception("Cannot create modern OpenGL Context");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occured during modern OpenGL Context creation : " + ex.Message);
            }
            #endregion
            WGL.MakeCurrent(m_HDC, m_HRC);
            #region VERSION OPENGL
            int majorGL, minorGL;
            GL.GetInteger(GetParamName.GL_MAJOR_VERSION, out majorGL);
            GL.GetInteger(GetParamName.GL_MINOR_VERSION, out minorGL);
            GLRCVersion = majorGL + minorGL / 10.0;
            GLVersion = GL.GetString(StringName.GL_VERSION);
            GLRenderer = GL.GetString(StringName.GL_RENDERER);
            GLVendor = GL.GetString(StringName.GL_VENDOR);
            GLShadingLanguageVersion = GL.GetString(StringName.GL_SHADING_LANGUAGE_VERSION);
            Logger.WriteLine("OpenGL version : " + GLVersion);
            Logger.WriteLine("Renderer       : " + GLRenderer);
            Logger.WriteLine("Vendor         : " + GLVendor);
            Logger.WriteLine("GLSL version   : " + GLShadingLanguageVersion);
            #endregion
        }

        /// <summary>
        /// Release all the GLContext resources
        /// </summary>
        public void Dispose()
        {
            Logger.WriteLine("Releasing OpenGL Context");
            WGL.MakeCurrent(m_HDC, 0);
            WGL.DeleteContext(m_HRC);
            Win32.ReleaseDC(m_HWND, m_HDC);
            Logger.WriteLine("OpenGL Context released");
        }

        /// <summary>
        /// Swap buffers to update the rendering of the control
        /// </summary>
        public void SwapBuffers()
        {
            Win32.SwapBuffers(m_HDC);
        }
    }
}
