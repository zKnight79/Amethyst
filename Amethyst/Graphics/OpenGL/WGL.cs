using System;
using System.Runtime.InteropServices;

namespace Amethyst.Graphics.OpenGL
{
    #pragma warning disable 1591

    /// <summary>
    /// WGL functions collection
    /// </summary>
    public static class WGL
    {
        const string GL_LIB = "opengl32";

        #region WINGDI.H
        /// <summary>
        /// Makes a specified OpenGL rendering context the calling thread's current rendering context
        /// </summary>
        /// <param name="hdc">Handle to a device context</param>
        /// <param name="hglrc">Handle to an OpenGL rendering context that the function sets as the calling thread's rendering context</param>
        /// <returns>True if succeed, false if fail</returns>
        [DllImport(GL_LIB, EntryPoint = "wglMakeCurrent")]
        public static extern bool MakeCurrent(uint hdc, uint hglrc);
        /// <summary>
        /// The wglCreateContext function creates a new OpenGL rendering context,<br />
        /// which is suitable for drawing on the device referenced by hdc<br />
        /// The rendering context has the same pixel format as the device context
        /// </summary>
        /// <param name="hdc">Handle to a device context for which the function creates a suitable OpenGL rendering context</param>
        /// <returns>If the function succeeds, the return value is a valid handle to an OpenGL rendering context. If it fails, the return value is 0</returns>
        [DllImport(GL_LIB, EntryPoint = "wglCreateContext")]
        public static extern uint CreateContext(uint hdc);
        /// <summary>
        /// The wglDeleteContext function deletes a specified OpenGL rendering context
        /// </summary>
        /// <param name="hrc">Handle to an OpenGL rendering context that the function will delete</param>
        /// <returns>True if succeed, false if fail</returns>
        [DllImport(GL_LIB, EntryPoint = "wglDeleteContext")]
        public static extern bool DeleteContext(uint hrc);
        /// <summary>
        /// The wglGetProcAddress function returns the address of an OpenGL extension function for use with the current OpenGL rendering context
        /// </summary>
        /// <param name="lpszProc">Points to a null-terminated string that is the name of the extension function. The name of the extension function must be identical to a corresponding function implemented by OpenGL</param>
        /// <returns>When the function succeeds, the return value is the address of the extension function. When it fails, the return value is null</returns>
        [DllImport(GL_LIB, EntryPoint = "wglGetProcAddress")]
        internal extern static IntPtr GetProcAddress(String lpszProc);
        #endregion

        #region WGLEXT.H
        #region CONSTANTS
        public const int CONTEXT_DEBUG_BIT_ARB = 0x00000001;
        public const int CONTEXT_CORE_PROFILE_BIT_ARB = 0x00000001;
        public const int CONTEXT_COMPATIBILITY_PROFILE_BIT_ARB = 0x00000002;
        public const int CONTEXT_FORWARD_COMPATIBLE_BIT_ARB = 0x00000002;
        public const int CONTEXT_MAJOR_VERSION_ARB = 0x2091;
        public const int CONTEXT_MINOR_VERSION_ARB = 0x2092;
        public const int CONTEXT_LAYER_PLANE_ARB = 0x2093;
        public const int CONTEXT_FLAGS_ARB = 0x2094;
        public const int ERROR_INVALID_VERSION_ARB = 0x2095;
        public const int ERROR_INVALID_PROFILE_ARB = 0x2096;
        public const int NUMBER_PIXEL_FORMATS_ARB = 0x2000;
        public const int DRAW_TO_WINDOW_ARB = 0x2001;
        public const int DRAW_TO_BITMAP_ARB = 0x2002;
        public const int ACCELERATION_ARB = 0x2003;
        public const int NEED_PALETTE_ARB = 0x2004;
        public const int NEED_SYSTEM_PALETTE_ARB = 0x2005;
        public const int SWAP_LAYER_BUFFERS_ARB = 0x2006;
        public const int SWAP_METHOD_ARB = 0x2007;
        public const int NUMBER_OVERLAYS_ARB = 0x2008;
        public const int NUMBER_UNDERLAYS_ARB = 0x2009;
        public const int TRANSPARENT_ARB = 0x200A;
        public const int TRANSPARENT_RED_VALUE_ARB = 0x2037;
        public const int TRANSPARENT_GREEN_VALUE_ARB = 0x2038;
        public const int TRANSPARENT_BLUE_VALUE_ARB = 0x2039;
        public const int TRANSPARENT_ALPHA_VALUE_ARB = 0x203A;
        public const int TRANSPARENT_INDEX_VALUE_ARB = 0x203B;
        public const int SHARE_DEPTH_ARB = 0x200C;
        public const int SHARE_STENCIL_ARB = 0x200D;
        public const int SHARE_ACCUM_ARB = 0x200E;
        public const int SUPPORT_GDI_ARB = 0x200F;
        public const int SUPPORT_OPENGL_ARB = 0x2010;
        public const int DOUBLE_BUFFER_ARB = 0x2011;
        public const int STEREO_ARB = 0x2012;
        public const int PIXEL_TYPE_ARB = 0x2013;
        public const int COLOR_BITS_ARB = 0x2014;
        public const int RED_BITS_ARB = 0x2015;
        public const int RED_SHIFT_ARB = 0x2016;
        public const int GREEN_BITS_ARB = 0x2017;
        public const int GREEN_SHIFT_ARB = 0x2018;
        public const int BLUE_BITS_ARB = 0x2019;
        public const int BLUE_SHIFT_ARB = 0x201A;
        public const int ALPHA_BITS_ARB = 0x201B;
        public const int ALPHA_SHIFT_ARB = 0x201C;
        public const int ACCUM_BITS_ARB = 0x201D;
        public const int ACCUM_RED_BITS_ARB = 0x201E;
        public const int ACCUM_GREEN_BITS_ARB = 0x201F;
        public const int ACCUM_BLUE_BITS_ARB = 0x2020;
        public const int ACCUM_ALPHA_BITS_ARB = 0x2021;
        public const int DEPTH_BITS_ARB = 0x2022;
        public const int STENCIL_BITS_ARB = 0x2023;
        public const int AUX_BUFFERS_ARB = 0x2024;
        public const int NO_ACCELERATION_ARB = 0x2025;
        public const int GENERIC_ACCELERATION_ARB = 0x2026;
        public const int FULL_ACCELERATION_ARB = 0x2027;
        public const int SWAP_EXCHANGE_ARB = 0x2028;
        public const int SWAP_COPY_ARB = 0x2029;
        public const int SWAP_UNDEFINED_ARB = 0x202A;
        public const int TYPE_RGBA_ARB = 0x202B;
        public const int TYPE_COLORINDEX_ARB = 0x202C;
        public const int SAMPLE_BUFFERS_ARB = 0x2041;
        public const int SAMPLES_ARB = 0x2042;
        #endregion
        #region wglCreateContextAttribsARB
        private unsafe delegate uint wglCreateContextAttribsARBDelegate(uint hDC, uint hShareContext, int* attribList);
        private static wglCreateContextAttribsARBDelegate wglCreateContextAttribsARB = null;
        public static uint CreateContextAttribs(uint hDC, uint hShareContext, int[] attribList)
        {
            unsafe
            {
                fixed (int* attribList_ptr = attribList)
                {
                    return wglCreateContextAttribsARB(hDC, hShareContext, attribList_ptr);
                }
            }
        }
        #endregion
        #region wglSwapIntervalEXT
        private delegate bool wglSwapIntervalEXTDelegate(int interval);
        private static wglSwapIntervalEXTDelegate wglSwapIntervalEXT = null;
        public static bool SwapInterval(int interval)
        {
            return wglSwapIntervalEXT(interval);
        }
        #endregion
        #region wglGetSwapIntervalEXT
        private delegate int wglGetSwapIntervalEXTDelegate();
        private static wglGetSwapIntervalEXTDelegate wglGetSwapIntervalEXT = null;
        public static int GetSwapInterval()
        {
            return wglGetSwapIntervalEXT();
        }
        #endregion
        #region wglChoosePixelFormatARB
        private unsafe delegate bool wglChoosePixelFormatARBDelegate(uint hdc, int* piAttribIList, float* pfAttribFList, uint nMaxFormats, int* piFormats, uint* nNumFormats);
        private static wglChoosePixelFormatARBDelegate wglChoosePixelFormatARB = null;
        public static bool ChoosePixelFormat(uint hdc, int[] piAttribIList, float[] pfAttribFList, uint nMaxFormats, out int piFormats, out uint nNumFormats)
        {
            unsafe
            {
                fixed (int* piAttribIList_ptr = piAttribIList, piFormats_ptr = &piFormats)
                fixed (float* pfAttribFList_ptr = pfAttribFList)
                fixed (uint* nNumFormats_ptr = &nNumFormats)
                {
                    return wglChoosePixelFormatARB(hdc, piAttribIList_ptr, pfAttribFList_ptr, nMaxFormats, piFormats_ptr, nNumFormats_ptr);
                }
            }
        }
        #endregion
        #endregion

        internal static T GetExtension<T>(string name) where T : class
        {
            IntPtr addr = GetProcAddress(name);
            if (addr == IntPtr.Zero || addr == new IntPtr(1) || addr == new IntPtr(2))
            {
                return default(T);
            }
            return (Marshal.GetDelegateForFunctionPointer(addr, typeof(T)) as T);
        }

        /// <summary>
        /// Load WGL Extensions
        /// </summary>
        public static void LoadExtensions()
        {
            Logger.WriteLine("Loading WGL Extensions");
            wglCreateContextAttribsARB = GetExtension<wglCreateContextAttribsARBDelegate>("wglCreateContextAttribsARB");
            wglSwapIntervalEXT = GetExtension<wglSwapIntervalEXTDelegate>("wglSwapIntervalEXT");
            wglGetSwapIntervalEXT = GetExtension<wglGetSwapIntervalEXTDelegate>("wglGetSwapIntervalEXT");
            wglChoosePixelFormatARB = GetExtension<wglChoosePixelFormatARBDelegate>("wglChoosePixelFormatARB");
            Logger.WriteLine("WGL Extensions loaded");
        }
    }
}
