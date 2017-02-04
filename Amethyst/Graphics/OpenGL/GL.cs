using System;
using System.Runtime.InteropServices;
using System.Text;

using GLenum = System.UInt32;
using GLuint = System.UInt32;
using GLint = System.Int32;
using GLsizei = System.Int32;
using GLclampf = System.Single;
using GLfloat = System.Single;
using GLclampd = System.Double;
using GLdouble = System.Double;
using GLboolean = System.Boolean;
using GLubyte = System.Byte;
using GLsizeiptr = System.IntPtr;
using GLintptr = System.IntPtr;
using GLshort = System.Int16;
using GLbyte = System.SByte;
using GLushort = System.UInt16;
using GLbitfield = System.UInt32;
using GLsync = System.IntPtr;
using GLuint64 = System.UInt64;
using GLint64 = System.Int64;

using Amethyst.Math;

namespace Amethyst.Graphics.OpenGL
{
    #pragma warning disable 1591
    
    /// <summary>
    /// Represents a method that will be used as a callback for OpenGL Debug functions introduced in 4.3 specification
    /// </summary>
    /// <param name="source">Source of debug</param>
    /// <param name="type">Type of debug</param>
    /// <param name="id">ID of debug</param>
    /// <param name="severity">Severity of debug</param>
    /// <param name="length">Message length</param>
    /// <param name="message">Message</param>
    /// <param name="userParam">User parameters</param>
    public delegate void GLDEBUGPROC(DebugSource source, DebugType type, int id, DebugSeverity severity, int length, string message, IntPtr userParam);

    /// <summary>
    /// OpenGL 1.0 to 4.4 functions collection
    /// </summary>
    public static class GL
    {
        const string GL_LIB = "opengl32";

        #region OPENGL 1.0
        #region glCullFace
        [DllImport(GL_LIB, EntryPoint = "glCullFace")]
        private static extern void glCullFace(GLenum mode);
        public static void CullFace(CullMode mode)
        {
            glCullFace((GLenum)mode);
        }
        #endregion
        #region glFrontFace
        [DllImport(GL_LIB, EntryPoint = "glFrontFace")]
        private static extern void glFrontFace(GLenum mode);
        public static void FrontFace(FrontFaceMode mode)
        {
            glFrontFace((GLenum)mode);
        }
        #endregion
        #region glHint
        [DllImport(GL_LIB, EntryPoint = "glHint")]
        private static extern void glHint(GLenum target, GLenum mode);
        public static void Hint(HintTarget target, HintMode mode)
        {
            glHint((GLenum)target, (GLenum)mode);
        }
        #endregion
        #region glLineWidth
        [DllImport(GL_LIB, EntryPoint = "glLineWidth")]
        private static extern void glLineWidth(GLfloat width);
        public static void LineWidth(float width)
        {
            glLineWidth(width);
        }
        #endregion
        #region glPointSize
        [DllImport(GL_LIB, EntryPoint = "glPointSize")]
        private static extern void glPointSize(GLfloat size);
        public static void PointSize(float size)
        {
            glPointSize(size);
        }
        #endregion
        #region glPolygonMode
        [DllImport(GL_LIB, EntryPoint = "glPolygonMode")]
        private static extern void glPolygonMode(GLenum face, GLenum mode);
        public static void PolygonMode(MaterialFace face, PolygonMode mode)
        {
            glPolygonMode((GLenum)face, (GLenum)mode);
        }
        #endregion
        #region glScissor
        [DllImport(GL_LIB, EntryPoint = "glScissor")]
        private static extern void glScissor(GLint x, GLint y, GLsizei width, GLsizei height);
        public static void Scissor(int x, int y, int width, int height)
        {
            glScissor(x, y, width, height);
        }
        #endregion
        #region glTexParameterf
        [DllImport(GL_LIB, EntryPoint = "glTexParameterf")]
        private static extern void glTexParameterf(GLenum target, GLenum pname, GLfloat param);
        public static void TexParameter(TextureTarget target, TextureParamName pname, float param)
        {
            glTexParameterf((GLenum)target, (GLenum)pname, param);
        }
        #endregion
        #region glTexParameterfv
        [DllImport(GL_LIB, EntryPoint = "glTexParameterfv")]
        private static unsafe extern void glTexParameterfv(GLenum target, GLenum pname, GLfloat* param);
        public static void TexParameter(TextureTarget target, TextureParamName pname, float[] param)
        {
            unsafe
            {
                fixed (float* param_ptr = param)
                {
                    glTexParameterfv((GLenum)target, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glTexParameteri
        [DllImport(GL_LIB, EntryPoint = "glTexParameteri")]
        private static extern void glTexParameteri(GLenum target, GLenum pname, GLint param);
        public static void TexParameter(TextureTarget target, TextureParamName pname, int param)
        {
            glTexParameteri((GLenum)target, (GLenum)pname, param);
        }
        #endregion
        #region glTexParameteriv
        [DllImport(GL_LIB, EntryPoint = "glTexParameteriv")]
        private static unsafe extern void glTexParameteriv(GLenum target, GLenum pname, GLint* param);
        public static void TexParameter(TextureTarget target, TextureParamName pname, int[] param)
        {
            unsafe
            {
                fixed (int* param_ptr = param)
                {
                    glTexParameteriv((GLenum)target, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glTexImage1D
        [DllImport(GL_LIB, EntryPoint = "glTexImage1D")]
        private static extern void glTexImage1D(GLenum target, GLint level, GLint internalformat, GLsizei width, GLint border, GLenum format, GLenum type, IntPtr pixels);
        public static void TexImage1D<T>(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int border, PixelFormat format, PixelType type, T[] pixels) where T : struct
        {
            GCHandle pixels_ptr = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                glTexImage1D((GLenum)target, level, (GLint)internalformat, width, border, (GLenum)format, (GLenum)type, pixels_ptr.AddrOfPinnedObject());
            }
            finally
            {
                pixels_ptr.Free();
            }
        }
        #endregion
        #region glTexImage2D
        [DllImport(GL_LIB, EntryPoint = "glTexImage2D")]
        private static extern void glTexImage2D(GLenum target, GLint level, GLint internalformat, GLsizei width, GLsizei height, GLint border, GLenum format, GLenum type, IntPtr pixels);
        public static void TexImage2D(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int height, int border, PixelFormat format, PixelType type, IntPtr pixels)
        {
            glTexImage2D((GLenum)target, level, (GLint)internalformat, width, height, border, (GLenum)format, (GLenum)type, pixels);
        }
        public static void TexImage2D<T>(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int height, int border, PixelFormat format, PixelType type, T[] pixels) where T : struct
        {
            GCHandle pixels_ptr = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                glTexImage2D((GLenum)target, level, (GLint)internalformat, width, height, border, (GLenum)format, (GLenum)type, pixels_ptr.AddrOfPinnedObject());
            }
            finally
            {
                pixels_ptr.Free();
            }
        }
        #endregion
        #region glDrawBuffer
        [DllImport(GL_LIB, EntryPoint = "glDrawBuffer")]
        private static extern void glDrawBuffer(GLenum mode);
        public static void DrawBuffer(DrawBufferMode mode)
        {
            glDrawBuffer((GLenum)mode);
        }
        #endregion
        #region glClear
        [DllImport(GL_LIB, EntryPoint = "glClear")]
        private static extern void glClear(GLenum mask);
        public static void Clear(ClearMask mask)
        {
            glClear((GLenum)mask);
        }
        #endregion
        #region glClearColor
        [DllImport(GL_LIB, EntryPoint = "glClearColor")]
        private static extern void glClearColor(GLclampf red, GLclampf green, GLclampf blue, GLclampf alpha);
        public static void ClearColor(float red, float green, float blue, float alpha)
        {
            glClearColor(red, green, blue, alpha);
        }
        public static void ClearColor(Color4 color)
        {
            glClearColor(color.Red, color.Green, color.Blue, color.Alpha);
        }
        #endregion
        #region glClearStencil
        [DllImport(GL_LIB, EntryPoint = "glClearStencil")]
        private static extern void glClearStencil(GLint s);
        public static void ClearStencil(int s)
        {
            glClearStencil(s);
        }
        #endregion
        #region glClearDepth
        [DllImport(GL_LIB, EntryPoint = "glClearDepth")]
        private static extern void glClearDepth(GLclampd depth);
        public static void ClearDepth(double depth)
        {
            glClearDepth(depth);
        }
        #endregion
        #region glStencilMask
        [DllImport(GL_LIB, EntryPoint = "glStencilMask")]
        private static extern void glStencilMask(GLuint mask);
        public static void StencilMask(int mask)
        {
            glStencilMask((GLuint)mask);
        }
        #endregion
        #region glColorMask
        [DllImport(GL_LIB, EntryPoint = "glColorMask")]
        private static extern void glColorMask(GLboolean red, GLboolean green, GLboolean blue, GLboolean alpha);
        public static void ColorMask(bool red, bool green, bool blue, bool alpha)
        {
            glColorMask(red, green, blue, alpha);
        }
        #endregion
        #region glDepthMask
        [DllImport(GL_LIB, EntryPoint = "glDepthMask")]
        private static extern void glDepthMask(GLboolean flag);
        public static void DepthMask(bool flag)
        {
            glDepthMask(flag);
        }
        #endregion
        #region glDisable
        [DllImport(GL_LIB, EntryPoint = "glDisable")]
        private static extern void glDisable(GLenum cap);
        public static void Disable(EnableCap cap)
        {
            glDisable((GLenum)cap);
        }
        #endregion
        #region glEnable
        [DllImport(GL_LIB, EntryPoint = "glEnable")]
        private static extern void glEnable(GLenum cap);
        public static void Enable(EnableCap cap)
        {
            glEnable((GLenum)cap);
        }
        #endregion
        #region glFinish
        [DllImport(GL_LIB, EntryPoint = "glFinish")]
        private static extern void glFinish();
        public static void Finish()
        {
            glFinish();
        }
        #endregion
        #region glFlush
        [DllImport(GL_LIB, EntryPoint = "glFlush")]
        private static extern void glFlush();
        public static void Flush()
        {
            glFlush();
        }
        #endregion
        #region glBlendFunc
        [DllImport(GL_LIB, EntryPoint = "glBlendFunc")]
        private static extern void glBlendFunc(GLenum sfactor, GLenum dfactor);
        public static void BlendFunc(BlendFactor sfactor, BlendFactor dfactor)
        {
            glBlendFunc((GLenum)sfactor, (GLenum)dfactor);
        }
        #endregion
        #region glLogicOp
        [DllImport(GL_LIB, EntryPoint = "glLogicOp")]
        private static extern void glLogicOp(GLenum opcode);
        public static void LogicOp(LogicOperation opcode)
        {
            glLogicOp((GLenum)opcode);
        }
        #endregion
        #region glStencilFunc
        [DllImport(GL_LIB, EntryPoint = "glStencilFunc")]
        private static extern void glStencilFunc(GLenum func, GLint refer, GLuint mask);
        public static void StencilFunc(StencilFunction func, int refer, int mask)
        {
            glStencilFunc((GLenum)func, refer, (GLuint)mask);
        }
        #endregion
        #region glStencilOp
        [DllImport(GL_LIB, EntryPoint = "glStencilOp")]
        private static extern void glStencilOp(GLenum fail, GLenum zfail, GLenum zpass);
        public static void StencilOp(StencilOperation fail, StencilOperation zfail, StencilOperation zpass)
        {
            glStencilOp((GLenum)fail, (GLenum)zfail, (GLenum)zpass);
        }
        #endregion
        #region glDepthFunc
        [DllImport(GL_LIB, EntryPoint = "glDepthFunc")]
        private static extern void glDepthFunc(GLenum func);
        public static void DepthFunc(DepthFunction func)
        {
            glDepthFunc((GLenum)func);
        }
        #endregion
        #region glPixelStoref
        [DllImport(GL_LIB, EntryPoint = "glPixelStoref")]
        private static extern void glPixelStoref(GLenum pname, GLfloat param);
        public static void PixelStore(PixelStoreParamName pname, float param)
        {
            glPixelStoref((GLenum)pname, param);
        }
        #endregion
        #region glPixelStorei
        [DllImport(GL_LIB, EntryPoint = "glPixelStorei")]
        private static extern void glPixelStorei(GLenum pname, GLint param);
        public static void PixelStore(PixelStoreParamName pname, int param)
        {
            glPixelStorei((GLenum)pname, param);
        }
        #endregion
        #region glReadBuffer
        [DllImport(GL_LIB, EntryPoint = "glReadBuffer")]
        private static extern void glReadBuffer(GLenum mode);
        public static void ReadBuffer(ReadBufferMode mode)
        {
            glReadBuffer((GLenum)mode);
        }
        #endregion
        #region glReadPixels
        [DllImport(GL_LIB, EntryPoint = "glReadPixels")]
        private static extern void glReadPixels(GLint x, GLint y, GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr pixels);
        public static void ReadPixels<T>(int x, int y, int width, int height, PixelFormat format, PixelType type, [In, Out] T[] pixels) where T : struct
        {
            GCHandle pixels_ptr = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                glReadPixels(x, y, width, height, (GLenum)format, (GLenum)type, pixels_ptr.AddrOfPinnedObject());
            }
            finally
            {
                pixels_ptr.Free();
            }
        }
        #endregion
        #region glGetBooleanv
        [DllImport(GL_LIB, EntryPoint = "glGetBooleanv")]
        private static unsafe extern void glGetBooleanv(GLenum pname, GLboolean* param);
        public static void GetBoolean(GetParamName pname, out bool param)
        {
            unsafe
            {
                fixed (Boolean* params_ptr = &param)
                {
                    glGetBooleanv((GLenum)pname, params_ptr);
                    param = *params_ptr;
                }
            }
        }
        public static void GetBoolean(GetParamName pname, [Out] bool[] param)
        {
            unsafe
            {
                fixed (Boolean* params_ptr = param)
                {
                    glGetBooleanv((GLenum)pname, params_ptr);
                }
            }
        }
        #endregion
        #region glGetDoublev
        [DllImport(GL_LIB, EntryPoint = "glGetDoublev")]
        private static unsafe extern void glGetDoublev(GLenum pname, GLdouble* param);
        public static void GetDouble(GetParamName pname, out double param)
        {
            unsafe
            {
                fixed (Double* params_ptr = &param)
                {
                    glGetDoublev((GLenum)pname, params_ptr);
                    param = *params_ptr;
                }
            }
        }
        public static void GetDouble(GetParamName pname, [Out] double[] param)
        {
            unsafe
            {
                fixed (Double* params_ptr = param)
                {
                    glGetDoublev((GLenum)pname, params_ptr);
                }
            }
        }
        #endregion
        #region glGetError
        [DllImport(GL_LIB, EntryPoint = "glGetError")]
        private static extern GLenum glGetError();
        public static ErrorCode GetError()
        {
            return (ErrorCode)glGetError();
        }
        #endregion
        #region glGetFloatv
        [DllImport(GL_LIB, EntryPoint = "glGetFloatv")]
        private static unsafe extern void glGetFloatv(GLenum pname, GLfloat* param);
        public static void GetFloat(GetParamName pname, out float param)
        {
            unsafe
            {
                fixed (Single* params_ptr = &param)
                {
                    glGetFloatv((GLenum)pname, params_ptr);
                    param = *params_ptr;
                }
            }
        }
        public static void GetFloat(GetParamName pname, [Out] float[] param)
        {
            unsafe
            {
                fixed (Single* params_ptr = param)
                {
                    glGetFloatv((GLenum)pname, params_ptr);
                }
            }
        }
        #endregion
        #region glGetIntegerv
        [DllImport(GL_LIB, EntryPoint = "glGetIntegerv")]
        private static unsafe extern void glGetIntegerv(GLenum pname, GLint* param);
        public static void GetInteger(GetParamName pname, out int param)
        {
            unsafe
            {
                fixed (Int32* params_ptr = &param)
                {
                    glGetIntegerv((GLenum)pname, params_ptr);
                    param = *params_ptr;
                }
            }
        }
        public static void GetInteger(GetParamName pname, [Out] int[] param)
        {
            unsafe
            {
                fixed (Int32* params_ptr = param)
                {
                    glGetIntegerv((GLenum)pname, params_ptr);
                }
            }
        }
        #endregion
        #region glGetString
        [DllImport(GL_LIB, EntryPoint = "glGetString")]
        private static unsafe extern GLubyte* glGetString(GLenum name);
        public static string GetString(StringName name)
        {
            unsafe
            {
                return new string((sbyte*)glGetString((GLenum)name));
            }
        }
        #endregion
        #region glGetTexImage
        [DllImport(GL_LIB, EntryPoint = "glGetTexImage")]
        private static extern void glGetTexImage(GLenum target, GLint level, GLenum format, GLenum type, IntPtr pixels);
        public static void GetTexImage<T>(TextureTarget target, int level, PixelFormat format, PixelType type, T[] pixels) where T : struct
        {
            GCHandle pixels_ptr = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                glGetTexImage((GLenum)target, level, (GLenum)format, (GLenum)type, pixels_ptr.AddrOfPinnedObject());
            }
            finally
            {
                pixels_ptr.Free();
            }
        }
        #endregion
        #region glGetTexParameterfv
        [DllImport(GL_LIB, EntryPoint = "glGetTexParameterfv")]
        private static unsafe extern void glGetTexParameterfv(GLenum target, GLenum pname, GLfloat* param);
        public static void GetTexParameter(TextureTarget target, TextureParamName pname, out float param)
        {
            unsafe
            {
                fixed (Single* params_ptr = &param)
                {
                    glGetTexParameterfv((GLenum)target, (GLenum)pname, params_ptr);
                    param = *params_ptr;
                }
            }
        }
        public static void GetTexParameter(TextureTarget target, TextureParamName pname, [Out] float[] param)
        {
            unsafe
            {
                fixed (Single* params_ptr = param)
                {
                    glGetTexParameterfv((GLenum)target, (GLenum)pname, params_ptr);
                }
            }
        }
        #endregion
        #region glGetTexParameteriv
        [DllImport(GL_LIB, EntryPoint = "glGetTexParameteriv")]
        private static unsafe extern void glGetTexParameteriv(GLenum target, GLenum pname, GLint* param);
        public static void GetTexParameter(TextureTarget target, TextureParamName pname, out int param)
        {
            unsafe
            {
                fixed (Int32* params_ptr = &param)
                {
                    glGetTexParameteriv((GLenum)target, (GLenum)pname, params_ptr);
                    param = *params_ptr;
                }
            }
        }
        public static void GetTexParameter(TextureTarget target, TextureParamName pname, [Out] int[] param)
        {
            unsafe
            {
                fixed (Int32* params_ptr = param)
                {
                    glGetTexParameteriv((GLenum)target, (GLenum)pname, params_ptr);
                }
            }
        }
        #endregion
        #region glGetTexLevelParameterfv
        [DllImport(GL_LIB, EntryPoint = "glGetTexLevelParameterfv")]
        private static unsafe extern void glGetTexLevelParameterfv(GLenum target, GLint level, GLenum pname, GLfloat* param);
        public static void GetTexLevelParameter(TextureTarget target, int level, TextureParamName pname, out float param)
        {
            unsafe
            {
                fixed (Single* params_ptr = &param)
                {
                    glGetTexLevelParameterfv((GLenum)target, level, (GLenum)pname, params_ptr);
                    param = *params_ptr;
                }
            }
        }
        public static void GetTexLevelParameter(TextureTarget target, int level, TextureParamName pname, [Out] float[] param)
        {
            unsafe
            {
                fixed (Single* params_ptr = param)
                {
                    glGetTexLevelParameterfv((GLenum)target, level, (GLenum)pname, params_ptr);
                }
            }
        }
        #endregion
        #region glGetTexLevelParameteriv
        [DllImport(GL_LIB, EntryPoint = "glGetTexLevelParameteriv")]
        private static unsafe extern void glGetTexLevelParameteriv(GLenum target, GLint level, GLenum pname, GLint* param);
        public static void GetTexLevelParameter(TextureTarget target, int level, TextureParamName pname, out int param)
        {
            unsafe
            {
                fixed (Int32* params_ptr = &param)
                {
                    glGetTexLevelParameteriv((GLenum)target, level, (GLenum)pname, params_ptr);
                    param = *params_ptr;
                }
            }
        }
        public static void GetTexLevelParameter(TextureTarget target, int level, TextureParamName pname, [Out] int[] param)
        {
            unsafe
            {
                fixed (Int32* params_ptr = param)
                {
                    glGetTexLevelParameteriv((GLenum)target, level, (GLenum)pname, params_ptr);
                }
            }
        }
        #endregion
        #region glIsEnabled
        [DllImport(GL_LIB, EntryPoint = "glIsEnabled")]
        private static extern GLboolean glIsEnabled(GLenum cap);
        public static bool IsEnabled(EnableCap cap)
        {
            return glIsEnabled((GLenum)cap);
        }
        #endregion
        #region glDepthRange
        [DllImport(GL_LIB, EntryPoint = "glDepthRange")]
        private static extern void glDepthRange(GLdouble near, GLdouble far);
        public static void DepthRange(double near, double far)
        {
            glDepthRange(near, far);
        }
        #endregion
        #region glViewport
        [DllImport(GL_LIB, EntryPoint = "glViewport")]
        private static extern void glViewport(GLint x, GLint y, GLsizei width, GLsizei height);
        public static void Viewport(int x, int y, int width, int height)
        {
            glViewport(x, y, width, height);
        }
        public static void Viewport(Box r)
        {
            glViewport((int)r.X, (int)r.Y, (int)r.Width, (int)r.Height);
        }
        #endregion
        #endregion
        #region OPENGL 1.1
        #region glDrawArrays
        [DllImport(GL_LIB, EntryPoint = "glDrawArrays")]
        private static extern void glDrawArrays(GLenum mode, GLint first, GLsizei count);
        public static void DrawArrays(DrawMode mode, int first, int count)
        {
            glDrawArrays((GLenum)mode, first, count);
        }
        #endregion
        #region glDrawElements
        [DllImport(GL_LIB, EntryPoint = "glDrawElements")]
        private static extern void glDrawElements(GLenum mode, GLsizei count, GLenum type, IntPtr indices);
        public static void DrawElements(DrawMode mode, int count, DrawElementsType type, IntPtr indices)
        {
            glDrawElements((GLenum)mode, count, (GLenum)type, indices);
        }
        #endregion
        #region glPolygonOffset
        [DllImport(GL_LIB, EntryPoint = "glPolygonOffset")]
        private static extern void glPolygonOffset(GLfloat factor, GLfloat units);
        public static void PolygonOffset(float factor, float units)
        {
            glPolygonOffset(factor, units);
        }
        #endregion
        #region glCopyTexImage1D
        [DllImport(GL_LIB, EntryPoint = "glCopyTexImage1D")]
        private static extern void glCopyTexImage1D(GLenum target, GLint level, GLenum internalformat, GLint x, GLint y, GLsizei width, GLint border);
        public static void CopyTexImage1D(TextureTarget target, int level, PixelInternalFormat internalformat, int x, int y, int width, int border)
        {
            glCopyTexImage1D((GLenum)target, level, (GLenum)internalformat, x, y, width, border);
        }
        #endregion
        #region glCopyTexImage2D
        [DllImport(GL_LIB, EntryPoint = "glCopyTexImage2D")]
        private static extern void glCopyTexImage2D(GLenum target, GLint level, GLenum internalformat, GLint x, GLint y, GLsizei width, GLsizei height, GLint border);
        public static void CopyTexImage2D(TextureTarget target, int level, PixelInternalFormat internalformat, int x, int y, int width, int height, int border)
        {
            glCopyTexImage2D((GLenum)target, level, (GLenum)internalformat, x, y, width, height, border);
        }
        #endregion
        #region glCopyTexSubImage1D
        [DllImport(GL_LIB, EntryPoint = "glCopyTexSubImage1D")]
        private static extern void glCopyTexSubImage1D(GLenum target, GLint level, GLint xoffset, GLint x, GLint y, GLsizei width);
        public static void CopyTexSubImage1D(TextureTarget target, int level, int xoffset, int x, int y, int width)
        {
            glCopyTexSubImage1D((GLenum)target, level, xoffset, x, y, width);
        }
        #endregion
        #region glCopyTexSubImage2D
        [DllImport(GL_LIB, EntryPoint = "glCopyTexSubImage2D")]
        private static extern void glCopyTexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint x, GLint y, GLsizei width, GLsizei height);
        public static void CopyTexSubImage2D(TextureTarget target, int level, int xoffset, int yoffset, int x, int y, int width, int height)
        {
            glCopyTexSubImage2D((GLenum)target, level, xoffset, yoffset, x, y, width, height);
        }
        #endregion
        #region glTexSubImage1D
        [DllImport(GL_LIB, EntryPoint = "glTexSubImage1D")]
        private static extern void glTexSubImage1D(GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLenum type, IntPtr pixels);
        public static void TexSubImage1D<T>(TextureTarget target, int level, int xoffset, int width, PixelFormat format, PixelType type, T[] pixels) where T : struct
        {
            GCHandle pixels_ptr = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                glTexSubImage1D((GLenum)target, level, xoffset, width, (GLenum)format, (GLenum)type, pixels_ptr.AddrOfPinnedObject());
            }
            finally
            {
                pixels_ptr.Free();
            }
        }
        #endregion
        #region glTexSubImage2D
        [DllImport(GL_LIB, EntryPoint = "glTexSubImage2D")]
        private static extern void glTexSubImage2D(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLenum type, IntPtr pixels);
        public static void TexSubImage2D<T>(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, T[] pixels) where T : struct
        {
            GCHandle pixels_ptr = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                glTexSubImage2D((GLenum)target, level, xoffset, yoffset, width, height, (GLenum)format, (GLenum)type, pixels_ptr.AddrOfPinnedObject());
            }
            finally
            {
                pixels_ptr.Free();
            }
        }
        #endregion
        #region glBindTexture
        [DllImport(GL_LIB, EntryPoint = "glBindTexture")]
        private static extern void glBindTexture(GLenum target, GLuint texture);
        public static void BindTexture(TextureTarget target, int texture)
        {
            glBindTexture((GLenum)target, (GLuint)texture);
        }
        #endregion
        #region glDeleteTextures
        [DllImport(GL_LIB, EntryPoint = "glDeleteTextures")]
        private static unsafe extern void glDeleteTextures(GLsizei n, GLuint* textures);
        public static void DeleteTextures(int n, int[] textures)
        {
            unsafe
            {
                fixed (int* textures_ptr = textures)
                {
                    glDeleteTextures(n, (GLuint*)textures_ptr);
                }
            }
        }
        public static void DeleteTextures(int n, ref int textures)
        {
            unsafe
            {
                fixed (int* textures_ptr = &textures)
                {
                    glDeleteTextures(n, (GLuint*)textures_ptr);
                }
            }
        }
        #endregion
        #region glGenTextures
        [DllImport(GL_LIB, EntryPoint = "glGenTextures")]
        private static unsafe extern void glGenTextures(GLsizei n, GLuint* textures);
        public static void GenTextures(int n, [Out] int[] textures)
        {
            unsafe
            {
                fixed (Int32* textures_ptr = textures)
                {
                    glGenTextures((GLsizei)n, (GLuint*)textures_ptr);
                }
            }
        }
        public static void GenTextures(int n, out int textures)
        {
            unsafe
            {
                fixed (Int32* textures_ptr = &textures)
                {
                    glGenTextures((GLsizei)n, (GLuint*)textures_ptr);
                    textures = *textures_ptr;
                }
            }
        }
        #endregion
        #region glIsTexture
        [DllImport(GL_LIB, EntryPoint = "glIsTexture")]
        private static extern GLboolean glIsTexture(GLuint texture);
        public static bool IsTexture(int texture)
        {
            return glIsTexture((GLuint)texture);
        }
        #endregion
        #endregion
        #region OPENGL 1.2
        #region glDrawRangeElements
        private delegate void glDrawRangeElementsDelegate(GLenum mode, GLuint start, GLuint end, GLsizei count, GLenum type, IntPtr indices);
        private static glDrawRangeElementsDelegate glDrawRangeElements = null;
        public static void DrawRangeElements(DrawMode mode, int start, int end, int count, DrawElementsType type, IntPtr indices)
        {
            glDrawRangeElements((GLenum)mode, (GLuint)start, (GLuint)end, count, (GLenum)type, indices);
        }
        #endregion
        #region glTexImage3D
        private delegate void glTexImage3DDelegate(GLenum target, GLint level, GLint internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLenum format, GLenum type, IntPtr pixels);
        private static glTexImage3DDelegate glTexImage3D = null;
        public static void TexImage3D<T>(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int height, int depth, int border, PixelFormat format, PixelType type, T[] pixels) where T : struct
        {
            GCHandle pixels_ptr = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                glTexImage3D((GLenum)target, level, (GLint)internalformat, width, height, depth, border, (GLenum)format, (GLenum)type, pixels_ptr.AddrOfPinnedObject());
            }
            finally
            {
                pixels_ptr.Free();
            }
        }
        #endregion
        #region glTexSubImage3D
        private delegate void glTexSubImage3DDelegate(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, IntPtr pixels);
        private static glTexSubImage3DDelegate glTexSubImage3D = null;
        public static void TexSubImage3D<T>(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, T[] pixels) where T : struct
        {
            GCHandle pixels_ptr = GCHandle.Alloc(pixels, GCHandleType.Pinned);
            try
            {
                glTexSubImage3D((GLenum)target, level, xoffset, yoffset, zoffset, width, height, depth, (GLenum)format, (GLenum)type, pixels_ptr.AddrOfPinnedObject());
            }
            finally
            {
                pixels_ptr.Free();
            }
        }
        #endregion
        #region glCopyTexSubImage3D
        private delegate void glCopyTexSubImage3DDelegate(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLint x, GLint y, GLsizei width, GLsizei height);
        private static glCopyTexSubImage3DDelegate glCopyTexSubImage3D = null;
        public static void CopyTexSubImage3D(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int x, int y, int width, int height)
        {
            glCopyTexSubImage3D((GLenum)target, level, xoffset, yoffset, zoffset, x, y, width, height);
        }
        #endregion
        #endregion
        #region OPENGL 1.3
        #region glActiveTexture
        private delegate void glActiveTextureDelegate(GLenum texture);
        private static glActiveTextureDelegate glActiveTexture = null;
        public static void ActiveTexture(TextureUnit texture)
        {
            glActiveTexture((GLenum)texture);
        }
        public static void ActiveTexture(uint texture)
        {
            glActiveTexture(((uint)TextureUnit.GL_TEXTURE0) + texture);
        }
        #endregion
        #region glSampleCoverage
        private delegate void glSampleCoverageDelegate(GLfloat value, GLboolean invert);
        private static glSampleCoverageDelegate glSampleCoverage = null;
        public static void SampleCoverage(float value, bool invert)
        {
            glSampleCoverage(value, invert);
        }
        #endregion
        #region glCompressedTexImage3D
        private delegate void glCompressedTexImage3DDelegate(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLsizei imageSize, IntPtr data);
        private static glCompressedTexImage3DDelegate glCompressedTexImage3D = null;
        public static void CompressedTexImage3D<T>(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int height, int depth, int border, int imageSize, T[] data) where T : struct
        {
            GCHandle data_ptr = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                glCompressedTexImage3D((GLenum)target, level, (GLenum)internalformat, width, height, depth, border, imageSize, data_ptr.AddrOfPinnedObject());
            }
            finally
            {
                data_ptr.Free();
            }
        }
        #endregion
        #region glCompressedTexImage2D
        private delegate void glCompressedTexImage2DDelegate(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLint border, GLsizei imageSize, IntPtr data);
        private static glCompressedTexImage2DDelegate glCompressedTexImage2D = null;
        public static void CompressedTexImage2D<T>(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int height, int border, int imageSize, T[] data) where T : struct
        {
            GCHandle data_ptr = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                glCompressedTexImage2D((GLenum)target, level, (GLenum)internalformat, width, height, border, imageSize, data_ptr.AddrOfPinnedObject());
            }
            finally
            {
                data_ptr.Free();
            }
        }
        #endregion
        #region glCompressedTexImage1D
        private delegate void glCompressedTexImage1DDelegate(GLenum target, GLint level, GLenum internalformat, GLsizei width, GLint border, GLsizei imageSize, IntPtr data);
        private static glCompressedTexImage1DDelegate glCompressedTexImage1D = null;
        public static void CompressedTexImage1D<T>(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int border, int imageSize, T[] data) where T : struct
        {
            GCHandle data_ptr = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                glCompressedTexImage1D((GLenum)target, level, (GLenum)internalformat, width, border, imageSize, data_ptr.AddrOfPinnedObject());
            }
            finally
            {
                data_ptr.Free();
            }
        }
        #endregion
        #region glCompressedTexSubImage3D
        private delegate void glCompressedTexSubImage3DDelegate(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLsizei imageSize, IntPtr data);
        private static glCompressedTexSubImage3DDelegate glCompressedTexSubImage3D = null;
        public static void CompressedTexSubImage3D<T>(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, int imageSize, T[] data) where T : struct
        {
            GCHandle data_ptr = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                glCompressedTexSubImage3D((GLenum)target, level, xoffset, yoffset, zoffset, width, height, depth, (GLenum)format, imageSize, data_ptr.AddrOfPinnedObject());
            }
            finally
            {
                data_ptr.Free();
            }
        }
        #endregion
        #region glCompressedTexSubImage2D
        private delegate void glCompressedTexSubImage2DDelegate(GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLsizei imageSize, IntPtr data);
        private static glCompressedTexSubImage2DDelegate glCompressedTexSubImage2D = null;
        public static void CompressedTexSubImage2D<T>(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, int imageSize, T[] data) where T : struct
        {
            GCHandle data_ptr = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                glCompressedTexSubImage2D((GLenum)target, level, xoffset, yoffset, width, height, (GLenum)format, imageSize, data_ptr.AddrOfPinnedObject());
            }
            finally
            {
                data_ptr.Free();
            }
        }
        #endregion
        #region glCompressedTexSubImage1D
        private delegate void glCompressedTexSubImage1DDelegate(GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLsizei imageSize, IntPtr data);
        private static glCompressedTexSubImage1DDelegate glCompressedTexSubImage1D = null;
        public static void CompressedTexSubImage1D<T>(TextureTarget target, int level, int xoffset, int width, PixelFormat format, int imageSize, T[] data) where T : struct
        {
            GCHandle data_ptr = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                glCompressedTexSubImage1D((GLenum)target, level, xoffset, width, (GLenum)format, imageSize, data_ptr.AddrOfPinnedObject());
            }
            finally
            {
                data_ptr.Free();
            }
        }
        #endregion
        #region glGetCompressedTexImage
        private delegate void glGetCompressedTexImageDelegate(GLenum target, GLint level, IntPtr img);
        private static glGetCompressedTexImageDelegate glGetCompressedTexImage = null;
        public static void GetCompressedTexImage(TextureTarget target, int level, IntPtr img)
        {
            glGetCompressedTexImage((GLenum)target, level, img);
        }
        #endregion
        #endregion
        #region OPENGL 1.4
        #region glBlendFuncSeparate
        private delegate void glBlendFuncSeparateDelegate(GLenum sfactorRGB, GLenum dfactorRGB, GLenum sfactorAlpha, GLenum dfactorAlpha);
        private static glBlendFuncSeparateDelegate glBlendFuncSeparate = null;
        public static void BlendFuncSeparate(BlendFactor sfactorRGB, BlendFactor dfactorRGB, BlendFactor sfactorAlpha, BlendFactor dfactorAlpha)
        {
            glBlendFuncSeparate((GLenum)sfactorRGB, (GLenum)dfactorRGB, (GLenum)sfactorAlpha, (GLenum)dfactorAlpha);
        }
        #endregion
        #region glMultiDrawArrays
        private unsafe delegate void glMultiDrawArraysDelegate(GLenum mode, GLint* first, GLsizei* count, GLsizei drawcount);
        private static glMultiDrawArraysDelegate glMultiDrawArrays = null;
        public static void MultiDrawArrays(DrawMode mode, int[] first, int[] count, int drawcount)
        {
            unsafe
            {
                fixed (int* first_ptr = first, count_ptr = count)
                {
                    glMultiDrawArrays((GLenum)mode, first_ptr, count_ptr, drawcount);
                }
            }
        }
        #endregion
        #region glMultiDrawElements
        private unsafe delegate void glMultiDrawElementsDelegate(GLenum mode, GLsizei* count, GLenum type, IntPtr indices, GLsizei drawcount);
        private static glMultiDrawElementsDelegate glMultiDrawElements = null;
        public static void MultiDrawElements(DrawMode mode, int[] count, DrawElementsType type, IntPtr indices, int drawcount)
        {
            unsafe
            {
                fixed (int* count_ptr = count)
                {
                    glMultiDrawElements((GLenum)mode, count_ptr, (GLenum)type, indices, drawcount);
                }
            }
        }
        #endregion
        #region glPointParameterf
        private delegate void glPointParameterfDelegate(GLenum pname, GLfloat param);
        private static glPointParameterfDelegate glPointParameterf = null;
        public static void PointParameter(PointParamName pname, float param)
        {
            glPointParameterf((GLenum)pname, param);
        }
        #endregion
        #region glPointParameterfv
        private unsafe delegate void glPointParameterfvDelegate(GLenum pname, GLfloat* param);
        private static glPointParameterfvDelegate glPointParameterfv = null;
        public static void PointParameter(PointParamName pname, float[] param)
        {
            unsafe
            {
                fixed (float* param_ptr = param)
                {
                    glPointParameterfv((GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glPointParameteri
        private delegate void glPointParameteriDelegate(GLenum pname, GLint param);
        private static glPointParameteriDelegate glPointParameteri = null;
        public static void PointParameter(PointParamName pname, int param)
        {
            glPointParameteri((GLenum)pname, param);
        }
        #endregion
        #region glPointParameteriv
        private unsafe delegate void glPointParameterivDelegate(GLenum pname, GLint* param);
        private static glPointParameterivDelegate glPointParameteriv = null;
        public static void PointParameter(PointParamName pname, int[] param)
        {
            unsafe
            {
                fixed (int* param_ptr = param)
                {
                    glPointParameteriv((GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glBlendColor
        private delegate void glBlendColorDelegate(GLfloat red, GLfloat green, GLfloat blue, GLfloat alpha);
        private static glBlendColorDelegate glBlendColor = null;
        public static void BlendColor(float red, float green, float blue, float alpha)
        {
            glBlendColor(red, green, blue, alpha);
        }
        public static void BlendColor(Color4 color)
        {
            glBlendColor(color.Red, color.Green, color.Blue, color.Alpha);
        }
        #endregion
        #region glBlendEquation
        private delegate void glBlendEquationDelegate(GLenum mode);
        private static glBlendEquationDelegate glBlendEquation = null;
        public static void BlendEquation(BlendEquationMode mode)
        {
            glBlendEquation((GLenum)mode);
        }
        #endregion
        #endregion
        #region OPENGL 1.5
        #region glGenQueries
        private unsafe delegate void glGenQueriesDelegate(GLsizei n, GLuint* ids);
        private static glGenQueriesDelegate glGenQueries = null;
        public static void GenQueries(int n, [Out] int[] ids)
        {
            unsafe
            {
                fixed (Int32* ids_ptr = ids)
                {
                    glGenQueries((GLsizei)n, (GLuint*)ids_ptr);
                }
            }
        }
        public static void GenQueries(int n, out int ids)
        {
            unsafe
            {
                fixed (Int32* ids_ptr = &ids)
                {
                    glGenQueries((GLsizei)n, (GLuint*)ids_ptr);
                    ids = *ids_ptr;
                }
            }
        }
        #endregion
        #region glDeleteQueries
        private unsafe delegate void glDeleteQueriesDelegate(GLsizei n, GLuint* ids);
        private static glDeleteQueriesDelegate glDeleteQueries = null;
        public static void DeleteQueries(int n, int[] ids)
        {
            unsafe
            {
                fixed (int* ids_ptr = ids)
                {
                    glDeleteQueries(n, (GLuint*)ids_ptr);
                }
            }
        }
        public static void DeleteQueries(int n, ref int ids)
        {
            unsafe
            {
                fixed (int* ids_ptr = &ids)
                {
                    glDeleteQueries(n, (GLuint*)ids_ptr);
                }
            }
        }
        #endregion
        #region glIsQuery
        private delegate GLboolean glIsQueryDelegate(GLuint id);
        private static glIsQueryDelegate glIsQuery = null;
        public static bool IsQuery(int id)
        {
            return glIsQuery((GLuint)id);
        }
        #endregion
        #region glBeginQuery
        private delegate void glBeginQueryDelegate(GLenum target, GLuint id);
        private static glBeginQueryDelegate glBeginQuery = null;
        public static void BeginQuery(QueryTarget target, int id)
        {
            glBeginQuery((GLenum)target, (GLuint)id);
        }
        #endregion
        #region glEndQuery
        private delegate void glEndQueryDelegate(GLenum target);
        private static glEndQueryDelegate glEndQuery = null;
        public static void EndQuery(QueryTarget target)
        {
            glEndQuery((GLenum)target);
        }
        #endregion
        #region glGetQueryiv
        private unsafe delegate void glGetQueryivDelegate(GLenum target, GLenum pname, GLint* param);
        private static glGetQueryivDelegate glGetQueryiv = null;
        public static void GetQuery(QueryTarget target, QueryParamName pname, out int param)
        {
            unsafe
            {
                fixed (Int32* param_ptr = &param)
                {
                    glGetQueryiv((GLenum)target, (GLenum)pname, param_ptr);
                    param = *param_ptr;
                }
            }
        }
        public static void GetQuery(QueryTarget target, QueryParamName pname, [Out] int[] param)
        {
            unsafe
            {
                fixed (Int32* param_ptr = param)
                {
                    glGetQueryiv((GLenum)target, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glGetQueryObjectiv
        private unsafe delegate void glGetQueryObjectivDelegate(GLuint id, GLenum pname, GLint* param);
        private static glGetQueryObjectivDelegate glGetQueryObjectiv = null;
        public static void GetQueryObject(int id, QueryObjectParamName pname, out int param)
        {
            unsafe
            {
                fixed (Int32* param_ptr = &param)
                {
                    glGetQueryObjectiv((GLuint)id, (GLenum)pname, param_ptr);
                    param = *param_ptr;
                }
            }
        }
        public static void GetQueryObject(int id, QueryObjectParamName pname, [Out] int[] param)
        {
            unsafe
            {
                fixed (Int32* param_ptr = param)
                {
                    glGetQueryObjectiv((GLuint)id, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glGetQueryObjectuiv
        private unsafe delegate void glGetQueryObjectuivDelegate(GLuint id, GLenum pname, GLuint* param);
        private static glGetQueryObjectuivDelegate glGetQueryObjectuiv = null;
        public static void GetQueryObject(int id, QueryObjectParamName pname, out uint param)
        {
            unsafe
            {
                fixed (UInt32* param_ptr = &param)
                {
                    glGetQueryObjectuiv((GLuint)id, (GLenum)pname, param_ptr);
                    param = *param_ptr;
                }
            }
        }
        public static void GetQueryObject(int id, QueryObjectParamName pname, [Out] uint[] param)
        {
            unsafe
            {
                fixed (UInt32* param_ptr = param)
                {
                    glGetQueryObjectuiv((GLuint)id, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glBindBuffer
        private unsafe delegate void glBindBufferDelegate(GLenum target, GLuint buffer);
        private static glBindBufferDelegate glBindBuffer = null;
        public static void BindBuffer(BufferTarget target, int buffer)
        {
            glBindBuffer((GLenum)target, (GLuint)buffer);
        }
        #endregion
        #region glDeleteBuffers
        private unsafe delegate void glDeleteBuffersDelegate(GLsizei n, GLuint* buffers);
        private static glDeleteBuffersDelegate glDeleteBuffers = null;
        public static void DeleteBuffers(int n, int[] buffers)
        {
            unsafe
            {
                fixed (int* buffers_ptr = buffers)
                {
                    glDeleteBuffers(n, (GLuint*)buffers_ptr);
                }
            }
        }
        public static void DeleteBuffers(int n, ref int buffers)
        {
            unsafe
            {
                fixed (int* buffers_ptr = &buffers)
                {
                    glDeleteBuffers(n, (GLuint*)buffers_ptr);
                }
            }
        }
        #endregion
        #region glGenBuffers
        private unsafe delegate void glGenBuffersDelegate(GLsizei n, GLuint* buffers);
        private static glGenBuffersDelegate glGenBuffers = null;
        public static void GenBuffers(int n, [Out] int[] buffers)
        {
            unsafe
            {
                fixed (Int32* buffers_ptr = buffers)
                {
                    glGenBuffers((GLsizei)n, (GLuint*)buffers_ptr);
                }
            }
        }
        public static void GenBuffers(int n, out int buffers)
        {
            unsafe
            {
                fixed (Int32* buffers_ptr = &buffers)
                {
                    glGenBuffers((GLsizei)n, (GLuint*)buffers_ptr);
                    buffers = *buffers_ptr;
                }
            }
        }
        #endregion
        #region glIsBuffer
        private delegate GLboolean glIsBufferDelegate(GLuint buffer);
        private static glIsBufferDelegate glIsBuffer = null;
        public static bool IsBuffer(int buffer)
        {
            return glIsBuffer((GLuint)buffer);
        }
        #endregion
        #region glBufferData
        private delegate void glBufferDataDelegate(GLenum target, GLsizeiptr size, IntPtr data, GLenum usage);
        private static glBufferDataDelegate glBufferData = null;
        public static void BufferData(BufferTarget target, IntPtr size, IntPtr data, BufferUsage usage)
        {
            glBufferData((GLenum)target, size, data, (GLenum)usage);
        }
        public static void BufferData<T>(BufferTarget target, int size, T[] data, BufferUsage usage) where T : struct
        {
            GCHandle data_ptr = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                glBufferData((GLenum)target, (IntPtr)size, data_ptr.AddrOfPinnedObject(), (GLenum)usage);
            }
            finally
            {
                data_ptr.Free();
            }
        }
        #endregion
        #region glBufferSubData
        private delegate void glBufferSubDataDelegate(GLenum target, GLintptr offset, GLsizeiptr size, IntPtr data);
        private static glBufferSubDataDelegate glBufferSubData = null;
        public static void BufferSubData(BufferTarget target, IntPtr offset, IntPtr size, IntPtr data)
        {
            glBufferSubData((GLenum)target, offset, size, data);
        }
        public static void BufferSubData<T>(BufferTarget target, int offset, int size, T[] data) where T : struct
        {
            GCHandle data_ptr = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                glBufferSubData((GLenum)target, (IntPtr)offset, (IntPtr)size, data_ptr.AddrOfPinnedObject());
            }
            finally
            {
                data_ptr.Free();
            }
        }
        #endregion
        #region glGetBufferSubData
        private delegate void glGetBufferSubDataDelegate(GLenum target, GLintptr offset, GLsizeiptr size, IntPtr data);
        private static glGetBufferSubDataDelegate glGetBufferSubData = null;
        public static void GetBufferSubData(BufferTarget target, IntPtr offset, IntPtr size, IntPtr data)
        {
            glGetBufferSubData((GLenum)target, offset, size, data);
        }
        #endregion
        #region glMapBuffer
        private delegate IntPtr glMapBufferDelegate(GLenum target, GLenum access);
        private static glMapBufferDelegate glMapBuffer = null;
        public static IntPtr MapBuffer(BufferTarget target, BufferAccess access)
        {
            return glMapBuffer((GLenum)target, (GLenum)access);
        }
        #endregion
        #region glUnmapBuffer
        private delegate GLboolean glUnmapBufferDelegate(GLenum target);
        private static glUnmapBufferDelegate glUnmapBuffer = null;
        public static bool UnmapBuffer(BufferTarget target)
        {
            return glUnmapBuffer((GLenum)target);
        }
        #endregion
        #region glGetBufferParameteriv
        private unsafe delegate void glGetBufferParameterivDelegate(GLenum target, GLenum pname, GLint* param);
        private static glGetBufferParameterivDelegate glGetBufferParameteriv = null;
        public static void GetBufferParameter(BufferTarget target, BufferParamName pname, out int param)
        {
            unsafe
            {
                fixed (Int32* params_ptr = &param)
                {
                    glGetBufferParameteriv((GLenum)target, (GLenum)pname, params_ptr);
                    param = *params_ptr;
                }
            }
        }
        public static void GetBufferParameter(BufferTarget target, BufferParamName pname, [Out] int[] param)
        {
            unsafe
            {
                fixed (Int32* params_ptr = param)
                {
                    glGetBufferParameteriv((GLenum)target, (GLenum)pname, params_ptr);
                }
            }
        }
        #endregion
        #region glGetBufferPointerv
        private delegate void glGetBufferPointervDelegate(GLenum target, GLenum pname, IntPtr param);
        private static glGetBufferPointervDelegate glGetBufferPointerv = null;
        public static void GetBufferPointer(BufferTarget target, BufferPointerParamName pname, IntPtr param)
        {
            glGetBufferPointerv((GLenum)target, (GLenum)pname, param);
        }
        #endregion
        #endregion
        #region OPENGL 2.0
        #region glBlendEquationSeparate
        private delegate void glBlendEquationSeparateDelegate(GLenum modeRGB, GLenum modeAlpha);
        private static glBlendEquationSeparateDelegate glBlendEquationSeparate = null;
        public static void BlendEquationSeparate(BlendEquationMode modeRGB, BlendEquationMode modeAlpha)
        {
            glBlendEquationSeparate((GLenum)modeRGB, (GLenum)modeAlpha);
        }
        #endregion
        #region glDrawBuffers
        private unsafe delegate void glDrawBuffersDelegate(GLsizei n, GLenum* bufs);
        private static glDrawBuffersDelegate glDrawBuffers = null;
        public static void DrawBuffers(int n, DrawBuffersEnum[] bufs)
        {
            unsafe
            {
                fixed (DrawBuffersEnum* bufs_ptr = bufs)
                {
                    glDrawBuffers(n, (GLenum*)bufs_ptr);
                }
            }
        }
        #endregion
        #region glStencilOpSeparate
        private delegate void glStencilOpSeparateDelegate(GLenum face, GLenum sfail, GLenum dpfail, GLenum dppass);
        private static glStencilOpSeparateDelegate glStencilOpSeparate = null;
        public static void StencilOpSeparate(StencilFace face, StencilOperation sfail, StencilOperation dpfail, StencilOperation dppass)
        {
            glStencilOpSeparate((GLenum)face, (GLenum)sfail, (GLenum)dpfail, (GLenum)dppass);
        }
        #endregion
        #region glStencilFuncSeparate
        private delegate void glStencilFuncSeparateDelegate(GLenum face, GLenum func, GLint refer, GLuint mask);
        private static glStencilFuncSeparateDelegate glStencilFuncSeparate = null;
        public static void StencilFuncSeparate(StencilFace face, StencilFunction func, int refer, int mask)
        {
            glStencilFuncSeparate((GLenum)face, (GLenum)func, refer, (GLuint)mask);
        }
        #endregion
        #region glStencilMaskSeparate
        private delegate void glStencilMaskSeparateDelegate(GLenum face, GLuint mask);
        private static glStencilMaskSeparateDelegate glStencilMaskSeparate = null;
        public static void StencilMaskSeparate(StencilFace face, int mask)
        {
            glStencilMaskSeparate((GLenum)face, (GLuint)mask);
        }
        #endregion
        #region glAttachShader
        private delegate void glAttachShaderDelegate(GLuint program, GLuint shader);
        private static glAttachShaderDelegate glAttachShader = null;
        public static void AttachShader(int program, int shader)
        {
            glAttachShader((GLuint)program, (GLuint)shader);
        }
        #endregion
        #region glBindAttribLocation
        private delegate void glBindAttribLocationDelegate(GLuint program, GLuint index, string name);
        private static glBindAttribLocationDelegate glBindAttribLocation = null;
        public static void BindAttribLocation(int program, int index, string name)
        {
            glBindAttribLocation((GLuint)program, (GLuint)index, name);
        }
        #endregion
        #region glCompileShader
        private delegate void glCompileShaderDelegate(GLuint shader);
        private static glCompileShaderDelegate glCompileShader = null;
        public static void CompileShader(int shader)
        {
            glCompileShader((GLuint)shader);
        }
        #endregion
        #region glCreateProgram
        private delegate GLuint glCreateProgramDelegate();
        private static glCreateProgramDelegate glCreateProgram = null;
        public static int CreateProgram()
        {
            return (int)glCreateProgram();
        }
        #endregion
        #region glCreateShader
        private delegate GLuint glCreateShaderDelegate(GLenum type);
        private static glCreateShaderDelegate glCreateShader = null;
        public static int CreateShader(ShaderType type)
        {
            return (int)glCreateShader((GLenum)type);
        }
        #endregion
        #region glDeleteProgram
        private delegate void glDeleteProgramDelegate(GLuint program);
        private static glDeleteProgramDelegate glDeleteProgram = null;
        public static void DeleteProgram(int program)
        {
            glDeleteProgram((GLuint)program);
        }
        #endregion
        #region glDeleteShader
        private delegate void glDeleteShaderDelegate(GLuint shader);
        private static glDeleteShaderDelegate glDeleteShader = null;
        public static void DeleteShader(int shader)
        {
            glDeleteShader((GLuint)shader);
        }
        #endregion
        #region glDetachShader
        private delegate void glDetachShaderDelegate(GLuint program, GLuint shader);
        private static glDetachShaderDelegate glDetachShader = null;
        public static void DetachShader(int program, int shader)
        {
            glDetachShader((GLuint)program, (GLuint)shader);
        }
        #endregion
        #region glDisableVertexAttribarray
        private delegate void glDisableVertexAttribArrayDelegate(GLuint index);
        private static glDisableVertexAttribArrayDelegate glDisableVertexAttribArray = null;
        public static void DisableVertexAttribArray(int index)
        {
            glDisableVertexAttribArray((GLuint)index);
        }
        #endregion
        #region glEnableVertexAttribArray
        private delegate void glEnableVertexAttribArrayDelegate(GLuint index);
        private static glEnableVertexAttribArrayDelegate glEnableVertexAttribArray = null;
        public static void EnableVertexAttribArray(int index)
        {
            glEnableVertexAttribArray((GLuint)index);
        }
        #endregion
        #region glGetActiveAttrib
        private unsafe delegate void glGetActiveAttribDelegate(GLuint program, GLuint index, GLsizei bufSize, GLsizei* length, GLint* size, GLenum* type, StringBuilder name);
        private static glGetActiveAttribDelegate glGetActiveAttrib = null;
        public static void GetActiveAttrib(int program, int index, int bufSize, out int length, out int size, out ActiveAttribType type, StringBuilder name)
        {
            unsafe
            {
                fixed (int* length_ptr = &length, size_ptr = &size)
                fixed (ActiveAttribType* type_ptr = &type)
                {
                    glGetActiveAttrib((GLuint)program, (GLuint)index, bufSize, length_ptr, size_ptr, (GLenum*)type_ptr, name);
                }
            }
        }
        public static string GetActiveAttrib(int program, int index)
        {
            int length;
            GL.GetProgram(program, ProgramParamName.GL_ACTIVE_ATTRIBUTE_MAX_LENGTH, out length);
            if (length == 0)
            {
                return String.Empty;
            }
            StringBuilder name = new StringBuilder(length * 2);
            int size;
            ActiveAttribType type;
            GL.GetActiveAttrib(program, index, name.Capacity, out length, out size, out type, name);
            return name.ToString();
        }
        #endregion
        #region glGetActiveUniform
        private unsafe delegate void glGetActiveUniformDelegate(GLuint program, GLuint index, GLsizei bufSize, GLsizei* length, GLint* size, GLenum* type, StringBuilder name);
        private static glGetActiveUniformDelegate glGetActiveUniform = null;
        public static void GetActiveUniform(int program, int index, int bufSize, out int length, out int size, out ActiveUniformType type, StringBuilder name)
        {
            unsafe
            {
                fixed (int* length_ptr = &length, size_ptr = &size)
                fixed (ActiveUniformType* type_ptr = &type)
                {
                    glGetActiveUniform((GLuint)program, (GLuint)index, bufSize, length_ptr, size_ptr, (GLenum*)type_ptr, name);
                }
            }
        }
        public static string GetActiveUniform(int program, int index)
        {
            int length;
            GL.GetProgram(program, ProgramParamName.GL_ACTIVE_UNIFORM_MAX_LENGTH, out length);
            if (length == 0)
            {
                return String.Empty;
            }
            StringBuilder name = new StringBuilder(length * 2);
            int size;
            ActiveUniformType type;
            GL.GetActiveUniform(program, index, name.Capacity, out length, out size, out type, name);
            return name.ToString();
        }
        #endregion
        #region glGetAttachedShaders
        private unsafe delegate void glGetAttachedShadersDelegate(GLuint program, GLsizei maxCount, GLsizei* count, GLuint* shaders);
        private static glGetAttachedShadersDelegate glGetAttachedShaders = null;
        public static void GetAttachedShaders(int program, int maxCount, out int count, [Out] int[] shaders)
        {
            unsafe
            {
                fixed (int* count_ptr = &count)
                fixed (int* shaders_ptr = shaders)
                {
                    glGetAttachedShaders((GLuint)program, maxCount, count_ptr, (GLuint*)shaders_ptr);
                }
            }
        }
        #endregion
        #region glGetAttribLocation
        private delegate GLint glGetAttribLocationDelegate(GLuint program, string name);
        private static glGetAttribLocationDelegate glGetAttribLocation = null;
        public static int GetAttribLocation(int program, string name)
        {
            return glGetAttribLocation((GLuint)program, name);
        }
        #endregion
        #region glGetProgramiv
        private unsafe delegate void glGetProgramivDelegate(GLuint program, GLenum pname, GLint* param);
        private static glGetProgramivDelegate glGetProgramiv = null;
        public static void GetProgram(int program, ProgramParamName pname, out int param)
        {
            unsafe
            {
                fixed (int* param_ptr = &param)
                {
                    glGetProgramiv((GLuint)program, (GLenum)pname, param_ptr);
                    param = *param_ptr;
                }
            }
        }
        #endregion
        #region glGetProgramInfoLog
        private unsafe delegate void glGetProgramInfoLogDelegate(GLuint program, GLsizei bufSize, GLsizei* length, StringBuilder infoLog);
        private static glGetProgramInfoLogDelegate glGetProgramInfoLog = null;
        public static void GetProgramInfoLog(int program, int bufSize, out int length, StringBuilder infoLog)
        {
            unsafe
            {
                fixed (int* length_ptr = &length)
                {
                    glGetProgramInfoLog((GLuint)program, bufSize, length_ptr, infoLog);
                }
            }
        }
        public static string GetProgramInfoLog(int program)
        {
            int length;
            GL.GetProgram(program, ProgramParamName.GL_INFO_LOG_LENGTH, out length);
            if (length == 0)
            {
                return String.Empty;
            }
            StringBuilder infolog = new StringBuilder(length * 2);
            GL.GetProgramInfoLog(program, infolog.Capacity, out length, infolog);
            return infolog.ToString();
        }
        #endregion
        #region glGetShaderiv
        private unsafe delegate void glGetShaderivDelegate(GLuint shader, GLenum pname, GLint* param);
        private static glGetShaderivDelegate glGetShaderiv = null;
        public static void GetShader(int shader, ShaderParamName pname, out int param)
        {
            unsafe
            {
                fixed (int* param_ptr = &param)
                {
                    glGetShaderiv((GLuint)shader, (GLenum)pname, param_ptr);
                }
            }
        }
        public static void GetShader(int shader, ShaderParamName pname, [Out] int[] param)
        {
            unsafe
            {
                fixed (int* param_ptr = param)
                {
                    glGetShaderiv((GLuint)shader, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glGetShaderInfoLog
        private unsafe delegate void glGetShaderInfoLogDelegate(GLuint shader, GLsizei bufSize, GLsizei* length, StringBuilder infoLog);
        private static glGetShaderInfoLogDelegate glGetShaderInfoLog = null;
        public static void GetShaderInfoLog(int shader, int bufSize, out int length, StringBuilder infolog)
        {
            unsafe
            {
                fixed (int* length_ptr = &length)
                {
                    glGetShaderInfoLog((GLuint)shader, bufSize, length_ptr, infolog);
                }
            }
        }
        public static string GetShaderInfoLog(int shader)
        {
            int length;
            GL.GetShader(shader, ShaderParamName.GL_INFO_LOG_LENGTH, out length);
            if (length == 0)
            {
                return String.Empty;
            }
            StringBuilder infolog = new StringBuilder(length * 2);
            GL.GetShaderInfoLog(shader, infolog.Capacity, out length, infolog);
            return infolog.ToString();
        }
        #endregion
        #region glGetShaderSource
        private unsafe delegate void glGetShaderSourceDelegate(GLuint shader, GLsizei bufSize, GLsizei* length, StringBuilder source);
        private static glGetShaderSourceDelegate glGetShaderSource = null;
        public static void GetShaderSource(int shader, int bufSize, out int length, StringBuilder source)
        {
            unsafe
            {
                fixed (int* length_ptr = &length)
                {
                    glGetShaderSource((GLuint)shader, bufSize, length_ptr, source);
                }
            }
        }
        #endregion
        #region glGetUniformLocation
        private delegate GLint glGetUniformLocationDelegate(GLuint program, string name);
        private static glGetUniformLocationDelegate glGetUniformLocation = null;
        public static int GetUniformLocation(int program, string name)
        {
            return glGetUniformLocation((GLuint)program, name);
        }
        #endregion
        #region glGetUniformfv
        private unsafe delegate void glGetUniformfvDelegate(GLuint program, GLint location, GLfloat* param);
        private static glGetUniformfvDelegate glGetUniformfv = null;
        public static void GetUniform(int program, int location, out float param)
        {
            unsafe
            {
                fixed (float* param_ptr = &param)
                {
                    glGetUniformfv((GLuint)program, location, param_ptr);
                }
            }
        }
        public static void GetUniform(int program, int location, [Out] float[] param)
        {
            unsafe
            {
                fixed (float* param_ptr = param)
                {
                    glGetUniformfv((GLuint)program, location, param_ptr);
                }
            }
        }
        #endregion
        #region glGetUniformiv
        private unsafe delegate void glGetUniformivDelegate(GLuint program, GLint location, GLint* param);
        private static glGetUniformivDelegate glGetUniformiv = null;
        public static void GetUniform(int program, int location, out int param)
        {
            unsafe
            {
                fixed (int* param_ptr = &param)
                {
                    glGetUniformiv((GLuint)program, location, param_ptr);
                }
            }
        }
        public static void GetUniform(int program, int location, [Out] int[] param)
        {
            unsafe
            {
                fixed (int* param_ptr = param)
                {
                    glGetUniformiv((GLuint)program, location, param_ptr);
                }
            }
        }
        #endregion
        #region glGetVertexAttribdv
        private unsafe delegate void glGetVertexAttribdvDelegate(GLuint index, GLenum pname, GLdouble* param);
        private static glGetVertexAttribdvDelegate glGetVertexAttribdv = null;
        public static void GetVertexAttrib(int index, VertexAttribParamName pname, out double param)
        {
            unsafe
            {
                fixed (double* param_ptr = &param)
                {
                    glGetVertexAttribdv((GLuint)index, (GLenum)pname, param_ptr);
                }
            }
        }
        public static void GetVertexAttrib(int index, VertexAttribParamName pname, [Out] double[] param)
        {
            unsafe
            {
                fixed (double* param_ptr = param)
                {
                    glGetVertexAttribdv((GLuint)index, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glGetVertexAttribfv
        private unsafe delegate void glGetVertexAttribfvDelegate(GLuint index, GLenum pname, GLfloat* param);
        private static glGetVertexAttribfvDelegate glGetVertexAttribfv = null;
        public static void GetVertexAttrib(int index, VertexAttribParamName pname, out float param)
        {
            unsafe
            {
                fixed (float* param_ptr = &param)
                {
                    glGetVertexAttribfv((GLuint)index, (GLenum)pname, param_ptr);
                }
            }
        }
        public static void GetVertexAttrib(int index, VertexAttribParamName pname, [Out] float[] param)
        {
            unsafe
            {
                fixed (float* param_ptr = param)
                {
                    glGetVertexAttribfv((GLuint)index, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glGetVertexAttribiv
        private unsafe delegate void glGetVertexAttribivDelegate(GLuint index, GLenum pname, GLint* param);
        private static glGetVertexAttribivDelegate glGetVertexAttribiv = null;
        public static void GetVertexAttrib(int index, VertexAttribParamName pname, out int param)
        {
            unsafe
            {
                fixed (int* param_ptr = &param)
                {
                    glGetVertexAttribiv((GLuint)index, (GLenum)pname, param_ptr);
                }
            }
        }
        public static void GetVertexAttrib(int index, VertexAttribParamName pname, [Out] int[] param)
        {
            unsafe
            {
                fixed (int* param_ptr = param)
                {
                    glGetVertexAttribiv((GLuint)index, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glGetVertexAttribPointerv
        private delegate void glGetVertexAttribPointervDelegate(GLuint index, GLenum pname, IntPtr pointer);
        private static glGetVertexAttribPointervDelegate glGetVertexAttribPointerv = null;
        public static void GetVertexAttribPointer(int index, VertexAttribPointerParamName pname, IntPtr pointer)
        {
            glGetVertexAttribPointerv((GLuint)index, (GLenum)pname, pointer);
        }
        #endregion
        #region glIsProgram
        private delegate GLboolean glIsProgramDelegate(GLuint program);
        private static glIsProgramDelegate glIsProgram = null;
        public static bool IsProgram(int program)
        {
            return glIsProgram((GLuint)program);
        }
        #endregion
        #region glIsShader
        private delegate GLboolean glIsShaderDelegate(GLuint shader);
        private static glIsShaderDelegate glIsShader = null;
        public static bool IsShader(int shader)
        {
            return glIsShader((GLuint)shader);
        }
        #endregion
        #region glLinkProgram
        private delegate void glLinkProgramDelegate(GLuint program);
        private static glLinkProgramDelegate glLinkProgram = null;
        public static void LinkProgram(int program)
        {
            glLinkProgram((GLuint)program);
        }
        #endregion
        #region glShaderSource
        private unsafe delegate void glShaderSourceDelegate(GLuint shader, GLsizei count, string[] src, GLint* length);
        private static glShaderSourceDelegate glShaderSource = null;
        public static void ShaderSource(int shader, int count, string[] src, int[] length)
        {
            unsafe
            {
                fixed (int* length_ptr = length)
                {
                    glShaderSource((GLuint)shader, count, src, length_ptr);
                }
            }
        }
        public static void ShaderSource(int shader, string src)
        {
            int[] length = new int[1] { src.Length };
            ShaderSource(shader, 1, new string[] { src }, length);
        }
        #endregion
        #region glUseProgram
        private delegate void glUseProgramDelegate(GLuint program);
        private static glUseProgramDelegate glUseProgram = null;
        public static void UseProgram(int program)
        {
            glUseProgram((GLuint)program);
        }
        #endregion
        #region glUniform1f
        private delegate void glUniform1fDelegate(GLint location, GLfloat v0);
        private static glUniform1fDelegate glUniform1f = null;
        public static void Uniform1(int location, float v0)
        {
            glUniform1f(location, v0);
        }
        #endregion
        #region glUniform2f
        private delegate void glUniform2fDelegate(GLint location, GLfloat v0, GLfloat v1);
        private static glUniform2fDelegate glUniform2f = null;
        public static void Uniform2(int location, float v0, float v1)
        {
            glUniform2f(location, v0, v1);
        }
        #endregion
        #region glUniform3f
        private delegate void glUniform3fDelegate(GLint location, GLfloat v0, GLfloat v1, GLfloat v2);
        private static glUniform3fDelegate glUniform3f = null;
        public static void Uniform3(int location, float v0, float v1, float v2)
        {
            glUniform3f(location, v0, v1, v2);
        }
        #endregion
        #region glUniform4f
        private delegate void glUniform4fDelegate(GLint location, GLfloat v0, GLfloat v1, GLfloat v2, GLfloat v3);
        private static glUniform4fDelegate glUniform4f = null;
        public static void Uniform4(int location, float v0, float v1, float v2, float v3)
        {
            glUniform4f(location, v0, v1, v2, v3);
        }
        #endregion
        #region glUniform1i
        private delegate void glUniform1iDelegate(GLint location, GLint v0);
        private static glUniform1iDelegate glUniform1i = null;
        public static void Uniform1(int location, int v0)
        {
            glUniform1i(location, v0);
        }
        #endregion
        #region glUniform2i
        private delegate void glUniform2iDelegate(GLint location, GLint v0, GLint v1);
        private static glUniform2iDelegate glUniform2i = null;
        public static void Uniform2(int location, int v0, int v1)
        {
            glUniform2i(location, v0, v1);
        }
        #endregion
        #region glUniform3i
        private delegate void glUniform3iDelegate(GLint location, GLint v0, GLint v1, GLint v2);
        private static glUniform3iDelegate glUniform3i = null;
        public static void Uniform3(int location, int v0, int v1, int v2)
        {
            glUniform3i(location, v0, v1, v2);
        }
        #endregion
        #region glUniform4i
        private delegate void glUniform4iDelegate(GLint location, GLint v0, GLint v1, GLint v2, GLint v3);
        private static glUniform4iDelegate glUniform4i = null;
        public static void Uniform4(int location, int v0, int v1, int v2, int v3)
        {
            glUniform4i(location, v0, v1, v2, v3);
        }
        #endregion
        #region glUniform1fv
        private unsafe delegate void glUniform1fvDelegate(GLint location, GLsizei count, GLfloat* value);
        private static glUniform1fvDelegate glUniform1fv = null;
        public static void Uniform1(int location, int count, float[] value)
        {
            unsafe
            {
                fixed (float* value_ptr = value)
                {
                    glUniform1fv(location, count, value_ptr);
                }
            }
        }
        #endregion
        #region glUniform2fv
        private unsafe delegate void glUniform2fvDelegate(GLint location, GLsizei count, GLfloat* value);
        private static glUniform2fvDelegate glUniform2fv = null;
        public static void Uniform2(int location, int count, float[] value)
        {
            unsafe
            {
                fixed (float* value_ptr = value)
                {
                    glUniform2fv(location, count, value_ptr);
                }
            }
        }
        #endregion
        #region glUniform3fv
        private unsafe delegate void glUniform3fvDelegate(GLint location, GLsizei count, GLfloat* value);
        private static glUniform3fvDelegate glUniform3fv = null;
        public static void Uniform3(int location, int count, float[] value)
        {
            unsafe
            {
                fixed (float* value_ptr = value)
                {
                    glUniform3fv(location, count, value_ptr);
                }
            }
        }
        #endregion
        #region glUniform4fv
        private unsafe delegate void glUniform4fvDelegate(GLint location, GLsizei count, GLfloat* value);
        private static glUniform4fvDelegate glUniform4fv = null;
        public static void Uniform4(int location, int count, float[] value)
        {
            unsafe
            {
                fixed (float* value_ptr = value)
                {
                    glUniform4fv(location, count, value_ptr);
                }
            }
        }
        #endregion
        #region glUniform1iv
        private unsafe delegate void glUniform1ivDelegate(GLint location, GLsizei count, GLint* value);
        private static glUniform1ivDelegate glUniform1iv = null;
        public static void Uniform1(int location, int count, int[] value)
        {
            unsafe
            {
                fixed (int* value_ptr = value)
                {
                    glUniform1iv(location, count, value_ptr);
                }
            }
        }
        #endregion
        #region glUniform2iv
        private unsafe delegate void glUniform2ivDelegate(GLint location, GLsizei count, GLint* value);
        private static glUniform2ivDelegate glUniform2iv = null;
        public static void Uniform2(int location, int count, int[] value)
        {
            unsafe
            {
                fixed (int* value_ptr = value)
                {
                    glUniform2iv(location, count, value_ptr);
                }
            }
        }
        #endregion
        #region glUniform3iv
        private unsafe delegate void glUniform3ivDelegate(GLint location, GLsizei count, GLint* value);
        private static glUniform3ivDelegate glUniform3iv = null;
        public static void Uniform3(int location, int count, int[] value)
        {
            unsafe
            {
                fixed (int* value_ptr = value)
                {
                    glUniform3iv(location, count, value_ptr);
                }
            }
        }
        #endregion
        #region glUniform4iv
        private unsafe delegate void glUniform4ivDelegate(GLint location, GLsizei count, GLint* value);
        private static glUniform4ivDelegate glUniform4iv = null;
        public static void Uniform4(int location, int count, int[] value)
        {
            unsafe
            {
                fixed (int* value_ptr = value)
                {
                    glUniform4iv(location, count, value_ptr);
                }
            }
        }
        #endregion
        #region glUniformMatrix2fv
        private unsafe delegate void glUniformMatrix2fvDelegate(GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
        private static glUniformMatrix2fvDelegate glUniformMatrix2fv = null;
        public static void UniformMatrix2(int location, int count, bool transpose, float[] value)
        {
            unsafe
            {
                fixed (float* value_ptr = value)
                {
                    glUniformMatrix2fv(location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glUniformMatrix3fv
        private unsafe delegate void glUniformMatrix3fvDelegate(GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
        private static glUniformMatrix3fvDelegate glUniformMatrix3fv = null;
        public static void UniformMatrix3(int location, int count, bool transpose, float[] value)
        {
            unsafe
            {
                fixed (float* value_ptr = value)
                {
                    glUniformMatrix3fv(location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glUniformMatrix4fv
        private unsafe delegate void glUniformMatrix4fvDelegate(GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
        private static glUniformMatrix4fvDelegate glUniformMatrix4fv = null;
        public static void UniformMatrix4(int location, int count, bool transpose, float[] value)
        {
            unsafe
            {
                fixed (float* value_ptr = value)
                {
                    glUniformMatrix4fv(location, count, transpose, value_ptr);
                }
            }
        }
        public static void UniformMatrix4(int location, bool transpose, ref Matrix4 matrix)
        {
            UniformMatrix4(location, 1, transpose, matrix.ToUniformMatrix());
        }
        public static void UniformMatrix4(int location, ref Matrix4 matrix)
        {
            UniformMatrix4(location, 1, false, matrix.ToUniformMatrix());
        }
        #endregion
        #region glValidateProgram
        private delegate void glValidateProgramDelegate(GLuint program);
        private static glValidateProgramDelegate glValidateProgram = null;
        public static void ValidateProgram(int program)
        {
            glValidateProgram((GLuint)program);
        }
        #endregion
        #region glVertexAttrib1d
        private delegate void glVertexAttrib1dDelegate(GLuint index, GLdouble x);
        private static glVertexAttrib1dDelegate glVertexAttrib1d = null;
        public static void VertexAttrib1(int index, double x)
        {
            glVertexAttrib1d((GLuint)index, x);
        }
        #endregion
        #region glVertexAttrib1dv
        private unsafe delegate void glVertexAttrib1dvDelegate(GLuint index, GLdouble* v);
        private static glVertexAttrib1dvDelegate glVertexAttrib1dv = null;
        public static void VertexAttrib1(int index, ref double v)
        {
            unsafe
            {
                fixed (double* v_ptr = &v)
                {
                    glVertexAttrib1dv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttrib1f
        private delegate void glVertexAttrib1fDelegate(GLuint index, GLfloat x);
        private static glVertexAttrib1fDelegate glVertexAttrib1f = null;
        public static void VertexAttrib1(int index, float x)
        {
            glVertexAttrib1f((GLuint)index, x);
        }
        #endregion
        #region glVertexAttrib1fv
        private unsafe delegate void glVertexAttrib1fvDelegate(GLuint index, GLfloat* v);
        private static glVertexAttrib1fvDelegate glVertexAttrib1fv = null;
        public static void VertexAttrib1(int index, ref float v)
        {
            unsafe
            {
                fixed (float* v_ptr = &v)
                {
                    glVertexAttrib1fv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttrib1s
        private delegate void glVertexAttrib1sDelegate(GLuint index, GLshort x);
        private static glVertexAttrib1sDelegate glVertexAttrib1s = null;
        public static void VertexAttrib1(int index, short x)
        {
            glVertexAttrib1s((GLuint)index, x);
        }
        #endregion
        #region glVertexAttrib1sv
        private unsafe delegate void glVertexAttrib1svDelegate(GLuint index, GLshort* v);
        private static glVertexAttrib1svDelegate glVertexAttrib1sv = null;
        public static void VertexAttrib1(int index, ref short v)
        {
            unsafe
            {
                fixed (short* v_ptr = &v)
                {
                    glVertexAttrib1sv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttrib2d
        private delegate void glVertexAttrib2dDelegate(GLuint index, GLdouble x, GLdouble y);
        private static glVertexAttrib2dDelegate glVertexAttrib2d = null;
        public static void VertexAttrib2(int index, double x, double y)
        {
            glVertexAttrib2d((GLuint)index, x, y);
        }
        #endregion
        #region glVertexAttrib2dv
        private unsafe delegate void glVertexAttrib2dvDelegate(GLuint index, GLdouble* v);
        private static glVertexAttrib2dvDelegate glVertexAttrib2dv = null;
        public static void VertexAttrib2(int index, double[] v)
        {
            unsafe
            {
                fixed (double* v_ptr = v)
                {
                    glVertexAttrib2dv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttrib2f
        private delegate void glVertexAttrib2fDelegate(GLuint index, GLfloat x, GLfloat y);
        private static glVertexAttrib2fDelegate glVertexAttrib2f = null;
        public static void VertexAttrib2(int index, float x, float y)
        {
            glVertexAttrib2f((GLuint)index, x, y);
        }
        #endregion
        #region glVertexAttrib2fv
        private unsafe delegate void glVertexAttrib2fvDelegate(GLuint index, GLfloat* v);
        private static glVertexAttrib2fvDelegate glVertexAttrib2fv = null;
        public static void VertexAttrib2(int index, float[] v)
        {
            unsafe
            {
                fixed (float* v_ptr = v)
                {
                    glVertexAttrib2fv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttrib2s
        private delegate void glVertexAttrib2sDelegate(GLuint index, GLshort x, GLshort y);
        private static glVertexAttrib2sDelegate glVertexAttrib2s = null;
        public static void VertexAttrib2(int index, short x, short y)
        {
            glVertexAttrib2s((GLuint)index, x, y);
        }
        #endregion
        #region glVertexAttrib2sv
        private unsafe delegate void glVertexAttrib2svDelegate(GLuint index, GLshort* v);
        private static glVertexAttrib2svDelegate glVertexAttrib2sv = null;
        public static void VertexAttrib2(int index, short[] v)
        {
            unsafe
            {
                fixed (short* v_ptr = v)
                {
                    glVertexAttrib2sv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttrib3d
        private delegate void glVertexAttrib3dDelegate(GLuint index, GLdouble x, GLdouble y, GLdouble z);
        private static glVertexAttrib3dDelegate glVertexAttrib3d = null;
        public static void VertexAttrib3(int index, double x, double y, double z)
        {
            glVertexAttrib3d((GLuint)index, x, y, z);
        }
        #endregion
        #region glVertexAttrib3dv
        private unsafe delegate void glVertexAttrib3dvDelegate(GLuint index, GLdouble* v);
        private static glVertexAttrib3dvDelegate glVertexAttrib3dv = null;
        public static void VertexAttrib3(int index, double[] v)
        {
            unsafe
            {
                fixed (double* v_ptr = v)
                {
                    glVertexAttrib3dv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttrib3f
        private delegate void glVertexAttrib3fDelegate(GLuint index, GLfloat x, GLfloat y, GLfloat z);
        private static glVertexAttrib3fDelegate glVertexAttrib3f = null;
        public static void VertexAttrib3(int index, float x, float y, float z)
        {
            glVertexAttrib3f((GLuint)index, x, y, z);
        }
        #endregion
        #region glVertexAttrib3fv
        private unsafe delegate void glVertexAttrib3fvDelegate(GLuint index, GLfloat* v);
        private static glVertexAttrib3fvDelegate glVertexAttrib3fv = null;
        public static void VertexAttrib3(int index, float[] v)
        {
            unsafe
            {
                fixed (float* v_ptr = v)
                {
                    glVertexAttrib3fv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttrib3s
        private delegate void glVertexAttrib3sDelegate(GLuint index, GLshort x, GLshort y, GLshort z);
        private static glVertexAttrib3sDelegate glVertexAttrib3s = null;
        public static void VertexAttrib3(int index, short x, short y, short z)
        {
            glVertexAttrib3s((GLuint)index, x, y, z);
        }
        #endregion
        #region glVertexAttrib3sv
        private unsafe delegate void glVertexAttrib3svDelegate(GLuint index, GLshort* v);
        private static glVertexAttrib3svDelegate glVertexAttrib3sv = null;
        public static void VertexAttrib3(int index, short[] v)
        {
            unsafe
            {
                fixed (short* v_ptr = v)
                {
                    glVertexAttrib3sv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttrib4Nbv
        private unsafe delegate void glVertexAttrib4NbvDelegate(GLuint index, GLbyte* v);
        private static glVertexAttrib4NbvDelegate glVertexAttrib4Nbv = null;
        public static void VertexAttrib4N(int index, sbyte[] v)
        {
            unsafe
            {
                fixed (sbyte* v_ptr = v)
                {
                    glVertexAttrib4Nbv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttrib4Niv
        private unsafe delegate void glVertexAttrib4NivDelegate(GLuint index, GLint* v);
        private static glVertexAttrib4NivDelegate glVertexAttrib4Niv = null;
        public static void VertexAttrib4N(int index, int[] v)
        {
            unsafe
            {
                fixed (int* v_ptr = v)
                {
                    glVertexAttrib4Niv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttrib4Nsv
        private unsafe delegate void glVertexAttrib4NsvDelegate(GLuint index, GLshort* v);
        private static glVertexAttrib4NsvDelegate glVertexAttrib4Nsv = null;
        public static void VertexAttrib4N(int index, short[] v)
        {
            unsafe
            {
                fixed (short* v_ptr = v)
                {
                    glVertexAttrib4Nsv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttrib4Nub
        private delegate void glVertexAttrib4NubDelegate(GLuint index, GLubyte x, GLubyte y, GLubyte z, GLubyte w);
        private static glVertexAttrib4NubDelegate glVertexAttrib4Nub = null;
        public static void VertexAttrib4N(int index, byte x, byte y, byte z, byte w)
        {
            glVertexAttrib4Nub((GLuint)index, x, y, z, w);
        }
        #endregion
        #region glVertexAttrib4Nubv
        private unsafe delegate void glVertexAttrib4NubvDelegate(GLuint index, GLubyte* v);
        private static glVertexAttrib4NubvDelegate glVertexAttrib4Nubv = null;
        public static void VertexAttrib4N(int index, byte[] v)
        {
            unsafe
            {
                fixed (byte* v_ptr = v)
                {
                    glVertexAttrib4Nubv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttrib4Nuiv
        private unsafe delegate void glVertexAttrib4NuivDelegate(GLuint index, GLuint* v);
        private static glVertexAttrib4NuivDelegate glVertexAttrib4Nuiv = null;
        public static void VertexAttrib4N(int index, uint[] v)
        {
            unsafe
            {
                fixed (uint* v_ptr = v)
                {
                    glVertexAttrib4Nuiv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttrib4Nusv
        private unsafe delegate void glVertexAttrib4NusvDelegate(GLuint index, GLushort* v);
        private static glVertexAttrib4NusvDelegate glVertexAttrib4Nusv = null;
        public static void VertexAttrib4N(int index, ushort[] v)
        {
            unsafe
            {
                fixed (ushort* v_ptr = v)
                {
                    glVertexAttrib4Nusv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttrib4bv
        private unsafe delegate void glVertexAttrib4bvDelegate(GLuint index, GLbyte* v);
        private static glVertexAttrib4bvDelegate glVertexAttrib4bv = null;
        public static void VertexAttrib4(int index, sbyte[] v)
        {
            unsafe
            {
                fixed (sbyte* v_ptr = v)
                {
                    glVertexAttrib4bv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttrib4d
        private delegate void glVertexAttrib4dDelegate(GLuint index, GLdouble x, GLdouble y, GLdouble z, GLdouble w);
        private static glVertexAttrib4dDelegate glVertexAttrib4d = null;
        public static void VertexAttrib4(int index, double x, double y, double z, double w)
        {
            glVertexAttrib4d((GLuint)index, x, y, z, w);
        }
        #endregion
        #region glVertexAttrib4dv
        private unsafe delegate void glVertexAttrib4dvDelegate(GLuint index, GLdouble* v);
        private static glVertexAttrib4dvDelegate glVertexAttrib4dv = null;
        public static void VertexAttrib4(int index, double[] v)
        {
            unsafe
            {
                fixed (double* v_ptr = v)
                {
                    glVertexAttrib4dv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttrib4f
        private delegate void glVertexAttrib4fDelegate(GLuint index, GLfloat x, GLfloat y, GLfloat z, GLfloat w);
        private static glVertexAttrib4fDelegate glVertexAttrib4f = null;
        public static void VertexAttrib4(int index, float x, float y, float z, float w)
        {
            glVertexAttrib4f((GLuint)index, x, y, z, w);
        }
        #endregion
        #region glVertexAttrib4fv
        private unsafe delegate void glVertexAttrib4fvDelegate(GLuint index, GLfloat* v);
        private static glVertexAttrib4fvDelegate glVertexAttrib4fv = null;
        public static void VertexAttrib4(int index, float[] v)
        {
            unsafe
            {
                fixed (float* v_ptr = v)
                {
                    glVertexAttrib4fv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttrib4iv
        private unsafe delegate void glVertexAttrib4ivDelegate(GLuint index, GLint* v);
        private static glVertexAttrib4ivDelegate glVertexAttrib4iv = null;
        public static void VertexAttrib4(int index, int[] v)
        {
            unsafe
            {
                fixed (int* v_ptr = v)
                {
                    glVertexAttrib4iv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttrib4s
        private delegate void glVertexAttrib4sDelegate(GLuint index, GLshort x, GLshort y, GLshort z, GLshort w);
        private static glVertexAttrib4sDelegate glVertexAttrib4s = null;
        public static void VertexAttrib4(int index, short x, short y, short z, short w)
        {
            glVertexAttrib4s((GLuint)index, x, y, z, w);
        }
        #endregion
        #region glVertexAttrib4sv
        private unsafe delegate void glVertexAttrib4svDelegate(GLuint index, GLshort* v);
        private static glVertexAttrib4svDelegate glVertexAttrib4sv = null;
        public static void VertexAttrib4(int index, short[] v)
        {
            unsafe
            {
                fixed (short* v_ptr = v)
                {
                    glVertexAttrib4sv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttrib4ubv
        private unsafe delegate void glVertexAttrib4ubvDelegate(GLuint index, GLubyte* v);
        private static glVertexAttrib4ubvDelegate glVertexAttrib4ubv = null;
        public static void VertexAttrib4(int index, byte[] v)
        {
            unsafe
            {
                fixed (byte* v_ptr = v)
                {
                    glVertexAttrib4ubv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttrib4uiv
        private unsafe delegate void glVertexAttrib4uivDelegate(GLuint index, GLuint* v);
        private static glVertexAttrib4uivDelegate glVertexAttrib4uiv = null;
        public static void VertexAttrib4(int index, uint[] v)
        {
            unsafe
            {
                fixed (uint* v_ptr = v)
                {
                    glVertexAttrib4uiv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttrib4usv
        private unsafe delegate void glVertexAttrib4usvDelegate(GLuint index, GLushort* v);
        private static glVertexAttrib4usvDelegate glVertexAttrib4usv = null;
        public static void VertexAttrib4(int index, ushort[] v)
        {
            unsafe
            {
                fixed (ushort* v_ptr = v)
                {
                    glVertexAttrib4usv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttribPointer
        private delegate void glVertexAttribPointerDelegate(GLuint index, GLint size, GLenum type, GLboolean normalized, GLsizei stride, IntPtr pointer);
        private static glVertexAttribPointerDelegate glVertexAttribPointer = null;
        public static void VertexAttribPointer(int index, int size, VertexAttribType type, bool normalized, int stride, IntPtr pointer)
        {
            glVertexAttribPointer((uint)index, size, (GLenum)type, normalized, stride, pointer);
        }
        public static void VertexAttribPointer(int index, int size, VertexAttribType type, bool normalized, int stride, int offset)
        {
            glVertexAttribPointer((uint)index, size, (GLenum)type, normalized, stride, (IntPtr)offset);
        }
        #endregion
        #endregion
        #region OPENGL 2.1
        #region glUniformMatrix2x3fv
        private unsafe delegate void glUniformMatrix2x3fvDelegate(GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
        private static glUniformMatrix2x3fvDelegate glUniformMatrix2x3fv = null;
        public static void UniformMatrix2x3(int location, int count, bool transpose, float[] value)
        {
            unsafe
            {
                fixed (float* value_ptr = value)
                {
                    glUniformMatrix2x3fv(location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glUniformMatrix3x2fv
        private unsafe delegate void glUniformMatrix3x2fvDelegate(GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
        private static glUniformMatrix3x2fvDelegate glUniformMatrix3x2fv = null;
        public static void UniformMatrix3x2(int location, int count, bool transpose, float[] value)
        {
            unsafe
            {
                fixed (float* value_ptr = value)
                {
                    glUniformMatrix3x2fv(location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glUniformMatrix2x4fv
        private unsafe delegate void glUniformMatrix2x4fvDelegate(GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
        private static glUniformMatrix2x4fvDelegate glUniformMatrix2x4fv = null;
        public static void UniformMatrix2x4(int location, int count, bool transpose, float[] value)
        {
            unsafe
            {
                fixed (float* value_ptr = value)
                {
                    glUniformMatrix2x4fv(location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glUniformMatrix4x2fv
        private unsafe delegate void glUniformMatrix4x2fvDelegate(GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
        private static glUniformMatrix4x2fvDelegate glUniformMatrix4x2fv = null;
        public static void UniformMatrix4x2(int location, int count, bool transpose, float[] value)
        {
            unsafe
            {
                fixed (float* value_ptr = value)
                {
                    glUniformMatrix4x2fv(location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glUniformMatrix3x4fv
        private unsafe delegate void glUniformMatrix3x4fvDelegate(GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
        private static glUniformMatrix3x4fvDelegate glUniformMatrix3x4fv = null;
        public static void UniformMatrix3x4(int location, int count, bool transpose, float[] value)
        {
            unsafe
            {
                fixed (float* value_ptr = value)
                {
                    glUniformMatrix3x4fv(location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glUniformMatrix4x3fv
        private unsafe delegate void glUniformMatrix4x3fvDelegate(GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
        private static glUniformMatrix4x3fvDelegate glUniformMatrix4x3fv = null;
        public static void UniformMatrix4x3(int location, int count, bool transpose, float[] value)
        {
            unsafe
            {
                fixed (float* value_ptr = value)
                {
                    glUniformMatrix4x3fv(location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #endregion
        #region OPENGL 3.0
        #region glColorMaski
        private delegate void glColorMaskiDelegate(GLuint index, GLboolean r, GLboolean g, GLboolean b, GLboolean a);
        private static glColorMaskiDelegate glColorMaski = null;
        public static void ColorMark(int index, bool r, bool g, bool b, bool a)
        {
            glColorMaski((GLuint)index, r, g, b, a);
        }
        #endregion
        #region glGetBooleani_v
        private unsafe delegate void glGetBooleani_vDelegate(GLenum target, GLuint index, GLboolean* data);
        private static glGetBooleani_vDelegate glGetBooleani_v = null;
        public static void GetBoolean(IndexedParamName target, int index, out bool data)
        {
            unsafe
            {
                fixed (bool* data_ptr = &data)
                {
                    glGetBooleani_v((GLenum)target, (GLuint)index, data_ptr);
                }
            }
        }
        public static void GetBoolean(IndexedParamName target, int index, [Out] bool[] data)
        {
            unsafe
            {
                fixed (bool* data_ptr = data)
                {
                    glGetBooleani_v((GLenum)target, (GLuint)index, data_ptr);
                }
            }
        }
        #endregion
        #region glGetIntegeri_v
        private unsafe delegate void glGetIntegeri_vDelegate(GLenum target, GLuint index, GLint* data);
        private static glGetIntegeri_vDelegate glGetIntegeri_v = null;
        public static void GetInteger(IndexedParamName target, int index, out int data)
        {
            unsafe
            {
                fixed (int* data_ptr = &data)
                {
                    glGetIntegeri_v((GLenum)target, (GLuint)index, data_ptr);
                }
            }
        }
        public static void GetInteger(IndexedParamName target, int index, [Out] int[] data)
        {
            unsafe
            {
                fixed (int* data_ptr = data)
                {
                    glGetIntegeri_v((GLenum)target, (GLuint)index, data_ptr);
                }
            }
        }
        #endregion
        #region glEnablei
        private delegate void glEnableiDelegate(GLenum target, GLuint index);
        private static glEnableiDelegate glEnablei = null;
        public static void Enable(IndexedParamName target, int index)
        {
            glEnablei((GLenum)target, (GLuint)index);
        }
        #endregion
        #region glDisablei
        private delegate void glDisableiDelegate(GLenum target, GLuint index);
        private static glDisableiDelegate glDisablei = null;
        public static void Disable(IndexedParamName target, int index)
        {
            glDisablei((GLenum)target, (GLuint)index);
        }
        #endregion
        #region glIsEnabledi
        private delegate GLboolean glIsEnablediDelegate(GLenum target, GLuint index);
        private static glIsEnablediDelegate glIsEnabledi = null;
        public static bool IsEnabled(IndexedParamName target, int index)
        {
            return glIsEnabledi((GLenum)target, (GLuint)index);
        }
        #endregion
        #region glBeginTransformFeedback
        private delegate void glBeginTransformFeedbackDelegate(GLenum primitiveMode);
        private static glBeginTransformFeedbackDelegate glBeginTransformFeedback = null;
        public static void BeginTransformFeedback(BeginFeedbackMode primitiveMode)
        {
            glBeginTransformFeedback((GLenum)primitiveMode);
        }
        public static void BeginTransformFeedback(DrawMode primitiveMode)
        {
            glBeginTransformFeedback((GLenum)primitiveMode);
        }
        #endregion
        #region glEndTransformFeedback
        private delegate void glEndTransformFeedbackDelegate();
        private static glEndTransformFeedbackDelegate glEndTransformFeedback = null;
        public static void EndTransformFeedback()
        {
            glEndTransformFeedback();
        }
        #endregion
        #region glBindBufferRange
        private delegate void glBindBufferRangeDelegate(GLenum target, GLuint index, GLuint buffer, GLintptr offset, GLsizeiptr size);
        private static glBindBufferRangeDelegate glBindBufferRange = null;
        public static void BindBufferRange(BufferTarget target, int index, int buffer, IntPtr offset, IntPtr size)
        {
            glBindBufferRange((GLenum)target, (GLuint)index, (GLuint)buffer, offset, size);
        }
        #endregion
        #region glBindBufferBase
        private delegate void glBindBufferBaseDelegate(GLenum target, GLuint index, GLuint buffer);
        private static glBindBufferBaseDelegate glBindBufferBase = null;
        public static void BindBufferBase(BufferTarget target, int index, int buffer)
        {
            glBindBufferBase((GLenum)target, (GLuint)index, (GLuint)buffer);
        }
        #endregion
        #region glTransformFeedbackVaryings
        private delegate void glTransformFeedbackVaryingsDelegate(GLuint program, GLsizei count, string[] varyings, GLenum bufferMode);
        private static glTransformFeedbackVaryingsDelegate glTransformFeedbackVaryings = null;
        public static void TransformFeedbackVaryings(int program, int count, string[] varyings, TransformFeedbackMode bufferMode)
        {
            glTransformFeedbackVaryings((GLuint)program, count, varyings, (GLenum)bufferMode);
        }
        #endregion
        #region glGetTransformFeedbackVarying
        private unsafe delegate void glGetTransformFeedbackVaryingDelegate(GLuint program, GLuint index, GLsizei bufSize, GLsizei* length, GLsizei* size, GLenum* type, StringBuilder name);
        private static glGetTransformFeedbackVaryingDelegate glGetTransformFeedbackVarying = null;
        public static void GetTransformFeedbackVarying(int program, int index, int bufSize, out int length, out int size, out ActiveAttribType type, StringBuilder name)
        {
            unsafe
            {
                fixed (int* length_ptr = &length, size_ptr = &size)
                fixed (ActiveAttribType* type_ptr = &type)
                {
                    glGetTransformFeedbackVarying((GLuint)program, (GLuint)index, bufSize, length_ptr, size_ptr, (GLenum*)type_ptr, name);
                }
            }
        }
        #endregion
        #region glClampColor
        private delegate void glClampColorDelegate(GLenum target, GLenum clamp);
        private static glClampColorDelegate glClampColor = null;
        public static void ClampColor(ClampColorTarget target, ClampColorMode clamp)
        {
            glClampColor((GLenum)target, (GLenum)clamp);
        }
        #endregion
        #region glBeginConditionalRender
        private delegate void glBeginConditionalRenderDelegate(GLuint id, GLenum mode);
        private static glBeginConditionalRenderDelegate glBeginConditionalRender = null;
        public static void BeginConditionalRender(int id, ConditionalRenderMode mode)
        {
            glBeginConditionalRender((GLuint)id, (GLenum)mode);
        }
        #endregion
        #region glEndConditionalRender
        private delegate void glEndConditionalRenderDelegate();
        private static glEndConditionalRenderDelegate glEndConditionalRender = null;
        public static void EndConditionalRender()
        {
            glEndConditionalRender();
        }
        #endregion
        #region glVertexAttribIPointer
        private delegate void glVertexAttribIPointerDelegate(GLuint index, GLint size, GLenum type, GLsizei stride, IntPtr pointer);
        private static glVertexAttribIPointerDelegate glVertexAttribIPointer = null;
        public static void VertexAttribIPointer(int index, int size, VertexAttribType type, int stride, IntPtr pointer)
        {
            glVertexAttribIPointer((GLuint)index, size, (GLenum)type, stride, pointer);
        }
        #endregion
        #region glGetVertexAttribIiv
        private unsafe delegate void glGetVertexAttribIivDelegate(GLuint index, GLenum pname, GLint* param);
        private static glGetVertexAttribIivDelegate glGetVertexAttribIiv = null;
        public static void GetVertexAttribI(int index, VertexAttribParamName pname, out int param)
        {
            unsafe
            {
                fixed (int* param_ptr = &param)
                {
                    glGetVertexAttribIiv((GLuint)index, (GLenum)pname, param_ptr);
                }
            }
        }
        public static void GetVertexAttribI(int index, VertexAttribParamName pname, [Out] int[] param)
        {
            unsafe
            {
                fixed (int* param_ptr = param)
                {
                    glGetVertexAttribIiv((GLuint)index, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glGetVertexAttribIuiv
        private unsafe delegate void glGetVertexAttribIuivDelegate(GLuint index, GLenum pname, GLuint* param);
        private static glGetVertexAttribIuivDelegate glGetVertexAttribIuiv = null;
        public static void GetVertexAttribI(int index, VertexAttribParamName pname, out uint param)
        {
            unsafe
            {
                fixed (uint* param_ptr = &param)
                {
                    glGetVertexAttribIuiv((GLuint)index, (GLenum)pname, param_ptr);
                }
            }
        }
        public static void GetVertexAttribI(int index, VertexAttribParamName pname, [Out] uint[] param)
        {
            unsafe
            {
                fixed (uint* param_ptr = param)
                {
                    glGetVertexAttribIuiv((GLuint)index, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttribI1i
        private delegate void glVertexAttribI1iDelegate(GLuint index, GLint x);
        private static glVertexAttribI1iDelegate glVertexAttribI1i = null;
        public static void VertexAttribI(int index, int x)
        {
            glVertexAttribI1i((GLuint)index, x);
        }
        #endregion
        #region glVertexAttribI2i
        private delegate void glVertexAttribI2iDelegate(GLuint index, GLint x, GLint y);
        private static glVertexAttribI2iDelegate glVertexAttribI2i = null;
        public static void VertexAttribI(int index, int x, int y)
        {
            glVertexAttribI2i((GLuint)index, x, y);
        }
        #endregion
        #region glVertexAttribI3i
        private delegate void glVertexAttribI3iDelegate(GLuint index, GLint x, GLint y, GLint z);
        private static glVertexAttribI3iDelegate glVertexAttribI3i = null;
        public static void VertexAttribI(int index, int x, int y, int z)
        {
            glVertexAttribI3i((GLuint)index, x, y, z);
        }
        #endregion
        #region glVertexAttribI4i
        private delegate void glVertexAttribI4iDelegate(GLuint index, GLint x, GLint y, GLint z, GLint w);
        private static glVertexAttribI4iDelegate glVertexAttribI4i = null;
        public static void VertexAttribI(int index, int x, int y, int z, int w)
        {
            glVertexAttribI4i((GLuint)index, x, y, z, w);
        }
        #endregion
        #region glVertexAttribI1ui
        private delegate void glVertexAttribI1uiDelegate(GLuint index, GLuint x);
        private static glVertexAttribI1uiDelegate glVertexAttribI1ui = null;
        public static void VertexAttribI(int index, uint x)
        {
            glVertexAttribI1ui((GLuint)index, x);
        }
        #endregion
        #region glVertexAttribI2ui
        private delegate void glVertexAttribI2uiDelegate(GLuint index, GLuint x, GLuint y);
        private static glVertexAttribI2uiDelegate glVertexAttribI2ui = null;
        public static void VertexAttribI(int index, uint x, uint y)
        {
            glVertexAttribI2ui((GLuint)index, x, y);
        }
        #endregion
        #region glVertexAttribI3ui
        private delegate void glVertexAttribI3uiDelegate(GLuint index, GLuint x, GLuint y, GLuint z);
        private static glVertexAttribI3uiDelegate glVertexAttribI3ui = null;
        public static void VertexAttribI(int index, uint x, uint y, uint z)
        {
            glVertexAttribI3ui((GLuint)index, x, y, z);
        }
        #endregion
        #region glVertexAttribI4ui
        private delegate void glVertexAttribI4uiDelegate(GLuint index, GLuint x, GLuint y, GLuint z, GLuint w);
        private static glVertexAttribI4uiDelegate glVertexAttribI4ui = null;
        public static void VertexAttribI(int index, uint x, uint y, uint z, uint w)
        {
            glVertexAttribI4ui((GLuint)index, x, y, z, w);
        }
        #endregion
        #region glVertexAttribI1iv
        private unsafe delegate void glVertexAttribI1ivDelegate(GLuint index, GLint* v);
        private static glVertexAttribI1ivDelegate glVertexAttribI1iv = null;
        public static void VertexAttribI1(int index, ref int v)
        {
            unsafe
            {
                fixed (int* v_ptr = &v)
                {
                    glVertexAttribI1iv((GLuint)index, v_ptr);
                }
            }
        }
        public static void VertexAttribI1(int index, int[] v)
        {
            unsafe
            {
                fixed (int* v_ptr = v)
                {
                    glVertexAttribI1iv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttribI2iv
        private unsafe delegate void glVertexAttribI2ivDelegate(GLuint index, GLint* v);
        private static glVertexAttribI2ivDelegate glVertexAttribI2iv = null;
        public static void VertexAttribI2(int index, int[] v)
        {
            unsafe
            {
                fixed (int* v_ptr = v)
                {
                    glVertexAttribI2iv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttribI3iv
        private unsafe delegate void glVertexAttribI3ivDelegate(GLuint index, GLint* v);
        private static glVertexAttribI3ivDelegate glVertexAttribI3iv = null;
        public static void VertexAttribI3(int index, int[] v)
        {
            unsafe
            {
                fixed (int* v_ptr = v)
                {
                    glVertexAttribI3iv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttribI4iv
        private unsafe delegate void glVertexAttribI4ivDelegate(GLuint index, GLint* v);
        private static glVertexAttribI4ivDelegate glVertexAttribI4iv = null;
        public static void VertexAttribI4(int index, int[] v)
        {
            unsafe
            {
                fixed (int* v_ptr = v)
                {
                    glVertexAttribI4iv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttribI1uiv
        private unsafe delegate void glVertexAttribI1uivDelegate(GLuint index, GLuint* v);
        private static glVertexAttribI1uivDelegate glVertexAttribI1uiv = null;
        public static void VertexAttribI1(int index, ref uint v)
        {
            unsafe
            {
                fixed (uint* v_ptr = &v)
                {
                    glVertexAttribI1uiv((GLuint)index, v_ptr);
                }
            }
        }
        public static void VertexAttribI1(int index, uint[] v)
        {
            unsafe
            {
                fixed (uint* v_ptr = v)
                {
                    glVertexAttribI1uiv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttribI2uiv
        private unsafe delegate void glVertexAttribI2uivDelegate(GLuint index, GLuint* v);
        private static glVertexAttribI2uivDelegate glVertexAttribI2uiv = null;
        public static void VertexAttribI2(int index, uint[] v)
        {
            unsafe
            {
                fixed (uint* v_ptr = v)
                {
                    glVertexAttribI2uiv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttribI3uiv
        private unsafe delegate void glVertexAttribI3uivDelegate(GLuint index, GLuint* v);
        private static glVertexAttribI3uivDelegate glVertexAttribI3uiv = null;
        public static void VertexAttribI3(int index, uint[] v)
        {
            unsafe
            {
                fixed (uint* v_ptr = v)
                {
                    glVertexAttribI3uiv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttribI4uiv
        private unsafe delegate void glVertexAttribI4uivDelegate(GLuint index, GLuint* v);
        private static glVertexAttribI4uivDelegate glVertexAttribI4uiv = null;
        public static void VertexAttribI4(int index, uint[] v)
        {
            unsafe
            {
                fixed (uint* v_ptr = v)
                {
                    glVertexAttribI4uiv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttribI4bv
        private unsafe delegate void glVertexAttribI4bvDelegate(GLuint index, GLbyte* v);
        private static glVertexAttribI4bvDelegate glVertexAttribI4bv = null;
        public static void VertexAttribI4(int index, sbyte[] v)
        {
            unsafe
            {
                fixed (sbyte* v_ptr = v)
                {
                    glVertexAttribI4bv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttribI4sv
        private unsafe delegate void glVertexAttribI4svDelegate(GLuint index, GLshort* v);
        private static glVertexAttribI4svDelegate glVertexAttribI4sv = null;
        public static void VertexAttribI4(int index, short[] v)
        {
            unsafe
            {
                fixed (short* v_ptr = v)
                {
                    glVertexAttribI4sv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttribI4ubv
        private unsafe delegate void glVertexAttribI4ubvDelegate(GLuint index, GLubyte* v);
        private static glVertexAttribI4ubvDelegate glVertexAttribI4ubv = null;
        public static void VertexAttribI4(int index, byte[] v)
        {
            unsafe
            {
                fixed (byte* v_ptr = v)
                {
                    glVertexAttribI4ubv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttribI4usv
        private unsafe delegate void glVertexAttribI4usvDelegate(GLuint index, GLushort* v);
        private static glVertexAttribI4usvDelegate glVertexAttribI4usv = null;
        public static void VertexAttribI4(int index, ushort[] v)
        {
            unsafe
            {
                fixed (ushort* v_ptr = v)
                {
                    glVertexAttribI4usv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glGetUniformuiv
        private unsafe delegate void glGetUniformuivDelegate(GLuint program, GLint location, GLuint* param);
        private static glGetUniformuivDelegate glGetUniformuiv = null;
        public static void GetUniform(int program, int location, out uint param)
        {
            unsafe
            {
                fixed (uint* param_ptr = &param)
                {
                    glGetUniformuiv((GLuint)program, location, param_ptr);
                }
            }
        }
        public static void GetUniform(int program, int location, [Out] uint[] param)
        {
            unsafe
            {
                fixed (uint* param_ptr = param)
                {
                    glGetUniformuiv((GLuint)program, location, param_ptr);
                }
            }
        }
        #endregion
        #region glBindFragDataLocation
        private delegate void glBindFragDataLocationDelegate(GLuint program, GLuint color, string name);
        private static glBindFragDataLocationDelegate glBindFragDataLocation = null;
        public static void BindFragDataLocation(int program, uint color, string name)
        {
            glBindFragDataLocation((GLuint)program, color, name);
        }
        #endregion
        #region glGetFragDataLocation
        private delegate GLint glGetFragDataLocationDelegate(GLuint program, string name);
        private static glGetFragDataLocationDelegate glGetFragDataLocation = null;
        public static int GetFragDataLocation(int program, string name)
        {
            return glGetFragDataLocation((GLuint)program, name);
        }
        #endregion
        #region glUniform1ui
        private delegate void glUniform1uiDelegate(GLint location, GLuint v0);
        private static glUniform1uiDelegate glUniform1ui = null;
        public static void Uniform1(int location, uint v0)
        {
            glUniform1ui(location, v0);
        }
        #endregion
        #region glUniform2ui
        private delegate void glUniform2uiDelegate(GLint location, GLuint v0, GLuint v1);
        private static glUniform2uiDelegate glUniform2ui = null;
        public static void Uniform2(int location, uint v0, uint v1)
        {
            glUniform2ui(location, v0, v1);
        }
        #endregion
        #region glUniform3ui
        private delegate void glUniform3uiDelegate(GLint location, GLuint v0, GLuint v1, GLuint v2);
        private static glUniform3uiDelegate glUniform3ui = null;
        public static void Uniform3(int location, uint v0, uint v1, uint v2)
        {
            glUniform3ui(location, v0, v1, v2);
        }
        #endregion
        #region glUniform4ui
        private delegate void glUniform4uiDelegate(GLint location, GLuint v0, GLuint v1, GLuint v2, GLuint v3);
        private static glUniform4uiDelegate glUniform4ui = null;
        public static void Uniform4(int location, uint v0, uint v1, uint v2, uint v3)
        {
            glUniform4ui(location, v0, v1, v2, v3);
        }
        #endregion
        #region glUniform1uiv
        private unsafe delegate void glUniform1uivDelegate(GLint location, GLsizei count, GLuint* value);
        private static glUniform1uivDelegate glUniform1uiv = null;
        public static void Uniform1(int location, int count, uint[] value)
        {
            unsafe
            {
                fixed (uint* value_ptr = value)
                {
                    glUniform1uiv(location, count, value_ptr);
                }
            }
        }
        #endregion
        #region glUniform2uiv
        private unsafe delegate void glUniform2uivDelegate(GLint location, GLsizei count, GLuint* value);
        private static glUniform2uivDelegate glUniform2uiv = null;
        public static void Uniform2(int location, int count, uint[] value)
        {
            unsafe
            {
                fixed (uint* value_ptr = value)
                {
                    glUniform2uiv(location, count, value_ptr);
                }
            }
        }
        #endregion
        #region glUniform3uiv
        private unsafe delegate void glUniform3uivDelegate(GLint location, GLsizei count, GLuint* value);
        private static glUniform3uivDelegate glUniform3uiv = null;
        public static void Uniform3(int location, int count, uint[] value)
        {
            unsafe
            {
                fixed (uint* value_ptr = value)
                {
                    glUniform3uiv(location, count, value_ptr);
                }
            }
        }
        #endregion
        #region glUniform4uiv
        private unsafe delegate void glUniform4uivDelegate(GLint location, GLsizei count, GLuint* value);
        private static glUniform4uivDelegate glUniform4uiv = null;
        public static void Uniform4(int location, int count, uint[] value)
        {
            unsafe
            {
                fixed (uint* value_ptr = value)
                {
                    glUniform4uiv(location, count, value_ptr);
                }
            }
        }
        #endregion
        #region glTexParameterIiv
        private unsafe delegate void glTexParameterIivDelegate(GLenum target, GLenum pname, GLint* param);
        private static glTexParameterIivDelegate glTexParameterIiv = null;
        public static void TexParameterI(TextureTarget target, TextureParamName pname, ref int param)
        {
            unsafe
            {
                fixed (int* param_ptr = &param)
                {
                    glTexParameterIiv((GLenum)target, (GLenum)pname, param_ptr);
                }
            }
        }
        public static void TexParameterI(TextureTarget target, TextureParamName pname, int[] param)
        {
            unsafe
            {
                fixed (int* param_ptr = param)
                {
                    glTexParameterIiv((GLenum)target, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glTexParameterIuiv
        private unsafe delegate void glTexParameterIuivDelegate(GLenum target, GLenum pname, GLuint* param);
        private static glTexParameterIuivDelegate glTexParameterIuiv = null;
        public static void TexParameterI(TextureTarget target, TextureParamName pname, ref uint param)
        {
            unsafe
            {
                fixed (uint* param_ptr = &param)
                {
                    glTexParameterIuiv((GLenum)target, (GLenum)pname, param_ptr);
                }
            }
        }
        public static void TexParameterI(TextureTarget target, TextureParamName pname, uint[] param)
        {
            unsafe
            {
                fixed (uint* param_ptr = param)
                {
                    glTexParameterIuiv((GLenum)target, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glGetTexParameterIiv
        private unsafe delegate void glGetTexParameterIivDelegate(GLenum target, GLenum pname, GLint* param);
        private static glGetTexParameterIivDelegate glGetTexParameterIiv = null;
        public static void GetTexParameterI(TextureTarget target, TextureParamName pname, out int param)
        {
            unsafe
            {
                fixed (int* param_ptr = &param)
                {
                    glGetTexParameterIiv((GLenum)target, (GLenum)pname, param_ptr);
                }
            }
        }
        public static void GetTexParameterI(TextureTarget target, TextureParamName pname, [Out] int[] param)
        {
            unsafe
            {
                fixed (int* param_ptr = param)
                {
                    glGetTexParameterIiv((GLenum)target, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glGetTexParameterIuiv
        private unsafe delegate void glGetTexParameterIuivDelegate(GLenum target, GLenum pname, GLuint* param);
        private static glGetTexParameterIuivDelegate glGetTexParameterIuiv = null;
        public static void GetTexParameterI(TextureTarget target, TextureParamName pname, out uint param)
        {
            unsafe
            {
                fixed (uint* param_ptr = &param)
                {
                    glGetTexParameterIuiv((GLenum)target, (GLenum)pname, param_ptr);
                }
            }
        }
        public static void GetTexParameterI(TextureTarget target, TextureParamName pname, [Out] uint[] param)
        {
            unsafe
            {
                fixed (uint* param_ptr = param)
                {
                    glGetTexParameterIuiv((GLenum)target, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glClearBufferiv
        private unsafe delegate void glClearBufferivDelegate(GLenum buffer, GLint drawbuffer, GLint* value);
        private static glClearBufferivDelegate glClearBufferiv = null;
        public static void ClearBuffer(ClearBuffer buffer, int drawbuffer, int[] value)
        {
            unsafe
            {
                fixed (int* value_ptr = value)
                {
                    glClearBufferiv((GLenum)buffer, drawbuffer, value_ptr);
                }
            }
        }
        #endregion
        #region glClearBufferuiv
        private unsafe delegate void glClearBufferuivDelegate(GLenum buffer, GLint drawbuffer, GLuint* value);
        private static glClearBufferuivDelegate glClearBufferuiv = null;
        public static void ClearBuffer(ClearBuffer buffer, int drawbuffer, uint[] value)
        {
            unsafe
            {
                fixed (uint* value_ptr = value)
                {
                    glClearBufferuiv((GLenum)buffer, drawbuffer, value_ptr);
                }
            }
        }
        #endregion
        #region glClearBufferfv
        private unsafe delegate void glClearBufferfvDelegate(GLenum buffer, GLint drawbuffer, GLfloat* value);
        private static glClearBufferfvDelegate glClearBufferfv = null;
        public static void ClearBuffer(ClearBuffer buffer, int drawbuffer, float[] value)
        {
            unsafe
            {
                fixed (float* value_ptr = value)
                {
                    glClearBufferfv((GLenum)buffer, drawbuffer, value_ptr);
                }
            }
        }
        #endregion
        #region glClearBufferfi
        private delegate void glClearBufferfiDelegate(GLenum buffer, GLint drawbuffer, GLfloat depth, GLint stencil);
        private static glClearBufferfiDelegate glClearBufferfi = null;
        public static void ClearBuffer(ClearBuffer buffer, int drawbuffer, float depth, int stencil)
        {
            glClearBufferfi((GLenum)buffer, drawbuffer, depth, stencil);
        }
        #endregion
        #region glGetStringi
        private unsafe delegate GLubyte* glGetStringiDelegate(GLenum name, GLuint index);
        private static glGetStringiDelegate glGetStringi = null;
        public static string GetString(StringName name, int index)
        {
            unsafe
            {
                return new string((sbyte*)glGetStringi((GLenum)name, (GLuint)index));
            }
        }
        #endregion
        #region glIsRenderbuffer
        private delegate GLboolean glIsRenderbufferDelegate(GLuint renderbuffer);
        private static glIsRenderbufferDelegate glIsRenderbuffer = null;
        public static bool IsRenderbuffer(int renderbuffer)
        {
            return glIsRenderbuffer((GLuint)renderbuffer);
        }
        #endregion
        #region glBindRenderbuffer
        private delegate void glBindRenderbufferDelegate(GLenum target, GLuint renderbuffer);
        private static glBindRenderbufferDelegate glBindRenderbuffer = null;
        public static void BindRenderbuffer(RenderbufferTarget target, int renderbuffer)
        {
            glBindRenderbuffer((GLenum)target, (GLuint)renderbuffer);
        }
        #endregion
        #region glDeleteRenderbuffers
        private unsafe delegate void glDeleteRenderbuffersDelegate(GLsizei n, GLuint* renderbuffers);
        private static glDeleteRenderbuffersDelegate glDeleteRenderbuffers = null;
        public static void DeleteRenderbuffers(int n, ref int renderbuffers)
        {
            unsafe
            {
                fixed (int* renderbuffers_ptr = &renderbuffers)
                {
                    glDeleteRenderbuffers(n, (GLuint*)renderbuffers_ptr);
                }
            }
        }
        public static void DeleteRenderbuffers(int n, int[] renderbuffers)
        {
            unsafe
            {
                fixed (int* renderbuffers_ptr = renderbuffers)
                {
                    glDeleteRenderbuffers(n, (GLuint*)renderbuffers_ptr);
                }
            }
        }
        #endregion
        #region glGenRenderbuffers
        private unsafe delegate void glGenRenderbuffersDelegate(GLsizei n, GLuint* renderbuffers);
        private static glGenRenderbuffersDelegate glGenRenderbuffers = null;
        public static void GenRenderbuffers(int n, out int renderbuffers)
        {
            unsafe
            {
                fixed (int* renderbuffers_ptr = &renderbuffers)
                {
                    glGenRenderbuffers(n, (GLuint*)renderbuffers_ptr);
                }
            }
        }
        public static void GenRenderbuffers(int n, [Out] int[] renderbuffers)
        {
            unsafe
            {
                fixed (int* renderbuffers_ptr = renderbuffers)
                {
                    glGenRenderbuffers(n, (GLuint*)renderbuffers_ptr);
                }
            }
        }
        #endregion
        #region glRenderbufferStorage
        private delegate void glRenderbufferStorageDelegate(GLenum target, GLenum internalformat, GLsizei width, GLsizei height);
        private static glRenderbufferStorageDelegate glRenderbufferStorage = null;
        public static void RenderbufferStorage(RenderbufferTarget target, PixelInternalFormat internalformat, int width, int height)
        {
            glRenderbufferStorage((GLenum)target, (GLenum)internalformat, width, height);
        }
        #endregion
        #region glGetRenderbufferParameteriv
        private unsafe delegate void glGetRenderbufferParameterivDelegate(GLenum target, GLenum pname, GLint* param);
        private static glGetRenderbufferParameterivDelegate glGetRenderbufferParameteriv = null;
        public static void GetRenderbufferParameter(RenderbufferTarget target, RenderbufferParamName pname, out int param)
        {
            unsafe
            {
                fixed (int* param_ptr = &param)
                {
                    glGetRenderbufferParameteriv((GLenum)target, (GLenum)pname, param_ptr);
                }
            }
        }
        public static void GetRenderbufferParameter(RenderbufferTarget target, RenderbufferParamName pname, [Out] int[] param)
        {
            unsafe
            {
                fixed (int* param_ptr = param)
                {
                    glGetRenderbufferParameteriv((GLenum)target, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glIsFramebuffer
        private delegate GLboolean glIsFramebufferDelegate(GLuint framebuffer);
        private static glIsFramebufferDelegate glIsFramebuffer = null;
        public static bool IsFramebuffer(int framebuffer)
        {
            return glIsFramebuffer((GLuint)framebuffer);
        }
        #endregion
        #region glBindFramebuffer
        private delegate void glBindFramebufferDelegate(GLenum target, GLuint framebuffer);
        private static glBindFramebufferDelegate glBindFramebuffer = null;
        public static void BindFramebuffer(FramebufferTarget target, int framebuffer)
        {
            glBindFramebuffer((GLenum)target, (GLuint)framebuffer);
        }
        #endregion
        #region glDeleteFramebuffers
        private unsafe delegate void glDeleteFramebuffersDelegate(GLsizei n, GLuint* framebuffers);
        private static glDeleteFramebuffersDelegate glDeleteFramebuffers = null;
        public static void DeleteFramebuffers(int n, ref int framebuffers)
        {
            unsafe
            {
                fixed (int* framebuffers_ptr = &framebuffers)
                {
                    glDeleteFramebuffers(n, (GLuint*)framebuffers_ptr);
                }
            }
        }
        public static void DeleteFramebuffers(int n, int[] framebuffers)
        {
            unsafe
            {
                fixed (int* framebuffers_ptr = framebuffers)
                {
                    glDeleteFramebuffers(n, (GLuint*)framebuffers_ptr);
                }
            }
        }
        #endregion
        #region glGenFramebuffers
        private unsafe delegate void glGenFramebuffersDelegate(GLsizei n, GLuint* framebuffers);
        private static glGenFramebuffersDelegate glGenFramebuffers = null;
        public static void GenFramebuffers(int n, out int framebuffers)
        {
            unsafe
            {
                fixed (int* framebuffers_ptr = &framebuffers)
                {
                    glGenFramebuffers(n, (GLuint*)framebuffers_ptr);
                }
            }
        }
        public static void GenFramebuffers(int n, [Out] int[] framebuffers)
        {
            unsafe
            {
                fixed (int* framebuffers_ptr = framebuffers)
                {
                    glGenFramebuffers(n, (GLuint*)framebuffers_ptr);
                }
            }
        }
        #endregion
        #region glCheckFramebufferStatus
        private delegate GLenum glCheckFramebufferStatusDelegate(GLenum target);
        private static glCheckFramebufferStatusDelegate glCheckFramebufferStatus = null;
        public static FramebufferStatus CheckFramebufferStatus(FramebufferTarget target)
        {
            return (FramebufferStatus)glCheckFramebufferStatus((GLenum)target);
        }
        #endregion
        #region glFramebufferTexture1D
        private delegate void glFramebufferTexture1DDelegate(GLenum target, GLenum attachment, GLenum textarget, GLuint texture, GLint level);
        private static glFramebufferTexture1DDelegate glFramebufferTexture1D = null;
        public static void FramebufferTexture1D(FramebufferTarget target, FramebufferAttachment attachment, TextureTarget textarget, int texture, int level)
        {
            glFramebufferTexture1D((GLenum)target, (GLenum)attachment, (GLenum)textarget, (GLuint)texture, level);
        }
        #endregion
        #region glFramebufferTexture2D
        private delegate void glFramebufferTexture2DDelegate(GLenum target, GLenum attachment, GLenum textarget, GLuint texture, GLint level);
        private static glFramebufferTexture2DDelegate glFramebufferTexture2D = null;
        public static void FramebufferTexture2D(FramebufferTarget target, FramebufferAttachment attachment, TextureTarget textarget, int texture, int level)
        {
            glFramebufferTexture2D((GLenum)target, (GLenum)attachment, (GLenum)textarget, (GLuint)texture, level);
        }
        #endregion
        #region glFramebufferTexture3D
        private delegate void glFramebufferTexture3DDelegate(GLenum target, GLenum attachment, GLenum textarget, GLuint texture, GLint level, GLint zoffset);
        private static glFramebufferTexture3DDelegate glFramebufferTexture3D = null;
        public static void FramebufferTexture3D(FramebufferTarget target, FramebufferAttachment attachment, TextureTarget textarget, int texture, int level, int zoffset)
        {
            glFramebufferTexture3D((GLenum)target, (GLenum)attachment, (GLenum)textarget, (GLuint)texture, level, zoffset);
        }
        #endregion
        #region glFramebufferRenderbuffer
        private delegate void glFramebufferRenderbufferDelegate(GLenum target, GLenum attachment, GLenum renderbuffertarget, GLuint renderbuffer);
        private static glFramebufferRenderbufferDelegate glFramebufferRenderbuffer = null;
        public static void FramebufferRenderbuffer(FramebufferTarget target, FramebufferAttachment attachment, RenderbufferTarget renderbuffertarget, int renderbuffer)
        {
            glFramebufferRenderbuffer((GLenum)target, (GLenum)attachment, (GLenum)renderbuffertarget, (GLuint)renderbuffer);
        }
        #endregion
        #region glGetFramebufferAttachmentParameteriv
        private unsafe delegate void glGetFramebufferAttachmentParameterivDelegate(GLenum target, GLenum attachment, GLenum pname, GLint* param);
        private static glGetFramebufferAttachmentParameterivDelegate glGetFramebufferAttachmentParameteriv = null;
        public static void GetFramebufferAttachmentParameter(FramebufferTarget target, FramebufferAttachment attachment, FramebufferAttachmentParamName pname, out int param)
        {
            unsafe
            {
                fixed (int* param_ptr = &param)
                {
                    glGetFramebufferAttachmentParameteriv((GLenum)target, (GLenum)attachment, (GLenum)pname, param_ptr);
                }
            }
        }
        public static void GetFramebufferAttachmentParameter(FramebufferTarget target, FramebufferAttachment attachment, FramebufferAttachmentParamName pname, [Out] int[] param)
        {
            unsafe
            {
                fixed (int* param_ptr = param)
                {
                    glGetFramebufferAttachmentParameteriv((GLenum)target, (GLenum)attachment, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glGenerateMipmap
        private delegate void glGenerateMipmapDelegate(GLenum target);
        private static glGenerateMipmapDelegate glGenerateMipmap = null;
        public static void GenerateMipmap(GenerateMipmapTarget target)
        {
            glGenerateMipmap((GLenum)target);
        }
        #endregion
        #region glBlitFramebuffer
        private delegate void glBlitFramebufferDelegate(GLint srcX0, GLint srcY0, GLint srcX1, GLint srcY1, GLint dstX0, GLint dstY0, GLint dstX1, GLint dstY1, GLbitfield mask, GLenum filter);
        private static glBlitFramebufferDelegate glBlitFramebuffer = null;
        public static void BlitFramebuffer(int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, BlitFramebufferMask mask, BlitFramebufferFilter filter)
        {
            glBlitFramebuffer(srcX0, srcY0, srcX1, srcY1, dstX0, dstY0, dstX1, dstY1, (GLbitfield)mask, (GLenum)filter);
        }
        #endregion
        #region glRenderbufferStorageMultisample
        private delegate void glRenderbufferStorageMultisampleDelegate(GLenum target, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height);
        private static glRenderbufferStorageMultisampleDelegate glRenderbufferStorageMultisample = null;
        public static void RenderbufferStorageMultisample(RenderbufferTarget target, int samples, PixelInternalFormat internalformat, int width, int height)
        {
            glRenderbufferStorageMultisample((GLenum)target, samples, (GLenum)internalformat, width, height);
        }
        #endregion
        #region glFramebufferTextureLayer
        private delegate void glFramebufferTextureLayerDelegate(GLenum target, GLenum attachment, GLuint texture, GLint level, GLint layer);
        private static glFramebufferTextureLayerDelegate glFramebufferTextureLayer = null;
        public static void FramebufferTextureLayer(FramebufferTarget target, FramebufferAttachment attachment, int texture, int level, int layer)
        {
            glFramebufferTextureLayer((GLenum)target, (GLenum)attachment, (GLuint)texture, level, layer);
        }
        #endregion
        #region glMapBufferRange
        private delegate IntPtr glMapBufferRangeDelegate(GLenum target, GLintptr offset, GLsizeiptr length, GLbitfield access);
        private static glMapBufferRangeDelegate glMapBufferRange = null;
        public static IntPtr MapBufferRange(BufferTarget target, IntPtr offset, IntPtr length, MapBufferRangeAccess access)
        {
            return glMapBufferRange((GLenum)target, offset, length, (GLbitfield)access);
        }
        #endregion
        #region glFlushMappedBufferRange
        private delegate void glFlushMappedBufferRangeDelegate(GLenum target, GLintptr offset, GLsizeiptr length);
        private static glFlushMappedBufferRangeDelegate glFlushMappedBufferRange = null;
        public static void MapBufferRange(BufferTarget target, IntPtr offset, IntPtr length)
        {
            glFlushMappedBufferRange((GLenum)target, offset, length);
        }
        #endregion
        #region glBindVertexArray
        private unsafe delegate void glBindVertexArrayDelegate(GLuint array);
        private static glBindVertexArrayDelegate glBindVertexArray = null;
        public static void BindVertexArray(int array)
        {
            glBindVertexArray((GLuint)array);
        }
        #endregion
        #region glDeleteVertexArrays
        private unsafe delegate void glDeleteVertexArraysDelegate(GLsizei n, GLuint* arrays);
        private static glDeleteVertexArraysDelegate glDeleteVertexArrays = null;
        public static void DeleteVertexArrays(int n, int[] arrays)
        {
            unsafe
            {
                fixed (int* arrays_ptr = arrays)
                {
                    glDeleteVertexArrays(n, (GLuint*)arrays_ptr);
                }
            }
        }
        public static void DeleteVertexArrays(int n, ref int arrays)
        {
            unsafe
            {
                fixed (int* arrays_ptr = &arrays)
                {
                    glDeleteVertexArrays(n, (GLuint*)arrays_ptr);
                }
            }
        }
        #endregion
        #region glGenVertexArrays
        private unsafe delegate void glGenVertexArraysDelegate(GLsizei n, GLuint* arrays);
        private static glGenVertexArraysDelegate glGenVertexArrays = null;
        public static void GenVertexArrays(int n, [Out] int[] arrays)
        {
            unsafe
            {
                fixed (Int32* arrays_ptr = arrays)
                {
                    glGenVertexArrays((GLsizei)n, (GLuint*)arrays_ptr);
                }
            }
        }
        public static void GenVertexArrays(int n, out int arrays)
        {
            unsafe
            {
                fixed (Int32* arrays_ptr = &arrays)
                {
                    glGenVertexArrays((GLsizei)n, (GLuint*)arrays_ptr);
                    arrays = *arrays_ptr;
                }
            }
        }
        #endregion
        #region glIsVertexArray
        private delegate GLboolean glIsVertexArrayDelegate(GLuint array);
        private static glIsVertexArrayDelegate glIsVertexArray = null;
        public static bool IsVertexArray(int array)
        {
            return glIsVertexArray((GLuint)array);
        }
        #endregion
        #endregion
        #region OPENGL 3.1
        #region glDrawArraysInstanced
        private delegate void glDrawArraysInstancedDelegate(GLenum mode, GLint first, GLsizei count, GLsizei instancecount);
        private static glDrawArraysInstancedDelegate glDrawArraysInstanced = null;
        public static void DrawArraysInstanced(DrawMode mode, int first, int count, int instancecount)
        {
            glDrawArraysInstanced((GLenum)mode, first, count, instancecount);
        }
        #endregion
        #region glDrawElementsInstanced
        private delegate void glDrawElementsInstancedDelegate(GLenum mode, GLsizei count, GLenum type, IntPtr indices, GLsizei instancecount);
        private static glDrawElementsInstancedDelegate glDrawElementsInstanced = null;
        public static void DrawElementsInstanced(DrawMode mode, int count, DrawElementsType type, IntPtr indices, int instancecount)
        {
            glDrawElementsInstanced((GLenum)mode, count, (GLenum)type, indices, instancecount);
        }
        #endregion
        #region glTexBuffer
        private delegate void glTexBufferDelegate(GLenum target, GLenum internalformat, GLuint buffer);
        private static glTexBufferDelegate glTexBuffer = null;
        public static void TexBuffer(TextureBufferTarget target, TextureBufferInternalFormat internalformat, int buffer)
        {
            glTexBuffer((GLenum)target, (GLenum)internalformat, (GLuint)buffer);
        }
        #endregion
        #region glPrimitiveRestartIndex
        private delegate void glPrimitiveRestartIndexDelegate(GLuint index);
        private static glPrimitiveRestartIndexDelegate glPrimitiveRestartIndex = null;
        public static void PrimitiveRestartIndex(int index)
        {
            glPrimitiveRestartIndex((GLuint)index);
        }
        #endregion
        #region glCopyBufferSubData
        private delegate void glCopyBufferSubDataDelegate(GLenum readTarget, GLenum writeTarget, GLintptr readOffset, GLintptr writeOffset, GLsizeiptr size);
        private static glCopyBufferSubDataDelegate glCopyBufferSubData = null;
        public static void CopyBufferSubData(BufferTarget readTarget, BufferTarget writeTarget, IntPtr readOffset, IntPtr writeOffset, IntPtr size)
        {
            glCopyBufferSubData((GLenum)readTarget, (GLenum)writeTarget, readOffset, writeOffset, size);
        }
        #endregion
        #region glGetUniformIndices
        private unsafe delegate void glGetUniformIndicesDelegate(GLuint program, GLsizei uniformCount, string[] uniformNames, GLuint* uniformIndices);
        private static glGetUniformIndicesDelegate glGetUniformIndices = null;
        public static void GetUniformIndices(int program, int uniformCount, string[] uniformNames, out int uniformIndices)
        {
            unsafe
            {
                fixed (int* uniformIndices_ptr = &uniformIndices)
                {
                    glGetUniformIndices((GLuint)program, uniformCount, uniformNames, (GLuint*)uniformIndices_ptr);
                }
            }
        }
        public static void GetUniformIndices(int program, int uniformCount, string[] uniformNames, [Out] int[] uniformIndices)
        {
            unsafe
            {
                fixed (int* uniformIndices_ptr = uniformIndices)
                {
                    glGetUniformIndices((GLuint)program, uniformCount, uniformNames, (GLuint*)uniformIndices_ptr);
                }
            }
        }
        #endregion
        #region glGetActiveUniformsiv
        private unsafe delegate void glGetActiveUniformsivDelegate(GLuint program, GLsizei uniformCount, GLuint* uniformIndices, GLenum pname, GLint* param);
        private static glGetActiveUniformsivDelegate glGetActiveUniformsiv = null;
        public static void GetActiveUniforms(int program, int uniformCount, ref int uniformIndices, ActiveUniformParamName pname, out int param)
        {
            unsafe
            {
                fixed (int* uniformIndices_ptr = &uniformIndices, param_ptr = &param)
                {
                    glGetActiveUniformsiv((GLuint)program, uniformCount, (GLuint*)uniformIndices_ptr, (GLenum)pname, param_ptr);
                }
            }
        }
        public static void GetActiveUniforms(int program, int uniformCount, int[] uniformIndices, ActiveUniformParamName pname, [Out] int[] param)
        {
            unsafe
            {
                fixed (int* uniformIndices_ptr = uniformIndices, param_ptr = param)
                {
                    glGetActiveUniformsiv((GLuint)program, uniformCount, (GLuint*)uniformIndices_ptr, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glGetActiveUniformName
        private unsafe delegate void glGetActiveUniformNameDelegate(GLuint program, GLuint uniformIndex, GLsizei bufSize, GLsizei* length, StringBuilder uniformName);
        private static glGetActiveUniformNameDelegate glGetActiveUniformName = null;
        public static void GetActiveUniformName(int program, int uniformBlockIndex, int bufSize, out int length, StringBuilder uniformName)
        {
            unsafe
            {
                fixed (int* length_ptr = &length)
                {
                    glGetActiveUniformName((GLuint)program, (GLuint)uniformBlockIndex, bufSize, length_ptr, uniformName);
                }
            }
        }
        #endregion
        #region glGetUniformBlockIndex
        private delegate GLuint glGetUniformBlockIndexDelegate(GLuint program, string uniformBlockName);
        private static glGetUniformBlockIndexDelegate glGetUniformBlockIndex = null;
        public static int GetUniformBlockIndex(int program, string uniformBlockName)
        {
            return (int)glGetUniformBlockIndex((GLuint)program, uniformBlockName);
        }
        #endregion
        #region glGetActiveUniformBlockiv
        private unsafe delegate void glGetActiveUniformBlockivDelegate(GLuint program, GLuint uniformBlockIndex, GLenum pname, GLint* param);
        private static glGetActiveUniformBlockivDelegate glGetActiveUniformBlockiv = null;
        public static void GetActiveUniformBlock(int program, int uniformBlockIndex, ActiveUniformBlockParamName pname, out int param)
        {
            unsafe
            {
                fixed (int* param_ptr = &param)
                {
                    glGetActiveUniformBlockiv((GLuint)program, (GLuint)uniformBlockIndex, (GLenum)pname, param_ptr);
                }
            }
        }
        public static void GetActiveUniformBlock(int program, int uniformBlockIndex, ActiveUniformBlockParamName pname, [Out] int[] param)
        {
            unsafe
            {
                fixed (int* param_ptr = param)
                {
                    glGetActiveUniformBlockiv((GLuint)program, (GLuint)uniformBlockIndex, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glGetActiveUniformBlockName
        private unsafe delegate void glGetActiveUniformBlockNameDelegate(GLuint program, GLuint uniformBlockIndex, GLsizei bufSize, GLsizei* length, StringBuilder uniformBlockName);
        private static glGetActiveUniformBlockNameDelegate glGetActiveUniformBlockName = null;
        public static void GetActiveUniformBlockName(int program, int uniformBlockIndex, int bufSize, out int length, StringBuilder uniformBlockName)
        {
            unsafe
            {
                fixed (int* length_ptr = &length)
                {
                    glGetActiveUniformBlockName((GLuint)program, (GLuint)uniformBlockIndex, bufSize, length_ptr, uniformBlockName);
                }
            }
        }
        #endregion
        #region glUniformBlockBinding
        private delegate void glUniformBlockBindingDelegate(GLuint program, GLuint uniformBlockIndex, GLuint uniformBlockBinding);
        private static glUniformBlockBindingDelegate glUniformBlockBinding = null;
        public static void UniformBlockBinding(int program, int uniformBlockIndex, int uniformBlockBinding)
        {
            glUniformBlockBinding((GLuint)program, (GLuint)uniformBlockIndex, (GLuint)uniformBlockBinding);
        }
        #endregion
        #endregion
        #region OPENGL 3.2
        #region glDrawElementsBaseVertex
        private delegate void glDrawElementsBaseVertexDelegate(GLenum mode, GLsizei count, GLenum type, IntPtr indices, GLint basevertex);
        private static glDrawElementsBaseVertexDelegate glDrawElementsBaseVertex = null;
        public static void DrawElementsBaseVertex(DrawMode mode, int count, DrawElementsType type, IntPtr indices, int basevertex)
        {
            glDrawElementsBaseVertex((GLenum)mode, count, (GLenum)type, indices, basevertex);
        }
        #endregion
        #region glDrawRangeElementsBaseVertex
        private delegate void glDrawRangeElementsBaseVertexDelegate(GLenum mode, GLuint start, GLuint end, GLsizei count, GLenum type, IntPtr indices, GLint basevertex);
        private static glDrawRangeElementsBaseVertexDelegate glDrawRangeElementsBaseVertex = null;
        public static void DrawRangeElementsBaseVertex(DrawMode mode, int start, int end, int count, DrawElementsType type, IntPtr indices, int basevertex)
        {
            glDrawRangeElementsBaseVertex((GLenum)mode, (GLuint)start, (GLuint)end, count, (GLenum)type, indices, basevertex);
        }
        #endregion
        #region glDrawElementsInstancedBaseVertex
        private delegate void glDrawElementsInstancedBaseVertexDelegate(GLenum mode, GLsizei count, GLenum type, IntPtr indices, GLsizei instancecount, GLint basevertex);
        private static glDrawElementsInstancedBaseVertexDelegate glDrawElementsInstancedBaseVertex = null;
        public static void DrawElementsInstancedBaseVertex(DrawMode mode, int count, DrawElementsType type, IntPtr indices, int instancecount, int basevertex)
        {
            glDrawElementsInstancedBaseVertex((GLenum)mode, count, (GLenum)type, indices, instancecount, basevertex);
        }
        #endregion
        #region glMultiDrawElementsBaseVertex
        private unsafe delegate void glMultiDrawElementsBaseVertexDelegate(GLenum mode, GLsizei* count, GLenum type, IntPtr indices, GLsizei drawcount, GLint* basevertex);
        private static glMultiDrawElementsBaseVertexDelegate glMultiDrawElementsBaseVertex = null;
        public static void MultiDrawElementsBaseVertex(DrawMode mode, int[] count, DrawElementsType type, IntPtr indices, int drawcount, int[] basevertex)
        {
            unsafe
            {
                fixed (int* count_ptr = count)
                fixed (int* basevertex_ptr = basevertex)
                {
                    glMultiDrawElementsBaseVertex((GLenum)mode, count_ptr, (GLenum)type, indices, drawcount, basevertex_ptr);
                }
            }
        }
        #endregion
        #region glProvokingVertex
        private delegate void glProvokingVertexDelegate(GLenum mode);
        private static glProvokingVertexDelegate glProvokingVertex = null;
        public static void ProvokingVertex(ProvokingVertexMode mode)
        {
            glProvokingVertex((GLenum)mode);
        }
        #endregion
        #region glFenceSync
        private delegate GLsync glFenceSyncDelegate(GLenum condition, GLbitfield flags);
        private static glFenceSyncDelegate glFenceSync = null;
        public static void FenceSync(SyncParamName condition, FenceSyncFlags flags)
        {
            glFenceSync((GLenum)condition, (GLbitfield)flags);
        }
        #endregion
        #region glIsSync
        private delegate GLboolean glIsSyncDelegate(GLsync sync);
        private static glIsSyncDelegate glIsSync = null;
        public static bool IsSync(IntPtr sync)
        {
            return glIsSync(sync);
        }
        #endregion
        #region glDeleteSync
        private delegate void glDeleteSyncDelegate(GLsync sync);
        private static glDeleteSyncDelegate glDeleteSync = null;
        public static void DeleteSync(IntPtr sync)
        {
            glDeleteSync(sync);
        }
        #endregion
        #region glClientWaitSync
        private delegate GLenum glClientWaitSyncDelegate(GLsync sync, GLbitfield flags, GLuint64 timeout);
        private static glClientWaitSyncDelegate glClientWaitSync = null;
        public static SyncParamName ClientWaitSync(IntPtr sync, ClientWaitFlags flags, ulong timeout)
        {
            return (SyncParamName)glClientWaitSync(sync, (GLbitfield)flags, timeout);
        }
        #endregion
        #region glWaitSync
        private delegate void glWaitSyncDelegate(GLsync sync, GLbitfield flags, GLuint64 timeout);
        private static glWaitSyncDelegate glWaitSync = null;
        public static void WaitSync(IntPtr sync, WaitSyncFlags flags, ulong timeout)
        {
            glWaitSync(sync, (GLbitfield)flags, timeout);
        }
        #endregion
        #region glGetInteger64v
        private unsafe delegate void glGetInteger64vDelegate(GLenum pname, GLint64* param);
        private static glGetInteger64vDelegate glGetInteger64v = null;
        public static void GetInteger(SyncParamName pname, out long param)
        {
            unsafe
            {
                fixed (long* param_ptr = &param)
                {
                    glGetInteger64v((GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glGetSynciv
        private unsafe delegate void glGetSyncivDelegate(GLsync sync, GLenum pname, GLsizei bufSize, GLsizei* length, GLint* values);
        private static glGetSyncivDelegate glGetSynciv = null;
        public static void GetSync(IntPtr sync, SyncParamName pname, int bufSize, out int length, out int values)
        {
            unsafe
            {
                fixed (int* length_ptr = &length)
                fixed (int* values_ptr = &values)
                {
                    glGetSynciv(sync, (GLenum)pname, bufSize, length_ptr, values_ptr);
                }
            }
        }
        public static void GetSync(IntPtr sync, SyncParamName pname, int bufSize, out int length, [Out] int[] values)
        {
            unsafe
            {
                fixed (int* length_ptr = &length)
                fixed (int* values_ptr = values)
                {
                    glGetSynciv(sync, (GLenum)pname, bufSize, length_ptr, values_ptr);
                }
            }
        }
        #endregion
        #region glGetInteger64i_v
        private unsafe delegate void glGetInteger64i_vDelegate(GLenum target, GLuint index, GLint64* data);
        private static glGetInteger64i_vDelegate glGetInteger64i_v = null;
        public static void GetInteger(GetParamName pname, int index, out long param)
        {
            unsafe
            {
                fixed (long* param_ptr = &param)
                {
                    glGetInteger64i_v((GLenum)pname, (GLuint)index, param_ptr);
                }
            }
        }
        #endregion
        #region glGetBufferParameteri64v
        private unsafe delegate void glGetBufferParameteri64vDelegate(GLenum target, GLenum pname, GLint64* param);
        private static glGetBufferParameteri64vDelegate glGetBufferParameteri64v = null;
        public static void GetBufferParameter(BufferTarget target, BufferParamName pname, out long param)
        {
            unsafe
            {
                fixed (long* param_ptr = &param)
                {
                    glGetBufferParameteri64v((GLenum)target, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glFramebufferTexture
        private delegate void glFramebufferTextureDelegate(GLenum target, GLenum attachment, GLuint texture, GLint level);
        private static glFramebufferTextureDelegate glFramebufferTexture = null;
        public static void FramebufferTexture(FramebufferTarget target, FramebufferAttachment attachment, int texture, int level)
        {
            glFramebufferTexture((GLenum)target, (GLenum)attachment, (GLuint)texture, level);
        }
        #endregion
        #region glTexImage2DMultisample
        private delegate void glTexImage2DMultisampleDelegate(GLenum target, GLsizei samples, GLint internalformat, GLsizei width, GLsizei height, GLboolean fixedsamplelocations);
        private static glTexImage2DMultisampleDelegate glTexImage2DMultisample = null;
        public static void TexImage2DMultisample(TextureTargetMultisample target, int samples, PixelInternalFormat internalformat, int width, int height, bool fixedsamplelocations)
        {
            glTexImage2DMultisample((GLenum)target, samples, (GLint)internalformat, width, height, fixedsamplelocations);
        }
        #endregion
        #region glTexImage3DMultisample
        private delegate void glTexImage3DMultisampleDelegate(GLenum target, GLsizei samples, GLint internalformat, GLsizei width, GLsizei height, GLsizei depth, GLboolean fixedsamplelocations);
        private static glTexImage3DMultisampleDelegate glTexImage3DMultisample = null;
        public static void TexImage3DMultisample(TextureTargetMultisample target, int samples, PixelInternalFormat internalformat, int width, int height, int depth, bool fixedsamplelocations)
        {
            glTexImage3DMultisample((GLenum)target, samples, (GLint)internalformat, width, height, depth, fixedsamplelocations);
        }
        #endregion
        #region glGetMultisamplefv
        private unsafe delegate void glGetMultisamplefvDelegate(GLenum pname, GLuint index, GLfloat* val);
        private static glGetMultisamplefvDelegate glGetMultisamplefv = null;
        public static void GetMultisample(MultisampleParamName pname, int index, out float val)
        {
            unsafe
            {
                fixed (float* val_ptr = &val)
                {
                    glGetMultisamplefv((GLenum)pname, (GLuint)index, val_ptr);
                }
            }
        }
        public static void GetMultisample(MultisampleParamName pname, int index, [Out] float[] val)
        {
            unsafe
            {
                fixed (float* val_ptr = val)
                {
                    glGetMultisamplefv((GLenum)pname, (GLuint)index, val_ptr);
                }
            }
        }
        #endregion
        #region glSampleMaski
        private delegate void glSampleMaskiDelegate(GLuint index, GLbitfield mask);
        private static glSampleMaskiDelegate glSampleMaski = null;
        public static void SampleMask(int index, uint mask)
        {
            glSampleMaski((GLuint)index, mask);
        }
        #endregion
        #endregion
        #region OPENGL 3.3
        #region glBindFragDataLocationIndexed
        private delegate void glBindFragDataLocationIndexedDelegate(GLuint program, GLuint colorNumber, GLuint index, string name);
        private static glBindFragDataLocationIndexedDelegate glBindFragDataLocationIndexed = null;
        public static void BindFragDataLocationIndexed(int program, int colorNumber, int index, string name)
        {
            glBindFragDataLocationIndexed((GLuint)program, (GLuint)colorNumber, (GLuint)index, name);
        }
        #endregion
        #region glGetFragDataIndex
        private delegate GLint glGetFragDataIndexDelegate(GLuint program, string name);
        private static glGetFragDataIndexDelegate glGetFragDataIndex = null;
        public static int GetFragDataIndex(int program, string name)
        {
            return glGetFragDataIndex((GLuint)program, name);
        }
        #endregion
        #region glGenSamplers
        private unsafe delegate void glGenSamplersDelegate(GLsizei count, GLuint* samplers);
        private static glGenSamplersDelegate glGenSamplers = null;
        public static void GenSamplers(int count, out int samplers)
        {
            unsafe
            {
                fixed (int* samplers_ptr = &samplers)
                {
                    glGenSamplers(count, (GLuint*)samplers_ptr);
                }
            }
        }
        public static void GenSamplers(int count, [Out] int[] samplers)
        {
            unsafe
            {
                fixed (int* samplers_ptr = samplers)
                {
                    glGenSamplers(count, (GLuint*)samplers_ptr);
                }
            }
        }
        #endregion
        #region glDeleteSamplers
        private unsafe delegate void glDeleteSamplersDelegate(GLsizei count, GLuint* samplers);
        private static glDeleteSamplersDelegate glDeleteSamplers = null;
        public static void DeleteSamplers(int count, ref int samplers)
        {
            unsafe
            {
                fixed (int* samplers_ptr = &samplers)
                {
                    glDeleteSamplers(count, (GLuint*)samplers_ptr);
                }
            }
        }
        public static void DeleteSamplers(int count, int[] samplers)
        {
            unsafe
            {
                fixed (int* samplers_ptr = samplers)
                {
                    glDeleteSamplers(count, (GLuint*)samplers_ptr);
                }
            }
        }
        #endregion
        #region glIsSampler
        private delegate GLboolean glIsSamplerDelegate(GLuint sampler);
        private static glIsSamplerDelegate glIsSampler = null;
        public static bool IsSampler(int sampler)
        {
            return glIsSampler((GLuint)sampler);
        }
        #endregion
        #region glBindSampler
        private delegate void glBindSamplerDelegate(GLuint unit, GLuint sampler);
        private static glBindSamplerDelegate glBindSampler = null;
        public static void BindSampler(int unit, int sampler)
        {
            glBindSampler((GLuint)unit, (GLuint)sampler);
        }
        #endregion
        #region glSamplerParameteri
        private delegate void glSamplerParameteriDelegate(GLuint sampler, GLenum pname, GLint param);
        private static glSamplerParameteriDelegate glSamplerParameteri = null;
        public static void SamplerParameter(int sampler, TextureParamName pname, int param)
        {
            glSamplerParameteri((GLuint)sampler, (GLenum)pname, param);
        }
        #endregion
        #region glSamplerParameteriv
        private unsafe delegate void glSamplerParameterivDelegate(GLuint sampler, GLenum pname, GLint* param);
        private static glSamplerParameterivDelegate glSamplerParameteriv = null;
        public static void SamplerParameter(int sampler, TextureParamName pname, ref int param)
        {
            unsafe
            {
                fixed (int* param_ptr = &param)
                {
                    glSamplerParameteriv((GLuint)sampler, (GLenum)pname, param_ptr);
                }
            }
        }
        public static void SamplerParameter(int sampler, TextureParamName pname, int[] param)
        {
            unsafe
            {
                fixed (int* param_ptr = param)
                {
                    glSamplerParameteriv((GLuint)sampler, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glSamplerParameterf
        private delegate void glSamplerParameterfDelegate(GLuint sampler, GLenum pname, GLfloat param);
        private static glSamplerParameterfDelegate glSamplerParameterf = null;
        public static void SamplerParameter(int sampler, TextureParamName pname, float param)
        {
            glSamplerParameterf((GLuint)sampler, (GLenum)pname, param);
        }
        #endregion
        #region glSamplerParameterfv
        private unsafe delegate void glSamplerParameterfvDelegate(GLuint sampler, GLenum pname, GLfloat* param);
        private static glSamplerParameterfvDelegate glSamplerParameterfv = null;
        public static void SamplerParameter(int sampler, TextureParamName pname, ref float param)
        {
            unsafe
            {
                fixed (float* param_ptr = &param)
                {
                    glSamplerParameterfv((GLuint)sampler, (GLenum)pname, param_ptr);
                }
            }
        }
        public static void SamplerParameter(int sampler, TextureParamName pname, float[] param)
        {
            unsafe
            {
                fixed (float* param_ptr = param)
                {
                    glSamplerParameterfv((GLuint)sampler, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glSamplerParameterIiv
        private unsafe delegate void glSamplerParameterIivDelegate(GLuint sampler, GLenum pname, GLint* param);
        private static glSamplerParameterIivDelegate glSamplerParameterIiv = null;
        public static void SamplerParameterI(int sampler, TextureParamName pname, ref int param)
        {
            unsafe
            {
                fixed (int* param_ptr = &param)
                {
                    glSamplerParameterIiv((GLuint)sampler, (GLenum)pname, param_ptr);
                }
            }
        }
        public static void SamplerParameterI(int sampler, TextureParamName pname, int[] param)
        {
            unsafe
            {
                fixed (int* param_ptr = param)
                {
                    glSamplerParameterIiv((GLuint)sampler, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glSamplerParameterIuiv
        private unsafe delegate void glSamplerParameterIuivDelegate(GLuint sampler, GLenum pname, GLuint* param);
        private static glSamplerParameterIuivDelegate glSamplerParameterIuiv = null;
        public static void SamplerParameterI(int sampler, TextureParamName pname, ref uint param)
        {
            unsafe
            {
                fixed (uint* param_ptr = &param)
                {
                    glSamplerParameterIuiv((GLuint)sampler, (GLenum)pname, param_ptr);
                }
            }
        }
        public static void SamplerParameterI(int sampler, TextureParamName pname, uint[] param)
        {
            unsafe
            {
                fixed (uint* param_ptr = param)
                {
                    glSamplerParameterIuiv((GLuint)sampler, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glGetSamplerParameteriv
        private unsafe delegate void glGetSamplerParameterivDelegate(GLuint sampler, GLenum pname, GLint* param);
        private static glGetSamplerParameterivDelegate glGetSamplerParameteriv = null;
        public static void GetSamplerParameter(int sampler, TextureParamName pname, out int param)
        {
            unsafe
            {
                fixed (int* param_ptr = &param)
                {
                    glGetSamplerParameteriv((GLuint)sampler, (GLenum)pname, param_ptr);
                }
            }
        }
        public static void GetSamplerParameter(int sampler, TextureParamName pname, [Out] int[] param)
        {
            unsafe
            {
                fixed (int* param_ptr = param)
                {
                    glGetSamplerParameteriv((GLuint)sampler, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glGetSamplerParameterIiv
        private unsafe delegate void glGetSamplerParameterIivDelegate(GLuint sampler, GLenum pname, GLint* param);
        private static glGetSamplerParameterIivDelegate glGetSamplerParameterIiv = null;
        public static void GetSamplerParameterI(int sampler, TextureParamName pname, out int param)
        {
            unsafe
            {
                fixed (int* param_ptr = &param)
                {
                    glGetSamplerParameterIiv((GLuint)sampler, (GLenum)pname, param_ptr);
                }
            }
        }
        public static void GetSamplerParameterI(int sampler, TextureParamName pname, [Out] int[] param)
        {
            unsafe
            {
                fixed (int* param_ptr = param)
                {
                    glGetSamplerParameterIiv((GLuint)sampler, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glGetSamplerParameterfv
        private unsafe delegate void glGetSamplerParameterfvDelegate(GLuint sampler, GLenum pname, GLfloat* param);
        private static glGetSamplerParameterfvDelegate glGetSamplerParameterfv = null;
        public static void GetSamplerParameter(int sampler, TextureParamName pname, out float param)
        {
            unsafe
            {
                fixed (float* param_ptr = &param)
                {
                    glGetSamplerParameterfv((GLuint)sampler, (GLenum)pname, param_ptr);
                }
            }
        }
        public static void GetSamplerParameter(int sampler, TextureParamName pname, [Out] float[] param)
        {
            unsafe
            {
                fixed (float* param_ptr = param)
                {
                    glGetSamplerParameterfv((GLuint)sampler, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glGetSamplerParameterIuiv
        private unsafe delegate void glGetSamplerParameterIuivDelegate(GLuint sampler, GLenum pname, GLuint* param);
        private static glGetSamplerParameterIuivDelegate glGetSamplerParameterIuiv = null;
        public static void GetSamplerParameterI(int sampler, TextureParamName pname, out uint param)
        {
            unsafe
            {
                fixed (uint* param_ptr = &param)
                {
                    glGetSamplerParameterIuiv((GLuint)sampler, (GLenum)pname, param_ptr);
                }
            }
        }
        public static void GetSamplerParameterI(int sampler, TextureParamName pname, [Out] uint[] param)
        {
            unsafe
            {
                fixed (uint* param_ptr = param)
                {
                    glGetSamplerParameterIuiv((GLuint)sampler, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glQueryCounter
        private delegate void glQueryCounterDelegate(GLuint id, GLenum target);
        private static glQueryCounterDelegate glQueryCounter = null;
        public static void QueryCounter(int id, QueryCounterTarget target)
        {
            glQueryCounter((GLuint)id, (GLenum)target);
        }
        #endregion
        #region glGetQueryObjecti64v
        private unsafe delegate void glGetQueryObjecti64vDelegate(GLuint id, GLenum pname, GLint64* param);
        private static glGetQueryObjecti64vDelegate glGetQueryObjecti64v = null;
        public static void GetQueryObject(int id, QueryObjectParamName pname, out long param)
        {
            unsafe
            {
                fixed (long* param_ptr = &param)
                {
                    glGetQueryObjecti64v((GLuint)id, (GLenum)pname, param_ptr);
                }
            }
        }
        public static void GetQueryObject(int id, QueryObjectParamName pname, [Out] long[] param)
        {
            unsafe
            {
                fixed (long* param_ptr = param)
                {
                    glGetQueryObjecti64v((GLuint)id, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glGetQueryObjectui64v
        private unsafe delegate void glGetQueryObjectui64vDelegate(GLuint id, GLenum pname, GLuint64* param);
        private static glGetQueryObjectui64vDelegate glGetQueryObjectui64v = null;
        public static void GetQueryObject(int id, QueryObjectParamName pname, out ulong param)
        {
            unsafe
            {
                fixed (ulong* param_ptr = &param)
                {
                    glGetQueryObjectui64v((GLuint)id, (GLenum)pname, param_ptr);
                }
            }
        }
        public static void GetQueryObject(int id, QueryObjectParamName pname, [Out] ulong[] param)
        {
            unsafe
            {
                fixed (ulong* param_ptr = param)
                {
                    glGetQueryObjectui64v((GLuint)id, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttribDivisor
        private delegate void glVertexAttribDivisorDelegate(GLuint index, GLuint divisor);
        private static glVertexAttribDivisorDelegate glVertexAttribDivisor = null;
        public static void VertexAttribDivisor(int index, int divisor)
        {
            glVertexAttribDivisor((GLuint)index, (GLuint)divisor);
        }
        #endregion
        #region glVertexAttribP1ui
        private delegate void glVertexAttribP1uiDelegate(GLuint index, GLenum type, GLboolean normalized, GLuint value);
        private static glVertexAttribP1uiDelegate glVertexAttribP1ui = null;
        public static void VertexAttribP1(int index, VertexAttribPackingType type, bool normalized, uint value)
        {
            glVertexAttribP1ui((GLuint)index, (GLenum)type, normalized, value);
        }
        #endregion
        #region glVertexAttribP1uiv
        private unsafe delegate void glVertexAttribP1uivDelegate(GLuint index, GLenum type, GLboolean normalized, GLuint* value);
        private static glVertexAttribP1uivDelegate glVertexAttribP1uiv = null;
        public static void VertexAttribP1(int index, VertexAttribPackingType type, bool normalized, ref uint value)
        {
            unsafe
            {
                fixed (uint* value_ptr = &value)
                {
                    glVertexAttribP1uiv((GLuint)index, (GLenum)type, normalized, value_ptr);
                }
            }
        }
        public static void VertexAttribP1(int index, VertexAttribPackingType type, bool normalized, uint[] value)
        {
            unsafe
            {
                fixed (uint* value_ptr = value)
                {
                    glVertexAttribP1uiv((GLuint)index, (GLenum)type, normalized, value_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttribP2ui
        private delegate void glVertexAttribP2uiDelegate(GLuint index, GLenum type, GLboolean normalized, GLuint value);
        private static glVertexAttribP2uiDelegate glVertexAttribP2ui = null;
        public static void VertexAttribP2(int index, VertexAttribPackingType type, bool normalized, uint value)
        {
            glVertexAttribP2ui((GLuint)index, (GLenum)type, normalized, value);
        }
        #endregion
        #region glVertexAttribP2uiv
        private unsafe delegate void glVertexAttribP2uivDelegate(GLuint index, GLenum type, GLboolean normalized, GLuint* value);
        private static glVertexAttribP2uivDelegate glVertexAttribP2uiv = null;
        public static void VertexAttribP2(int index, VertexAttribPackingType type, bool normalized, ref uint value)
        {
            unsafe
            {
                fixed (uint* value_ptr = &value)
                {
                    glVertexAttribP2uiv((GLuint)index, (GLenum)type, normalized, value_ptr);
                }
            }
        }
        public static void VertexAttribP2(int index, VertexAttribPackingType type, bool normalized, uint[] value)
        {
            unsafe
            {
                fixed (uint* value_ptr = value)
                {
                    glVertexAttribP2uiv((GLuint)index, (GLenum)type, normalized, value_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttribP3ui
        private delegate void glVertexAttribP3uiDelegate(GLuint index, GLenum type, GLboolean normalized, GLuint value);
        private static glVertexAttribP3uiDelegate glVertexAttribP3ui = null;
        public static void VertexAttribP3(int index, VertexAttribPackingType type, bool normalized, uint value)
        {
            glVertexAttribP3ui((GLuint)index, (GLenum)type, normalized, value);
        }
        #endregion
        #region glVertexAttribP3uiv
        private unsafe delegate void glVertexAttribP3uivDelegate(GLuint index, GLenum type, GLboolean normalized, GLuint* value);
        private static glVertexAttribP3uivDelegate glVertexAttribP3uiv = null;
        public static void VertexAttribP3(int index, VertexAttribPackingType type, bool normalized, ref uint value)
        {
            unsafe
            {
                fixed (uint* value_ptr = &value)
                {
                    glVertexAttribP3uiv((GLuint)index, (GLenum)type, normalized, value_ptr);
                }
            }
        }
        public static void VertexAttribP3(int index, VertexAttribPackingType type, bool normalized, uint[] value)
        {
            unsafe
            {
                fixed (uint* value_ptr = value)
                {
                    glVertexAttribP3uiv((GLuint)index, (GLenum)type, normalized, value_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttribP4ui
        private delegate void glVertexAttribP4uiDelegate(GLuint index, GLenum type, GLboolean normalized, GLuint value);
        private static glVertexAttribP4uiDelegate glVertexAttribP4ui = null;
        public static void VertexAttribP4(int index, VertexAttribPackingType type, bool normalized, uint value)
        {
            glVertexAttribP4ui((GLuint)index, (GLenum)type, normalized, value);
        }
        #endregion
        #region glVertexAttribP4uiv
        private unsafe delegate void glVertexAttribP4uivDelegate(GLuint index, GLenum type, GLboolean normalized, GLuint* value);
        private static glVertexAttribP4uivDelegate glVertexAttribP4uiv = null;
        public static void VertexAttribP4(int index, VertexAttribPackingType type, bool normalized, ref uint value)
        {
            unsafe
            {
                fixed (uint* value_ptr = &value)
                {
                    glVertexAttribP4uiv((GLuint)index, (GLenum)type, normalized, value_ptr);
                }
            }
        }
        public static void VertexAttribP4(int index, VertexAttribPackingType type, bool normalized, uint[] value)
        {
            unsafe
            {
                fixed (uint* value_ptr = value)
                {
                    glVertexAttribP4uiv((GLuint)index, (GLenum)type, normalized, value_ptr);
                }
            }
        }
        #endregion
        #endregion
        #region OPENGL 4.0
        #region glMinSampleShading
        private delegate void glMinSampleShadingDelegate(GLfloat value);
        private static glMinSampleShadingDelegate glMinSampleShading = null;
        public static void MinSampleShading(float value)
        {
            glMinSampleShading(value);
        }
        #endregion
        #region glBlendEquationi
        private delegate void glBlendEquationiDelegate(GLuint buf, GLenum mode);
        private static glBlendEquationiDelegate glBlendEquationi = null;
        public static void BlendEquation(int buf, BlendEquationMode mode)
        {
            glBlendEquationi((GLuint)buf, (GLenum)mode);
        }
        #endregion
        #region glBlendEquationSeparatei
        private delegate void glBlendEquationSeparateiDelegate(GLuint buf, GLenum modeRGB, GLenum modeAlpha);
        private static glBlendEquationSeparateiDelegate glBlendEquationSeparatei = null;
        public static void BlendEquationSeparate(int buf, BlendEquationMode modeRGB, BlendEquationMode modeAlpha)
        {
            glBlendEquationSeparatei((GLuint)buf, (GLenum)modeRGB, (GLenum)modeAlpha);
        }
        #endregion
        #region glBlendFunci
        private delegate void glBlendFunciDelegate(GLuint buf, GLenum src, GLenum dst);
        private static glBlendFunciDelegate glBlendFunci = null;
        public static void BlendFunc(int buf, BlendFactor src, BlendFactor dst)
        {
            glBlendFunci((GLuint)buf, (GLenum)src, (GLenum)dst);
        }
        #endregion
        #region glBlendFuncSeparatei
        private delegate void glBlendFuncSeparateiDelegate(GLuint buf, GLenum srcRGB, GLenum dstRGB, GLenum srcAlpha, GLenum dstAlpha);
        private static glBlendFuncSeparateiDelegate glBlendFuncSeparatei = null;
        public static void BlendFuncSeparate(int buf, BlendFactor srcRGB, BlendFactor dstRGB, BlendFactor srcAlpha, BlendFactor dstAlpha)
        {
            glBlendFuncSeparatei((GLuint)buf, (GLenum)srcRGB, (GLenum)dstRGB, (GLenum)srcAlpha, (GLenum)dstAlpha);
        }
        #endregion
        #region glDrawArraysIndirect
        private delegate void glDrawArraysIndirectDelegate(GLenum mode, IntPtr indirect);
        private static glDrawArraysIndirectDelegate glDrawArraysIndirect = null;
        public static void DrawArraysIndirect(DrawMode mode, IntPtr indirect)
        {
            glDrawArraysIndirect((GLenum)mode, indirect);
        }
        #endregion
        #region glDrawElementsIndirect
        private delegate void glDrawElementsIndirectDelegate(GLenum mode, GLenum type, IntPtr indirect);
        private static glDrawElementsIndirectDelegate glDrawElementsIndirect = null;
        public static void DrawElementsIndirect(DrawMode mode, DrawElementsType type, IntPtr indirect)
        {
            glDrawElementsIndirect((GLenum)mode, (GLenum)type, indirect);
        }
        #endregion
        #region glUniform1d
        private delegate void glUniform1dDelegate(GLint location, GLdouble x);
        private static glUniform1dDelegate glUniform1d = null;
        public static void Uniform1(int location, double x)
        {
            glUniform1d(location, x);
        }
        #endregion
        #region glUniform2d
        private delegate void glUniform2dDelegate(GLint location, GLdouble x, GLdouble y);
        private static glUniform2dDelegate glUniform2d = null;
        public static void Uniform2(int location, double x, double y)
        {
            glUniform2d(location, x, y);
        }
        #endregion
        #region glUniform3d
        private delegate void glUniform3dDelegate(GLint location, GLdouble x, GLdouble y, GLdouble z);
        private static glUniform3dDelegate glUniform3d = null;
        public static void Uniform3(int location, double x, double y, double z)
        {
            glUniform3d(location, x, y, z);
        }
        #endregion
        #region glUniform4d
        private delegate void glUniform4dDelegate(GLint location, GLdouble x, GLdouble y, GLdouble z, GLdouble w);
        private static glUniform4dDelegate glUniform4d = null;
        public static void Uniform3(int location, double x, double y, double z, double w)
        {
            glUniform4d(location, x, y, z, w);
        }
        #endregion
        #region glUniform1dv
        private unsafe delegate void glUniform1dvDelegate(GLint location, GLsizei count, GLdouble* value);
        private static glUniform1dvDelegate glUniform1dv = null;
        public static void Uniform1(int location, int count, double[] value)
        {
            unsafe
            {
                fixed (double* value_ptr = value)
                {
                    glUniform1dv(location, count, value_ptr);
                }
            }
        }
        #endregion
        #region glUniform2dv
        private unsafe delegate void glUniform2dvDelegate(GLint location, GLsizei count, GLdouble* value);
        private static glUniform2dvDelegate glUniform2dv = null;
        public static void Uniform2(int location, int count, double[] value)
        {
            unsafe
            {
                fixed (double* value_ptr = value)
                {
                    glUniform2dv(location, count, value_ptr);
                }
            }
        }
        #endregion
        #region glUniform3dv
        private unsafe delegate void glUniform3dvDelegate(GLint location, GLsizei count, GLdouble* value);
        private static glUniform3dvDelegate glUniform3dv = null;
        public static void Uniform3(int location, int count, double[] value)
        {
            unsafe
            {
                fixed (double* value_ptr = value)
                {
                    glUniform3dv(location, count, value_ptr);
                }
            }
        }
        #endregion
        #region glUniform4dv
        private unsafe delegate void glUniform4dvDelegate(GLint location, GLsizei count, GLdouble* value);
        private static glUniform4dvDelegate glUniform4dv = null;
        public static void Uniform4(int location, int count, double[] value)
        {
            unsafe
            {
                fixed (double* value_ptr = value)
                {
                    glUniform4dv(location, count, value_ptr);
                }
            }
        }
        #endregion
        #region glUniformMatrix2dv
        private unsafe delegate void glUniformMatrix2dvDelegate(GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
        private static glUniformMatrix2dvDelegate glUniformMatrix2dv = null;
        public static void UniformMatrix2(int location, int count, bool transpose, double[] value)
        {
            unsafe
            {
                fixed (double* value_ptr = value)
                {
                    glUniformMatrix2dv(location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glUniformMatrix3dv
        private unsafe delegate void glUniformMatrix3dvDelegate(GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
        private static glUniformMatrix3dvDelegate glUniformMatrix3dv = null;
        public static void UniformMatrix3(int location, int count, bool transpose, double[] value)
        {
            unsafe
            {
                fixed (double* value_ptr = value)
                {
                    glUniformMatrix3dv(location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glUniformMatrix4dv
        private unsafe delegate void glUniformMatrix4dvDelegate(GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
        private static glUniformMatrix4dvDelegate glUniformMatrix4dv = null;
        public static void UniformMatrix4(int location, int count, bool transpose, double[] value)
        {
            unsafe
            {
                fixed (double* value_ptr = value)
                {
                    glUniformMatrix4dv(location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glUniformMatrix2x3dv
        private unsafe delegate void glUniformMatrix2x3dvDelegate(GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
        private static glUniformMatrix2x3dvDelegate glUniformMatrix2x3dv = null;
        public static void UniformMatrix2x3(int location, int count, bool transpose, double[] value)
        {
            unsafe
            {
                fixed (double* value_ptr = value)
                {
                    glUniformMatrix2x3dv(location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glUniformMatrix2x4dv
        private unsafe delegate void glUniformMatrix2x4dvDelegate(GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
        private static glUniformMatrix2x4dvDelegate glUniformMatrix2x4dv = null;
        public static void UniformMatrix2x4(int location, int count, bool transpose, double[] value)
        {
            unsafe
            {
                fixed (double* value_ptr = value)
                {
                    glUniformMatrix2x4dv(location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glUniformMatrix3x2dv
        private unsafe delegate void glUniformMatrix3x2dvDelegate(GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
        private static glUniformMatrix3x2dvDelegate glUniformMatrix3x2dv = null;
        public static void UniformMatrix3x2(int location, int count, bool transpose, double[] value)
        {
            unsafe
            {
                fixed (double* value_ptr = value)
                {
                    glUniformMatrix3x2dv(location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glUniformMatrix3x4dv
        private unsafe delegate void glUniformMatrix3x4dvDelegate(GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
        private static glUniformMatrix3x4dvDelegate glUniformMatrix3x4dv = null;
        public static void UniformMatrix3x4(int location, int count, bool transpose, double[] value)
        {
            unsafe
            {
                fixed (double* value_ptr = value)
                {
                    glUniformMatrix3x4dv(location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glUniformMatrix4x2dv
        private unsafe delegate void glUniformMatrix4x2dvDelegate(GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
        private static glUniformMatrix4x2dvDelegate glUniformMatrix4x2dv = null;
        public static void UniformMatrix4x2(int location, int count, bool transpose, double[] value)
        {
            unsafe
            {
                fixed (double* value_ptr = value)
                {
                    glUniformMatrix4x2dv(location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glUniformMatrix4x3dv
        private unsafe delegate void glUniformMatrix4x3dvDelegate(GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
        private static glUniformMatrix4x3dvDelegate glUniformMatrix4x3dv = null;
        public static void UniformMatrix4x3(int location, int count, bool transpose, double[] value)
        {
            unsafe
            {
                fixed (double* value_ptr = value)
                {
                    glUniformMatrix4x3dv(location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glGetUniformdv
        private unsafe delegate void glGetUniformdvDelegate(GLuint program, GLint location, GLdouble* param);
        private static glGetUniformdvDelegate glGetUniformdv = null;
        public static void GetUniform(int program, int location, out double param)
        {
            unsafe
            {
                fixed (double* param_ptr = &param)
                {
                    glGetUniformdv((GLuint)program, location, param_ptr);
                }
            }
        }
        public static void GetUniform(int program, int location, [Out] double[] param)
        {
            unsafe
            {
                fixed (double* param_ptr = param)
                {
                    glGetUniformdv((GLuint)program, location, param_ptr);
                }
            }
        }
        #endregion
        #region glGetSubroutineUniformLocation
        private delegate GLint glGetSubroutineUniformLocationDelegate(GLuint program, GLenum shadertype, string name);
        private static glGetSubroutineUniformLocationDelegate glGetSubroutineUniformLocation = null;
        public static int GetSubroutineUniformLocation(int program, ShaderType shadertype, string name)
        {
            return glGetSubroutineUniformLocation((GLuint)program, (GLenum)shadertype, name);
        }
        #endregion
        #region glGetSubroutineIndex
        private unsafe delegate GLuint glGetSubroutineIndexDelegate(GLuint program, GLenum shadertype, string name);
        private static glGetSubroutineIndexDelegate glGetSubroutineIndex = null;
        public static int GetSubroutineIndex(int program, ShaderType shadertype, string name)
        {
            return (int)glGetSubroutineIndex((GLuint)program, (GLenum)shadertype, name);
        }
        #endregion
        #region glGetActiveSubroutineUniformiv
        private unsafe delegate void glGetActiveSubroutineUniformivDelegate(GLuint program, GLenum shadertype, GLuint index, GLenum pname, GLint* values);
        private static glGetActiveSubroutineUniformivDelegate glGetActiveSubroutineUniformiv = null;
        public static void GetActiveSubroutineUniform(int program, ShaderType shadertype, int index, ShaderSubroutineParamName pname, out int values)
        {
            unsafe
            {
                fixed (int* values_ptr = &values)
                {
                    glGetActiveSubroutineUniformiv((GLuint)program, (GLenum)shadertype, (GLuint)index, (GLenum)pname, values_ptr);
                }
            }
        }
        public static void GetActiveSubroutineUniform(int program, ShaderType shadertype, int index, ShaderSubroutineParamName pname, [Out] int[] values)
        {
            unsafe
            {
                fixed (int* values_ptr = values)
                {
                    glGetActiveSubroutineUniformiv((GLuint)program, (GLenum)shadertype, (GLuint)index, (GLenum)pname, values_ptr);
                }
            }
        }
        #endregion
        #region glGetActiveSubroutineUniformName
        private unsafe delegate void glGetActiveSubroutineUniformNameDelegate(GLuint program, GLenum shadertype, GLuint index, GLsizei bufsize, GLsizei* length, StringBuilder name);
        private static glGetActiveSubroutineUniformNameDelegate glGetActiveSubroutineUniformName = null;
        public static void GetActiveSubroutineUniformName(int program, ShaderType shadertype, int index, int bufSize, out int length, StringBuilder name)
        {
            unsafe
            {
                fixed (int* length_ptr = &length)
                {
                    glGetActiveSubroutineUniformName((GLuint)program, (GLenum)shadertype, (GLuint)index, bufSize, length_ptr, name);
                }
            }
        }
        #endregion
        #region glGetActiveSubroutineName
        private unsafe delegate void glGetActiveSubroutineNameDelegate(GLuint program, GLenum shadertype, GLuint index, GLsizei bufsize, GLsizei* length, StringBuilder name);
        private static glGetActiveSubroutineNameDelegate glGetActiveSubroutineName = null;
        public static void GetActiveSubroutineName(int program, ShaderType shadertype, int index, int bufSize, out int length, StringBuilder name)
        {
            unsafe
            {
                fixed (int* length_ptr = &length)
                {
                    glGetActiveSubroutineName((GLuint)program, (GLenum)shadertype, (GLuint)index, bufSize, length_ptr, name);
                }
            }
        }
        #endregion
        #region glUniformSubroutinesuiv
        private unsafe delegate void glUniformSubroutinesuivDelegate(GLenum shadertype, GLsizei count, GLuint* indices);
        private static glUniformSubroutinesuivDelegate glUniformSubroutinesuiv = null;
        public static void UniformSubroutines(ShaderType shadertype, int count, ref int indices)
        {
            unsafe
            {
                fixed (int* indices_ptr = &indices)
                {
                    glUniformSubroutinesuiv((GLenum)shadertype, count, (GLuint*)indices_ptr);
                }
            }
        }
        public static void UniformSubroutines(ShaderType shadertype, int count, int[] indices)
        {
            unsafe
            {
                fixed (int* indices_ptr = indices)
                {
                    glUniformSubroutinesuiv((GLenum)shadertype, count, (GLuint*)indices_ptr);
                }
            }
        }
        #endregion
        #region glGetUniformSubroutineuiv
        private unsafe delegate void glGetUniformSubroutineuivDelegate(GLenum shadertype, GLint location, GLuint* param);
        private static glGetUniformSubroutineuivDelegate glGetUniformSubroutineuiv = null;
        public static void GetUniformSubroutine(ShaderType shadertype, int location, out int param)
        {
            unsafe
            {
                fixed (int* param_ptr = &param)
                {
                    glGetUniformSubroutineuiv((GLenum)shadertype, location, (GLuint*)param_ptr);
                }
            }
        }
        public static void GetUniformSubroutine(ShaderType shadertype, int location, [Out] int[] param)
        {
            unsafe
            {
                fixed (int* param_ptr = param)
                {
                    glGetUniformSubroutineuiv((GLenum)shadertype, location, (GLuint*)param_ptr);
                }
            }
        }
        #endregion
        #region glGetProgramStageiv
        private unsafe delegate void glGetProgramStageivDelegate(GLuint program, GLenum shadertype, GLenum pname, GLint* values);
        private static glGetProgramStageivDelegate glGetProgramStageiv = null;
        public static void GetProgramStage(int program, ShaderType shadertype, ProgramStageParamName pname, out int values)
        {
            unsafe
            {
                fixed (int* values_ptr = &values)
                {
                    glGetProgramStageiv((GLuint)program, (GLenum)shadertype, (GLenum)pname, values_ptr);
                }
            }
        }
        public static void GetProgramStage(int program, ShaderType shadertype, ProgramStageParamName pname, [Out] int[] values)
        {
            unsafe
            {
                fixed (int* values_ptr = values)
                {
                    glGetProgramStageiv((GLuint)program, (GLenum)shadertype, (GLenum)pname, values_ptr);
                }
            }
        }
        #endregion
        #region glPatchParameteri
        private delegate void glPatchParameteriDelegate(GLenum pname, GLint value);
        private static glPatchParameteriDelegate glPatchParameteri = null;
        public static void PatchParameter(PatchParamName pname, int value)
        {
            glPatchParameteri((GLenum)pname, value);
        }
        #endregion
        #region glPatchParameterfv
        private unsafe delegate void glPatchParameterfvDelegate(GLenum pname, GLfloat* values);
        private static glPatchParameterfvDelegate glPatchParameterfv = null;
        public static void PatchParameter(PatchParamName pname, ref float values)
        {
            unsafe
            {
                fixed (float* values_ptr = &values)
                {
                    glPatchParameterfv((GLenum)pname, values_ptr);
                }
            }
        }
        public static void PatchParameter(PatchParamName pname, float[] values)
        {
            unsafe
            {
                fixed (float* values_ptr = values)
                {
                    glPatchParameterfv((GLenum)pname, values_ptr);
                }
            }
        }
        #endregion
        #region glBindTransformFeedback
        private delegate void glBindTransformFeedbackDelegate(GLenum target, GLuint id);
        private static glBindTransformFeedbackDelegate glBindTransformFeedback = null;
        public static void BindTransformFeedback(TransformFeedbackTarget target, int id)
        {
            glBindTransformFeedback((GLenum)target, (GLuint)id);
        }
        #endregion
        #region glDeleteTransformFeedbacks
        private unsafe delegate void glDeleteTransformFeedbacksDelegate(GLsizei n, GLuint* ids);
        private static glDeleteTransformFeedbacksDelegate glDeleteTransformFeedbacks = null;
        public static void DeleteTransformFeedbacks(int n, ref int ids)
        {
            unsafe
            {
                fixed (int* ids_ptr = &ids)
                {
                    glDeleteTransformFeedbacks(n, (GLuint*)ids_ptr);
                }
            }
        }
        public static void DeleteTransformFeedbacks(int n, int[] ids)
        {
            unsafe
            {
                fixed (int* ids_ptr = ids)
                {
                    glDeleteTransformFeedbacks(n, (GLuint*)ids_ptr);
                }
            }
        }
        #endregion
        #region glGenTransformFeedbacks
        private unsafe delegate void glGenTransformFeedbacksDelegate(GLsizei n, GLuint* ids);
        private static glGenTransformFeedbacksDelegate glGenTransformFeedbacks = null;
        public static void GenTransformFeedbacks(int n, out int ids)
        {
            unsafe
            {
                fixed (int* ids_ptr = &ids)
                {
                    glGenTransformFeedbacks(n, (GLuint*)ids_ptr);
                }
            }
        }
        public static void GenTransformFeedbacks(int n, [Out] int[] ids)
        {
            unsafe
            {
                fixed (int* ids_ptr = ids)
                {
                    glGenTransformFeedbacks(n, (GLuint*)ids_ptr);
                }
            }
        }
        #endregion
        #region glIsTransformFeedback
        private delegate GLboolean glIsTransformFeedbackDelegate(GLuint id);
        private static glIsTransformFeedbackDelegate glIsTransformFeedback = null;
        public static bool IsTransformFeedback(int id)
        {
            return glIsTransformFeedback((GLuint)id);
        }
        #endregion
        #region glPauseTransformFeedback
        private delegate void glPauseTransformFeedbackDelegate();
        private static glPauseTransformFeedbackDelegate glPauseTransformFeedback = null;
        public static void PauseTransformFeedback()
        {
            glPauseTransformFeedback();
        }
        #endregion
        #region glResumeTransformFeedback
        private delegate void glResumeTransformFeedbackDelegate();
        private static glResumeTransformFeedbackDelegate glResumeTransformFeedback = null;
        public static void ResumeTransformFeedback()
        {
            glResumeTransformFeedback();
        }
        #endregion
        #region glDrawTransformFeedback
        private delegate void glDrawTransformFeedbackDelegate(GLenum mode, GLuint id);
        private static glDrawTransformFeedbackDelegate glDrawTransformFeedback = null;
        public static void DrawTransformFeedback(DrawMode mode, int id)
        {
            glDrawTransformFeedback((GLenum)mode, (GLuint)id);
        }
        #endregion
        #region glDrawTransformFeedbackStream
        private delegate void glDrawTransformFeedbackStreamDelegate(GLenum mode, GLuint id, GLuint stream);
        private static glDrawTransformFeedbackStreamDelegate glDrawTransformFeedbackStream = null;
        public static void DrawTransformFeedbackStream(DrawMode mode, int id, int stream)
        {
            glDrawTransformFeedbackStream((GLenum)mode, (GLuint)id, (GLuint)stream);
        }
        #endregion
        #region glBeginQueryIndexed
        private delegate void glBeginQueryIndexedDelegate(GLenum target, GLuint index, GLuint id);
        private static glBeginQueryIndexedDelegate glBeginQueryIndexed = null;
        public static void BeginQueryIndexed(QueryTarget target, int index, int id)
        {
            glBeginQueryIndexed((GLenum)target, (GLuint)index, (GLuint)id);
        }
        #endregion
        #region glEndQueryIndexed
        private delegate void glEndQueryIndexedDelegate(GLenum target, GLuint index);
        private static glEndQueryIndexedDelegate glEndQueryIndexed = null;
        public static void EndQueryIndexed(QueryTarget target, int index)
        {
            glEndQueryIndexed((GLenum)target, (GLuint)index);
        }
        #endregion
        #region glGetQueryIndexediv
        private unsafe delegate void glGetQueryIndexedivDelegate(GLenum target, GLuint index, GLenum pname, GLint* param);
        private static glGetQueryIndexedivDelegate glGetQueryIndexediv = null;
        public static void GetQueryIndexed(QueryTarget target, int index, QueryParamName pname, out int param)
        {
            unsafe
            {
                fixed (int* param_ptr = &param)
                {
                    glGetQueryIndexediv((GLenum)target, (GLuint)index, (GLenum)pname, param_ptr);
                }
            }
        }
        public static void GetQueryIndexed(QueryTarget target, int index, QueryParamName pname, [Out] int[] param)
        {
            unsafe
            {
                fixed (int* param_ptr = param)
                {
                    glGetQueryIndexediv((GLenum)target, (GLuint)index, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #endregion
        #region OPENGL 4.1
        #region glReleaseShaderCompiler
        private delegate void glReleaseShaderCompilerDelegate();
        private static glReleaseShaderCompilerDelegate glReleaseShaderCompiler = null;
        public static void ReleaseShaderCompiler()
        {
            glReleaseShaderCompiler();
        }
        #endregion
        #region glShaderBinary
        private unsafe delegate void glShaderBinaryDelegate(GLsizei count, GLuint* shaders, GLenum binaryformat, IntPtr binary, GLsizei length);
        private static glShaderBinaryDelegate glShaderBinary = null;
        public static void ShaderBinary(int count, int[] shaders, ShaderBinaryFormat binaryformat, IntPtr binary, int length)
        {
            unsafe
            {
                fixed (int* shaders_ptr = shaders)
                {
                    glShaderBinary(count, (GLuint*)shaders_ptr, (GLenum)binaryformat, binary, length);
                }
            }
        }
        #endregion
        #region glGetShaderPrecisionFormat
        private unsafe delegate void glGetShaderPrecisionFormatDelegate(GLenum shadertype, GLenum precisiontype, GLint* range, GLint* precision);
        private static glGetShaderPrecisionFormatDelegate glGetShaderPrecisionFormat = null;
        public static void GetShaderPrecisionFormat(ShaderType shadertype, ShaderPrecisionType precisiontype, [Out] int[] range, out int precision)
        {
            unsafe
            {
                fixed (int* range_ptr = range, precision_ptr = &precision)
                {
                    glGetShaderPrecisionFormat((GLenum)shadertype, (GLenum)precisiontype, range_ptr, precision_ptr);
                }
            }
        }
        #endregion
        #region glDepthRangef
        private delegate void glDepthRangefDelegate(GLfloat n, GLfloat f);
        private static glDepthRangefDelegate glDepthRangef = null;
        public static void DepthRange(float n, float f)
        {
            glDepthRangef(n, f);
        }
        #endregion
        #region glClearDepthf
        private delegate void glClearDepthfDelegate(GLfloat d);
        private static glClearDepthfDelegate glClearDepthf = null;
        public static void ClearDepth(float d)
        {
            glClearDepthf(d);
        }
        #endregion
        #region glGetProgramBinary
        private unsafe delegate void glGetProgramBinaryDelegate(GLuint program, GLsizei bufSize, GLsizei* length, GLenum* binaryFormat, IntPtr binary);
        private static glGetProgramBinaryDelegate glGetProgramBinary = null;
        public static void GetProgramBinary(int program, int bufSize, out int length, out ShaderBinaryFormat binaryFormat, IntPtr binary)
        {
            unsafe
            {
                fixed (int* length_ptr = &length)
                fixed (ShaderBinaryFormat* binaryFormat_ptr = &binaryFormat)
                {
                    glGetProgramBinary((GLuint)program, bufSize, length_ptr, (GLenum*)binaryFormat_ptr, binary);
                }
            }
        }
        #endregion
        #region glProgramBinary
        private delegate void glProgramBinaryDelegate(GLuint program, GLenum binaryFormat, IntPtr binary, GLsizei length);
        private static glProgramBinaryDelegate glProgramBinary = null;
        public static void ProgramBinary(int program, ShaderBinaryFormat binaryFormat, IntPtr binary, int length)
        {
            glProgramBinary((GLuint)program, (GLenum)binaryFormat, binary, length);
        }
        #endregion
        #region glProgramParameteri
        private delegate void glProgramParameteriDelegate(GLuint program, GLenum pname, GLint value);
        private static glProgramParameteriDelegate glProgramParameteri = null;
        private static void ProgramParameter(int program, ProgramParameterParamName pname, int value)
        {
            glProgramParameteri((GLuint)program, (GLenum)pname, value);
        }
        #endregion
        #region glUseProgramStages
        private delegate void glUseProgramStagesDelegate(GLuint pipeline, GLbitfield stages, GLuint program);
        private static glUseProgramStagesDelegate glUseProgramStages = null;
        public static void UseProgramStages(int pipeline, ProgramStageMask stages, int program)
        {
            glUseProgramStages((GLuint)pipeline, (GLbitfield)stages, (GLuint)program);
        }
        #endregion
        #region glActiveShaderProgram
        private delegate void glActiveShaderProgramDelegate(GLuint pipeline, GLuint program);
        private static glActiveShaderProgramDelegate glActiveShaderProgram = null;
        public static void ActiveShaderProgram(int pipeline, int program)
        {
            glActiveShaderProgram((GLuint) pipeline, (GLuint) program);
        }
        #endregion
        #region glCreateShaderProgramv
        private delegate GLuint glCreateShaderProgramvDelegate(GLenum type, GLsizei count, string[] strings);
        private static glCreateShaderProgramvDelegate glCreateShaderProgramv = null;
        public static int CreateShaderProgram(ShaderType type, int count, string[] strings)
        {
            return (int)glCreateShaderProgramv((GLenum)type, count, strings);
        }
        #endregion
        #region glBindProgramPipeline
        private delegate void glBindProgramPipelineDelegate(GLuint pipeline);
        private static glBindProgramPipelineDelegate glBindProgramPipeline = null;
        public static void BindProgramPipeline(int pipeline)
        {
            glBindProgramPipeline((GLuint) pipeline);
        }
        #endregion
        #region glDeleteProgramPipelines
        private unsafe delegate void glDeleteProgramPipelinesDelegate(GLsizei n, GLuint* pipelines);
        private static glDeleteProgramPipelinesDelegate glDeleteProgramPipelines = null;
        public static void DeleteProgramPipelines(int n, ref int pipelines)
        {
            unsafe
            {
                fixed (int* pipelines_ptr = &pipelines)
                {
                    glDeleteProgramPipelines(n, (GLuint*)pipelines_ptr);
                }
            }
        }
        public static void DeleteProgramPipelines(int n, int[] pipelines)
        {
            unsafe
            {
                fixed (int* pipelines_ptr = pipelines)
                {
                    glDeleteProgramPipelines(n, (GLuint*)pipelines_ptr);
                }
            }
        }
        #endregion
        #region glGenProgramPipelines
        private unsafe delegate void glGenProgramPipelinesDelegate(GLsizei n, GLuint* pipelines);
        private static glGenProgramPipelinesDelegate glGenProgramPipelines = null;
        public static void GenProgramPipelines(int n, out int pipelines)
        {
            unsafe
            {
                fixed (int* pipelines_ptr = &pipelines)
                {
                    glGenProgramPipelines(n, (GLuint*)pipelines_ptr);
                }
            }
        }
        public static void GenProgramPipelines(int n, [Out] int[] pipelines)
        {
            unsafe
            {
                fixed (int* pipelines_ptr = pipelines)
                {
                    glGenProgramPipelines(n, (GLuint*)pipelines_ptr);
                }
            }
        }
        #endregion
        #region glIsProgramPipeline
        private delegate GLboolean glIsProgramPipelineDelegate(GLuint pipeline);
        private static glIsProgramPipelineDelegate glIsProgramPipeline = null;
        public static bool IsProgramPipeline(int pipeline)
        {
            return glIsProgramPipeline((GLuint)pipeline);
        }
        #endregion
        #region glGetProgramPipelineiv
        private unsafe delegate void glGetProgramPipelineivDelegate(GLuint pipeline, GLenum pname, GLint* param);
        private static glGetProgramPipelineivDelegate glGetProgramPipelineiv = null;
        public static void GetProgramPipeline(int pipeline, ProgramPipelineParamName pname, out int param)
        {
            unsafe
            {
                fixed (int* param_ptr = &param)
                {
                    glGetProgramPipelineiv((GLuint)pipeline, (GLenum)pname, param_ptr);
                }
            }
        }
        public static void GetProgramPipeline(int pipeline, ProgramPipelineParamName pname, [Out] int[] param)
        {
            unsafe
            {
                fixed (int* param_ptr = param)
                {
                    glGetProgramPipelineiv((GLuint)pipeline, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniform1i
        private delegate void glProgramUniform1iDelegate(GLuint program, GLint location, GLint v0);
        private static glProgramUniform1iDelegate glProgramUniform1i = null;
        public static void ProgramUniform1(int program, int location, int v0)
        {
            glProgramUniform1i((GLuint)program, location, v0);
        }
        #endregion
        #region glProgramUniform1iv
        private unsafe delegate void glProgramUniform1ivDelegate(GLuint program, GLint location, GLsizei count, GLint* value);
        private static glProgramUniform1ivDelegate glProgramUniform1iv = null;
        public static void ProgramUniform1(int program, int location, int count, int[] value)
        {
            unsafe
            {
                fixed (int* value_ptr = value)
                {
                    glProgramUniform1iv((GLuint)program, location, count, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniform1f
        private delegate void glProgramUniform1fDelegate(GLuint program, GLint location, GLfloat v0);
        private static glProgramUniform1fDelegate glProgramUniform1f = null;
        public static void ProgramUniform1(int program, int location, float v0)
        {
            glProgramUniform1f((GLuint)program, location, v0);
        }
        #endregion
        #region glProgramUniform1fv
        private unsafe delegate void glProgramUniform1fvDelegate(GLuint program, GLint location, GLsizei count, GLfloat* value);
        private static glProgramUniform1fvDelegate glProgramUniform1fv = null;
        public static void ProgramUniform1(int program, int location, int count, float[] value)
        {
            unsafe
            {
                fixed (float* value_ptr = value)
                {
                    glProgramUniform1fv((GLuint)program, location, count, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniform1d
        private delegate void glProgramUniform1dDelegate(GLuint program, GLint location, GLdouble v0);
        private static glProgramUniform1dDelegate glProgramUniform1d = null;
        public static void ProgramUniform1(int program, int location, double v0)
        {
            glProgramUniform1d((GLuint)program, location, v0);
        }
        #endregion
        #region glProgramUniform1dv
        private unsafe delegate void glProgramUniform1dvDelegate(GLuint program, GLint location, GLsizei count, GLdouble* value);
        private static glProgramUniform1dvDelegate glProgramUniform1dv = null;
        public static void ProgramUniform1(int program, int location, int count, double[] value)
        {
            unsafe
            {
                fixed (double* value_ptr = value)
                {
                    glProgramUniform1dv((GLuint)program, location, count, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniform1ui
        private delegate void glProgramUniform1uiDelegate(GLuint program, GLint location, GLuint v0);
        private static glProgramUniform1uiDelegate glProgramUniform1ui = null;
        public static void ProgramUniform1(int program, int location, uint v0)
        {
            glProgramUniform1ui((GLuint)program, location, v0);
        }
        #endregion
        #region glProgramUniform1uiv
        private unsafe delegate void glProgramUniform1uivDelegate(GLuint program, GLint location, GLsizei count, GLuint* value);
        private static glProgramUniform1uivDelegate glProgramUniform1uiv = null;
        public static void ProgramUniform1(int program, int location, int count, uint[] value)
        {
            unsafe
            {
                fixed (uint* value_ptr = value)
                {
                    glProgramUniform1uiv((GLuint)program, location, count, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniform2i
        private delegate void glProgramUniform2iDelegate(GLuint program, GLint location, GLint v0, GLint v1);
        private static glProgramUniform2iDelegate glProgramUniform2i = null;
        public static void ProgramUniform2(int program, int location, int v0, int v1)
        {
            glProgramUniform2i((GLuint)program, location, v0, v1);
        }
        #endregion
        #region glProgramUniform2iv
        private unsafe delegate void glProgramUniform2ivDelegate(GLuint program, GLint location, GLsizei count, GLint* value);
        private static glProgramUniform2ivDelegate glProgramUniform2iv = null;
        public static void ProgramUniform2(int program, int location, int count, int[] value)
        {
            unsafe
            {
                fixed (int* value_ptr = value)
                {
                    glProgramUniform2iv((GLuint)program, location, count, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniform2f
        private delegate void glProgramUniform2fDelegate(GLuint program, GLint location, GLfloat v0, GLfloat v1);
        private static glProgramUniform2fDelegate glProgramUniform2f = null;
        public static void ProgramUniform2(int program, int location, float v0, float v1)
        {
            glProgramUniform2f((GLuint)program, location, v0, v1);
        }
        #endregion
        #region glProgramUniform2fv
        private unsafe delegate void glProgramUniform2fvDelegate(GLuint program, GLint location, GLsizei count, GLfloat* value);
        private static glProgramUniform2fvDelegate glProgramUniform2fv = null;
        public static void ProgramUniform2(int program, int location, int count, float[] value)
        {
            unsafe
            {
                fixed (float* value_ptr = value)
                {
                    glProgramUniform2fv((GLuint)program, location, count, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniform2d
        private delegate void glProgramUniform2dDelegate(GLuint program, GLint location, GLdouble v0, GLdouble v1);
        private static glProgramUniform2dDelegate glProgramUniform2d = null;
        public static void ProgramUniform2(int program, int location, double v0, double v1)
        {
            glProgramUniform2d((GLuint)program, location, v0, v1);
        }
        #endregion
        #region glProgramUniform2dv
        private unsafe delegate void glProgramUniform2dvDelegate(GLuint program, GLint location, GLsizei count, GLdouble* value);
        private static glProgramUniform2dvDelegate glProgramUniform2dv = null;
        public static void ProgramUniform2(int program, int location, int count, double[] value)
        {
            unsafe
            {
                fixed (double* value_ptr = value)
                {
                    glProgramUniform2dv((GLuint)program, location, count, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniform2ui
        private delegate void glProgramUniform2uiDelegate(GLuint program, GLint location, GLuint v0, GLuint v1);
        private static glProgramUniform2uiDelegate glProgramUniform2ui = null;
        public static void ProgramUniform2(int program, int location, uint v0, uint v1)
        {
            glProgramUniform2ui((GLuint)program, location, v0, v1);
        }
        #endregion
        #region glProgramUniform2uiv
        private unsafe delegate void glProgramUniform2uivDelegate(GLuint program, GLint location, GLsizei count, GLuint* value);
        private static glProgramUniform2uivDelegate glProgramUniform2uiv = null;
        public static void ProgramUniform2(int program, int location, int count, uint[] value)
        {
            unsafe
            {
                fixed (uint* value_ptr = value)
                {
                    glProgramUniform2uiv((GLuint)program, location, count, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniform3i
        private delegate void glProgramUniform3iDelegate(GLuint program, GLint location, GLint v0, GLint v1, GLint v2);
        private static glProgramUniform3iDelegate glProgramUniform3i = null;
        public static void ProgramUniform3(int program, int location, int v0, int v1, int v2)
        {
            glProgramUniform3i((GLuint)program, location, v0, v1, v2);
        }
        #endregion
        #region glProgramUniform3iv
        private unsafe delegate void glProgramUniform3ivDelegate(GLuint program, GLint location, GLsizei count, GLint* value);
        private static glProgramUniform3ivDelegate glProgramUniform3iv = null;
        public static void ProgramUniform3(int program, int location, int count, int[] value)
        {
            unsafe
            {
                fixed (int* value_ptr = value)
                {
                    glProgramUniform3iv((GLuint)program, location, count, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniform3f
        private delegate void glProgramUniform3fDelegate(GLuint program, GLint location, GLfloat v0, GLfloat v1, GLfloat v2);
        private static glProgramUniform3fDelegate glProgramUniform3f = null;
        public static void ProgramUniform3(int program, int location, float v0, float v1, float v2)
        {
            glProgramUniform3f((GLuint)program, location, v0, v1, v2);
        }
        #endregion
        #region glProgramUniform3fv
        private unsafe delegate void glProgramUniform3fvDelegate(GLuint program, GLint location, GLsizei count, GLfloat* value);
        private static glProgramUniform3fvDelegate glProgramUniform3fv = null;
        public static void ProgramUniform3(int program, int location, int count, float[] value)
        {
            unsafe
            {
                fixed (float* value_ptr = value)
                {
                    glProgramUniform3fv((GLuint)program, location, count, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniform3d
        private delegate void glProgramUniform3dDelegate(GLuint program, GLint location, GLdouble v0, GLdouble v1, GLdouble v2);
        private static glProgramUniform3dDelegate glProgramUniform3d = null;
        public static void ProgramUniform3(int program, int location, double v0, double v1, double v2)
        {
            glProgramUniform3d((GLuint)program, location, v0, v1, v2);
        }
        #endregion
        #region glProgramUniform3dv
        private unsafe delegate void glProgramUniform3dvDelegate(GLuint program, GLint location, GLsizei count, GLdouble* value);
        private static glProgramUniform3dvDelegate glProgramUniform3dv = null;
        public static void ProgramUniform3(int program, int location, int count, double[] value)
        {
            unsafe
            {
                fixed (double* value_ptr = value)
                {
                    glProgramUniform3dv((GLuint)program, location, count, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniform3ui
        private delegate void glProgramUniform3uiDelegate(GLuint program, GLint location, GLuint v0, GLuint v1, GLuint v2);
        private static glProgramUniform3uiDelegate glProgramUniform3ui = null;
        public static void ProgramUniform3(int program, int location, uint v0, uint v1, uint v2)
        {
            glProgramUniform3ui((GLuint)program, location, v0, v1, v2);
        }
        #endregion
        #region glProgramUniform3uiv
        private unsafe delegate void glProgramUniform3uivDelegate(GLuint program, GLint location, GLsizei count, GLuint* value);
        private static glProgramUniform3uivDelegate glProgramUniform3uiv = null;
        public static void ProgramUniform3(int program, int location, int count, uint[] value)
        {
            unsafe
            {
                fixed (uint* value_ptr = value)
                {
                    glProgramUniform3uiv((GLuint)program, location, count, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniform4i
        private delegate void glProgramUniform4iDelegate(GLuint program, GLint location, GLint v0, GLint v1, GLint v2, GLint v3);
        private static glProgramUniform4iDelegate glProgramUniform4i = null;
        public static void ProgramUniform4(int program, int location, int v0, int v1, int v2, int v3)
        {
            glProgramUniform4i((GLuint)program, location, v0, v1, v2, v3);
        }
        #endregion
        #region glProgramUniform4iv
        private unsafe delegate void glProgramUniform4ivDelegate(GLuint program, GLint location, GLsizei count, GLint* value);
        private static glProgramUniform4ivDelegate glProgramUniform4iv = null;
        public static void ProgramUniform4(int program, int location, int count, int[] value)
        {
            unsafe
            {
                fixed (int* value_ptr = value)
                {
                    glProgramUniform4iv((GLuint)program, location, count, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniform4f
        private delegate void glProgramUniform4fDelegate(GLuint program, GLint location, GLfloat v0, GLfloat v1, GLfloat v2, GLfloat v3);
        private static glProgramUniform4fDelegate glProgramUniform4f = null;
        public static void ProgramUniform4(int program, int location, float v0, float v1, float v2, float v3)
        {
            glProgramUniform4f((GLuint)program, location, v0, v1, v2, v3);
        }
        #endregion
        #region glProgramUniform4fv
        private unsafe delegate void glProgramUniform4fvDelegate(GLuint program, GLint location, GLsizei count, GLfloat* value);
        private static glProgramUniform4fvDelegate glProgramUniform4fv = null;
        public static void ProgramUniform4(int program, int location, int count, float[] value)
        {
            unsafe
            {
                fixed (float* value_ptr = value)
                {
                    glProgramUniform4fv((GLuint)program, location, count, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniform4d
        private delegate void glProgramUniform4dDelegate(GLuint program, GLint location, GLdouble v0, GLdouble v1, GLdouble v2, GLdouble v3);
        private static glProgramUniform4dDelegate glProgramUniform4d = null;
        public static void ProgramUniform4(int program, int location, double v0, double v1, double v2, double v3)
        {
            glProgramUniform4d((GLuint)program, location, v0, v1, v2, v3);
        }
        #endregion
        #region glProgramUniform4dv
        private unsafe delegate void glProgramUniform4dvDelegate(GLuint program, GLint location, GLsizei count, GLdouble* value);
        private static glProgramUniform4dvDelegate glProgramUniform4dv = null;
        public static void ProgramUniform4(int program, int location, int count, double[] value)
        {
            unsafe
            {
                fixed (double* value_ptr = value)
                {
                    glProgramUniform4dv((GLuint)program, location, count, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniform4ui
        private delegate void glProgramUniform4uiDelegate(GLuint program, GLint location, GLuint v0, GLuint v1, GLuint v2, GLuint v3);
        private static glProgramUniform4uiDelegate glProgramUniform4ui = null;
        public static void ProgramUniform4(int program, int location, uint v0, uint v1, uint v2, uint v3)
        {
            glProgramUniform4ui((GLuint)program, location, v0, v1, v2, v3);
        }
        #endregion
        #region glProgramUniform4uiv
        private unsafe delegate void glProgramUniform4uivDelegate(GLuint program, GLint location, GLsizei count, GLuint* value);
        private static glProgramUniform4uivDelegate glProgramUniform4uiv = null;
        public static void ProgramUniform4(int program, int location, int count, uint[] value)
        {
            unsafe
            {
                fixed (uint* value_ptr = value)
                {
                    glProgramUniform4uiv((GLuint)program, location, count, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniformMatrix2fv
        private unsafe delegate void glProgramUniformMatrix2fvDelegate(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
        private static glProgramUniformMatrix2fvDelegate glProgramUniformMatrix2fv = null;
        public static void ProgramUniformMatrix2(int program, int location, int count, bool transpose, float[] value)
        {
            unsafe
            {
                fixed (float* value_ptr = value)
                {
                    glProgramUniformMatrix2fv((GLuint)program, location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniformMatrix3fv
        private unsafe delegate void glProgramUniformMatrix3fvDelegate(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
        private static glProgramUniformMatrix3fvDelegate glProgramUniformMatrix3fv = null;
        public static void ProgramUniformMatrix3(int program, int location, int count, bool transpose, float[] value)
        {
            unsafe
            {
                fixed (float* value_ptr = value)
                {
                    glProgramUniformMatrix3fv((GLuint)program, location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniformMatrix4fv
        private unsafe delegate void glProgramUniformMatrix4fvDelegate(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
        private static glProgramUniformMatrix4fvDelegate glProgramUniformMatrix4fv = null;
        public static void ProgramUniformMatrix4(int program, int location, int count, bool transpose, float[] value)
        {
            unsafe
            {
                fixed (float* value_ptr = value)
                {
                    glProgramUniformMatrix4fv((GLuint)program, location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniformMatrix2dv
        private unsafe delegate void glProgramUniformMatrix2dvDelegate(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
        private static glProgramUniformMatrix2dvDelegate glProgramUniformMatrix2dv = null;
        public static void ProgramUniformMatrix2(int program, int location, int count, bool transpose, double[] value)
        {
            unsafe
            {
                fixed (double* value_ptr = value)
                {
                    glProgramUniformMatrix2dv((GLuint)program, location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniformMatrix3dv
        private unsafe delegate void glProgramUniformMatrix3dvDelegate(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
        private static glProgramUniformMatrix3dvDelegate glProgramUniformMatrix3dv = null;
        public static void ProgramUniformMatrix3(int program, int location, int count, bool transpose, double[] value)
        {
            unsafe
            {
                fixed (double* value_ptr = value)
                {
                    glProgramUniformMatrix3dv((GLuint)program, location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniformMatrix4dv
        private unsafe delegate void glProgramUniformMatrix4dvDelegate(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
        private static glProgramUniformMatrix4dvDelegate glProgramUniformMatrix4dv = null;
        public static void ProgramUniformMatrix4(int program, int location, int count, bool transpose, double[] value)
        {
            unsafe
            {
                fixed (double* value_ptr = value)
                {
                    glProgramUniformMatrix4dv((GLuint)program, location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniformMatrix2x3fv
        private unsafe delegate void glProgramUniformMatrix2x3fvDelegate(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
        private static glProgramUniformMatrix2x3fvDelegate glProgramUniformMatrix2x3fv = null;
        public static void ProgramUniformMatrix2x3(int program, int location, int count, bool transpose, float[] value)
        {
            unsafe
            {
                fixed (float* value_ptr = value)
                {
                    glProgramUniformMatrix2x3fv((GLuint)program, location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniformMatrix3x2fv
        private unsafe delegate void glProgramUniformMatrix3x2fvDelegate(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
        private static glProgramUniformMatrix3x2fvDelegate glProgramUniformMatrix3x2fv = null;
        public static void ProgramUniformMatrix3x2(int program, int location, int count, bool transpose, float[] value)
        {
            unsafe
            {
                fixed (float* value_ptr = value)
                {
                    glProgramUniformMatrix3x2fv((GLuint)program, location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniformMatrix2x4fv
        private unsafe delegate void glProgramUniformMatrix2x4fvDelegate(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
        private static glProgramUniformMatrix2x4fvDelegate glProgramUniformMatrix2x4fv = null;
        public static void ProgramUniformMatrix2x4(int program, int location, int count, bool transpose, float[] value)
        {
            unsafe
            {
                fixed (float* value_ptr = value)
                {
                    glProgramUniformMatrix2x4fv((GLuint)program, location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniformMatrix4x2fv
        private unsafe delegate void glProgramUniformMatrix4x2fvDelegate(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
        private static glProgramUniformMatrix4x2fvDelegate glProgramUniformMatrix4x2fv = null;
        public static void ProgramUniformMatrix4x2(int program, int location, int count, bool transpose, float[] value)
        {
            unsafe
            {
                fixed (float* value_ptr = value)
                {
                    glProgramUniformMatrix4x2fv((GLuint)program, location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniformMatrix3x4fv
        private unsafe delegate void glProgramUniformMatrix3x4fvDelegate(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
        private static glProgramUniformMatrix3x4fvDelegate glProgramUniformMatrix3x4fv = null;
        public static void ProgramUniformMatrix3x4(int program, int location, int count, bool transpose, float[] value)
        {
            unsafe
            {
                fixed (float* value_ptr = value)
                {
                    glProgramUniformMatrix3x4fv((GLuint)program, location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniformMatrix4x3fv
        private unsafe delegate void glProgramUniformMatrix4x3fvDelegate(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLfloat* value);
        private static glProgramUniformMatrix4x3fvDelegate glProgramUniformMatrix4x3fv = null;
        public static void ProgramUniformMatrix4x3(int program, int location, int count, bool transpose, float[] value)
        {
            unsafe
            {
                fixed (float* value_ptr = value)
                {
                    glProgramUniformMatrix4x3fv((GLuint)program, location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniformMatrix2x3dv
        private unsafe delegate void glProgramUniformMatrix2x3dvDelegate(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
        private static glProgramUniformMatrix2x3dvDelegate glProgramUniformMatrix2x3dv = null;
        public static void ProgramUniformMatrix2x3(int program, int location, int count, bool transpose, double[] value)
        {
            unsafe
            {
                fixed (double* value_ptr = value)
                {
                    glProgramUniformMatrix2x3dv((GLuint)program, location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniformMatrix3x2dv
        private unsafe delegate void glProgramUniformMatrix3x2dvDelegate(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
        private static glProgramUniformMatrix3x2dvDelegate glProgramUniformMatrix3x2dv = null;
        public static void ProgramUniformMatrix3x2(int program, int location, int count, bool transpose, double[] value)
        {
            unsafe
            {
                fixed (double* value_ptr = value)
                {
                    glProgramUniformMatrix3x2dv((GLuint)program, location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniformMatrix2x4dv
        private unsafe delegate void glProgramUniformMatrix2x4dvDelegate(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
        private static glProgramUniformMatrix2x4dvDelegate glProgramUniformMatrix2x4dv = null;
        public static void ProgramUniformMatrix2x4(int program, int location, int count, bool transpose, double[] value)
        {
            unsafe
            {
                fixed (double* value_ptr = value)
                {
                    glProgramUniformMatrix2x4dv((GLuint)program, location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniformMatrix4x2dv
        private unsafe delegate void glProgramUniformMatrix4x2dvDelegate(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
        private static glProgramUniformMatrix4x2dvDelegate glProgramUniformMatrix4x2dv = null;
        public static void ProgramUniformMatrix4x2(int program, int location, int count, bool transpose, double[] value)
        {
            unsafe
            {
                fixed (double* value_ptr = value)
                {
                    glProgramUniformMatrix4x2dv((GLuint)program, location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniformMatrix3x4dv
        private unsafe delegate void glProgramUniformMatrix3x4dvDelegate(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
        private static glProgramUniformMatrix3x4dvDelegate glProgramUniformMatrix3x4dv = null;
        public static void ProgramUniformMatrix3x4(int program, int location, int count, bool transpose, double[] value)
        {
            unsafe
            {
                fixed (double* value_ptr = value)
                {
                    glProgramUniformMatrix3x4dv((GLuint)program, location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glProgramUniformMatrix4x3dv
        private unsafe delegate void glProgramUniformMatrix4x3dvDelegate(GLuint program, GLint location, GLsizei count, GLboolean transpose, GLdouble* value);
        private static glProgramUniformMatrix4x3dvDelegate glProgramUniformMatrix4x3dv = null;
        public static void ProgramUniformMatrix4x3(int program, int location, int count, bool transpose, double[] value)
        {
            unsafe
            {
                fixed (double* value_ptr = value)
                {
                    glProgramUniformMatrix4x3dv((GLuint)program, location, count, transpose, value_ptr);
                }
            }
        }
        #endregion
        #region glValidateProgramPipeline
        private delegate void glValidateProgramPipelineDelegate(GLuint pipeline);
        private static glValidateProgramPipelineDelegate glValidateProgramPipeline = null;
        private static void ValidateProgramPipeline(int pipeline)
        {
            glValidateProgramPipeline((GLuint)pipeline);
        }
        #endregion
        #region glGetProgramPipelineInfoLog
        private unsafe delegate void glGetProgramPipelineInfoLogDelegate(GLuint pipeline, GLsizei bufSize, GLsizei* length, StringBuilder infoLog);
        private static glGetProgramPipelineInfoLogDelegate glGetProgramPipelineInfoLog = null;
        public static void GetProgramPipelineInfoLog(int pipeline, int bufSize, out int length, StringBuilder infoLog)
        {
            unsafe
            {
                fixed (int* length_ptr = &length)
                {
                    glGetProgramPipelineInfoLog((GLuint) pipeline,  bufSize,  length_ptr,  infoLog);
                }
            }
        }
        #endregion
        #region glVertexAttribL1d
        private delegate void glVertexAttribL1dDelegate(GLuint index, GLdouble x);
        private static glVertexAttribL1dDelegate glVertexAttribL1d = null;
        public static void VertexAttribL1(int index, double x)
        {
            glVertexAttribL1d((GLuint)index, x);
        }
        #endregion
        #region glVertexAttribL2d
        private delegate void glVertexAttribL2dDelegate(GLuint index, GLdouble x, GLdouble y);
        private static glVertexAttribL2dDelegate glVertexAttribL2d = null;
        public static void VertexAttribL2(int index, double x, double y)
        {
            glVertexAttribL2d((GLuint)index, x, y);
        }
        #endregion
        #region glVertexAttribL3d
        private delegate void glVertexAttribL3dDelegate(GLuint index, GLdouble x, GLdouble y, GLdouble z);
        private static glVertexAttribL3dDelegate glVertexAttribL3d = null;
        public static void VertexAttribL3(int index, double x, double y, double z)
        {
            glVertexAttribL3d((GLuint)index, x, y, z);
        }
        #endregion
        #region glVertexAttribL4d
        private delegate void glVertexAttribL4dDelegate(GLuint index, GLdouble x, GLdouble y, GLdouble z, GLdouble w);
        private static glVertexAttribL4dDelegate glVertexAttribL4d = null;
        public static void VertexAttribL4(int index, double x, double y, double z, double w)
        {
            glVertexAttribL4d((GLuint)index, x, y, z, w);
        }
        #endregion
        #region glVertexAttribL1dv
        private unsafe delegate void glVertexAttribL1dvDelegate(GLuint index, GLdouble* v);
        private static glVertexAttribL1dvDelegate glVertexAttribL1dv = null;
        public static void VertexAttribL1(int index, ref double v)
        {
            unsafe
            {
                fixed (double* v_ptr = &v)
                {
                    glVertexAttribL1dv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttribL2dv
        private unsafe delegate void glVertexAttribL2dvDelegate(GLuint index, GLdouble* v);
        private static glVertexAttribL2dvDelegate glVertexAttribL2dv = null;
        public static void VertexAttribL2(int index, double[] v)
        {
            unsafe
            {
                fixed (double* v_ptr = v)
                {
                    glVertexAttribL2dv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttribL3dv
        private unsafe delegate void glVertexAttribL3dvDelegate(GLuint index, GLdouble* v);
        private static glVertexAttribL3dvDelegate glVertexAttribL3dv = null;
        public static void VertexAttribL3(int index, double[] v)
        {
            unsafe
            {
                fixed (double* v_ptr = v)
                {
                    glVertexAttribL3dv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttribL4dv
        private unsafe delegate void glVertexAttribL4dvDelegate(GLuint index, GLdouble* v);
        private static glVertexAttribL4dvDelegate glVertexAttribL4dv = null;
        public static void VertexAttribL4(int index, double[] v)
        {
            unsafe
            {
                fixed (double* v_ptr = v)
                {
                    glVertexAttribL4dv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glVertexAttribLPointer
        private delegate void glVertexAttribLPointerDelegate(GLuint index, GLint size, GLenum type, GLsizei stride, IntPtr pointer);
        private static glVertexAttribLPointerDelegate glVertexAttribLPointer = null;
        public static void VertexAttribLPointer(int index, int size, VertexAttribType type, int stride, IntPtr pointer)
        {
            glVertexAttribLPointer((GLuint)index, size, (GLenum)type, stride, pointer);
        }
        public static void VertexAttribLPointer(int index, int size, VertexAttribType type, int stride, int offset)
        {
            glVertexAttribLPointer((GLuint)index, size, (GLenum)type, stride, (IntPtr)offset);
        }
        #endregion
        #region glGetVertexAttribLdv
        private unsafe delegate void glGetVertexAttribLdvDelegate(GLuint index, GLenum pname, GLdouble* param);
        private static glGetVertexAttribLdvDelegate glGetVertexAttribLdv = null;
        public static void GetVertexAttribL(int index, VertexAttribParamName pname, [Out] double[] v)
        {
            unsafe
            {
                fixed (double* v_ptr = v)
                {
                    glGetVertexAttribLdv((GLuint)index, (GLenum)pname, v_ptr);
                }
            }
        }
        #endregion
        #region glViewportArrayv
        private unsafe delegate void glViewportArrayvDelegate(GLuint first, GLsizei count, GLfloat* v);
        private static glViewportArrayvDelegate glViewportArrayv = null;
        public static void ViewportArray(int first, int count, float[] v)
        {
            unsafe
            {
                fixed (float* v_ptr = v)
                {
                    glViewportArrayv((GLuint) first, count, v_ptr);
                }
            }
        }
        #endregion
        #region glViewportIndexedf
        private delegate void glViewportIndexedfDelegate(GLuint index, GLfloat x, GLfloat y, GLfloat w, GLfloat h);
        private static glViewportIndexedfDelegate glViewportIndexedf = null;
        public static void ViewportIndexed(int index, float x, float y, float w, float h)
        {
            glViewportIndexedf((GLuint)index, x, y, w, h);
        }
        #endregion
        #region glViewportIndexedfv
        private unsafe delegate void glViewportIndexedfvDelegate(GLuint index, GLfloat* v);
        private static glViewportIndexedfvDelegate glViewportIndexedfv = null;
        public static void ViewportIndexed(int index, float[] v)
        {
            unsafe
            {
                fixed (float* v_ptr = v)
                {
                    glViewportIndexedfv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glScissorArrayv
        private unsafe delegate void glScissorArrayvDelegate(GLuint first, GLsizei count, GLint* v);
        private static glScissorArrayvDelegate glScissorArrayv = null;
        public static void ScissorArray(int first, int count, int[] v)
        {
            unsafe
            {
                fixed (int* v_ptr = v)
                {
                    glScissorArrayv((GLuint)first, count, v_ptr);
                }
            }
        }
        #endregion
        #region glScissorIndexed
        private delegate void glScissorIndexedDelegate(GLuint index, GLint left, GLint bottom, GLsizei width, GLsizei height);
        private static glScissorIndexedDelegate glScissorIndexed = null;
        public static void ScissorIndexed(int index, int left, int bottom, int width, int height)
        {
            glScissorIndexed((GLuint)index, left, bottom, width, height);
        }
        #endregion
        #region glScissorIndexedv
        private unsafe delegate void glScissorIndexedvDelegate(GLuint index, GLint* v);
        private static glScissorIndexedvDelegate glScissorIndexedv = null;
        public static void ScissorIndexed(int index, int[] v)
        {
            unsafe
            {
                fixed (int* v_ptr = v)
                {
                    glScissorIndexedv((GLuint)index, v_ptr);
                }
            }
        }
        #endregion
        #region glDepthRangeArrayv
        private unsafe delegate void glDepthRangeArrayvDelegate(GLuint first, GLsizei count, GLdouble* v);
        private static glDepthRangeArrayvDelegate glDepthRangeArrayv = null;
        public static void DepthRangeArray(int first, int count, double[] v)
        {
            unsafe
            {
                fixed (double* v_ptr = v)
                {
                    glDepthRangeArrayv((GLuint)first, count, v_ptr);
                }
            }
        }
        #endregion
        #region glDepthRangeIndexed
        private delegate void glDepthRangeIndexedDelegate(GLuint index, GLdouble n, GLdouble f);
        private static glDepthRangeIndexedDelegate glDepthRangeIndexed = null;
        public static void DepthRangeIndexed(int index, double n, double f)
        {
            glDepthRangeIndexed((GLuint)index, n, f);
        }
        #endregion
        #region glGetFloati_v
        private unsafe delegate void glGetFloati_vDelegate(GLenum target, GLuint index, GLfloat* data);
        private static glGetFloati_vDelegate glGetFloati_v = null;
        public static void GetFloat(GetParamName pname, int index, out float data)
        {
            unsafe
            {
                fixed (float* data_ptr = &data)
                {
                    glGetFloati_v((GLenum)pname, (GLuint)index, data_ptr);
                }
            }
        }
        public static void GetFloat(GetParamName pname, int index, [Out] float[] data)
        {
            unsafe
            {
                fixed (float* data_ptr = data)
                {
                    glGetFloati_v((GLenum)pname, (GLuint)index, data_ptr);
                }
            }
        }
        #endregion
        #region glGetDoublei_v
        private unsafe delegate void glGetDoublei_vDelegate(GLenum target, GLuint index, GLdouble* data);
        private static glGetDoublei_vDelegate glGetDoublei_v = null;
        public static void GetDouble(GetParamName pname, int index, out double data)
        {
            unsafe
            {
                fixed (double* data_ptr = &data)
                {
                    glGetDoublei_v((GLenum)pname, (GLuint)index, data_ptr);
                }
            }
        }
        public static void GetDouble(GetParamName pname, int index, [Out] double[] data)
        {
            unsafe
            {
                fixed (double* data_ptr = data)
                {
                    glGetDoublei_v((GLenum)pname, (GLuint)index, data_ptr);
                }
            }
        }
        #endregion
        #endregion
        #region OPENGL 4.2
        #region glDrawArraysInstancedBaseInstance
        private delegate void glDrawArraysInstancedBaseInstanceDelegate(GLenum mode, GLint first, GLsizei count, GLsizei instancecount, GLuint baseinstance);
        private static glDrawArraysInstancedBaseInstanceDelegate glDrawArraysInstancedBaseInstance = null;
        public static void DrawArraysInstancedBaseInstance(DrawMode mode, int first, int count, int instancecount, int baseinstance)
        {
            glDrawArraysInstancedBaseInstance((GLenum)mode, first, count, instancecount, (GLuint)baseinstance);
        }
        #endregion
        #region glDrawElementsInstancedBaseInstance
        private delegate void glDrawElementsInstancedBaseInstanceDelegate(GLenum mode, GLsizei count, GLenum type, IntPtr indices, GLsizei instancecount, GLuint baseinstance);
        private static glDrawElementsInstancedBaseInstanceDelegate glDrawElementsInstancedBaseInstance = null;
        public static void DrawElementsInstancedBaseInstance(DrawMode mode, int count, DrawElementsType type, IntPtr indices, int instancecount, int baseinstance)
        {
            glDrawElementsInstancedBaseInstance((GLenum)mode, count, (GLenum)type, indices, instancecount, (GLuint)baseinstance);
        }
        #endregion
        #region glDrawElementsInstancedBaseVertexBaseInstance
        private delegate void glDrawElementsInstancedBaseVertexBaseInstanceDelegate(GLenum mode, GLsizei count, GLenum type, IntPtr indices, GLsizei instancecount, GLint basevertex, GLuint baseinstance);
        private static glDrawElementsInstancedBaseVertexBaseInstanceDelegate glDrawElementsInstancedBaseVertexBaseInstance = null;
        public static void DrawElementsInstancedBaseVertexBaseInstance(DrawMode mode, int count, DrawElementsType type, IntPtr indices, int instancecount, int basevertex, int baseinstance)
        {
            glDrawElementsInstancedBaseVertexBaseInstance((GLenum)mode, count, (GLenum)type, indices, instancecount, basevertex, (GLuint)baseinstance);
        }
        #endregion
        #region glGetInternalformativ
        private unsafe delegate void glGetInternalformativDelegate(GLenum target, GLenum internalformat, GLenum pname, GLsizei bufSize, GLint* param);
        private static glGetInternalformativDelegate glGetInternalformativ = null;
        public static void GetInternalformat(TextureTarget target, PixelInternalFormat internalformat, InternalformatParamName pname, int bufSize, out int param)
        {
            unsafe
            {
                fixed (int* param_ptr = &param)
                {
                    glGetInternalformativ((GLenum)target, (GLenum)internalformat, (GLenum)pname, bufSize, param_ptr);
                }
            }
        }
        #endregion
        #region glGetActiveAtomicCounterBufferiv
        private unsafe delegate void glGetActiveAtomicCounterBufferivDelegate(GLuint program, GLuint bufferIndex, GLenum pname, GLint* param);
        private static glGetActiveAtomicCounterBufferivDelegate glGetActiveAtomicCounterBufferiv = null;
        public static void GetActiveAtomicCounterBuffer(int program, int bufferIndex, ActiveAtomicCounterParamName pname, out int param)
        {
            unsafe
            {
                fixed (int* param_ptr = &param)
                {
                    glGetActiveAtomicCounterBufferiv((GLuint)program, (GLuint)bufferIndex, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glBindImageTexture
        private delegate void glBindImageTextureDelegate(GLuint unit, GLuint texture, GLint level, GLboolean layered, GLint layer, GLenum access, GLenum format);
        private static glBindImageTextureDelegate glBindImageTexture = null;
        public static void BindImageTexture(int unit, int texture, int level, bool layered, int layer, BufferAccess access, PixelFormat format)
        {
            glBindImageTexture((GLuint)unit, (GLuint)texture, level, layered, layer, (GLenum)access, (GLenum)format);
        }
        #endregion
        #region glMemoryBarrier
        private delegate void glMemoryBarrierDelegate(GLbitfield barriers);
        private static glMemoryBarrierDelegate glMemoryBarrier = null;
        public static void MemoryBarrier(MemoryBarrierMask barriers)
        {
            glMemoryBarrier((GLbitfield)barriers);
        }
        #endregion
        #region glTexStorage1D
        private delegate void glTexStorage1DDelegate(GLenum target, GLsizei levels, GLenum internalformat, GLsizei width);
        private static glTexStorage1DDelegate glTexStorage1D = null;
        public static void TexStorage1D(TextureTarget target, int levels, PixelInternalFormat internalformat, int width)
        {
            glTexStorage1D((GLenum)target, levels, (GLenum)internalformat, width);
        }
        #endregion
        #region glTexStorage2D
        private delegate void glTexStorage2DDelegate(GLenum target, GLsizei levels, GLenum internalformat, GLsizei width, GLsizei height);
        private static glTexStorage2DDelegate glTexStorage2D = null;
        public static void TexStorage2D(TextureTarget target, int levels, PixelInternalFormat internalformat, int width, int height)
        {
            glTexStorage2D((GLenum)target, levels, (GLenum)internalformat, width, height);
        }
        #endregion
        #region glTexStorage3D
        private delegate void glTexStorage3DDelegate(GLenum target, GLsizei levels, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth);
        private static glTexStorage3DDelegate glTexStorage3D = null;
        public static void TexStorage3D(TextureTarget target, int levels, PixelInternalFormat internalformat, int width, int height, int depth)
        {
            glTexStorage3D((GLenum)target, levels, (GLenum)internalformat, width, height, depth);
        }
        #endregion
        #region glDrawTransformFeedbackInstanced
        private delegate void glDrawTransformFeedbackInstancedDelegate(GLenum mode, GLuint id, GLsizei instancecount);
        private static glDrawTransformFeedbackInstancedDelegate glDrawTransformFeedbackInstanced = null;
        public static void DrawTransformFeedbackInstanced(DrawMode mode, int id, int instancecount)
        {
            glDrawTransformFeedbackInstanced((GLenum)mode, (GLuint)id, instancecount);
        }
        #endregion
        #region glDrawTransformFeedbackStreamInstanced
        private delegate void glDrawTransformFeedbackStreamInstancedDelegate(GLenum mode, GLuint id, GLuint stream, GLsizei instancecount);
        private static glDrawTransformFeedbackStreamInstancedDelegate glDrawTransformFeedbackStreamInstanced = null;
        public static void DrawTransformFeedbackStreamInstanced(DrawMode mode, int id, int stream, int instancecount)
        {
            glDrawTransformFeedbackStreamInstanced((GLenum)mode, (GLuint)id, (GLuint)stream, instancecount);
        }
        #endregion
        #endregion
        #region OPENGL 4.3
        #region glClearBufferData
        private delegate void glClearBufferDataDelegate(GLenum target, GLenum internalformat, GLenum format, GLenum type, IntPtr data);
        private static glClearBufferDataDelegate glClearBufferData = null;
        public static void ClearBufferData(BufferTarget target, PixelInternalFormat internalformat, PixelFormat format, PixelType type, IntPtr data)
        {
            glClearBufferData((GLenum)target, (GLenum)internalformat, (GLenum)format, (GLenum)type, data);
        }
        #endregion
        #region glClearBufferSubData
        private delegate void glClearBufferSubDataDelegate(GLenum target, GLenum internalformat, GLintptr offset, GLsizeiptr size, GLenum format, GLenum type, IntPtr data);
        private static glClearBufferSubDataDelegate glClearBufferSubData = null;
        public static void ClearBufferSubData(BufferTarget target, PixelInternalFormat internalformat, IntPtr offset, IntPtr size, PixelFormat format, PixelType type, IntPtr data)
        {
            glClearBufferSubData((GLenum)target, (GLenum)internalformat, offset, size, (GLenum)format, (GLenum)type, data);
        }
        #endregion
        #region glDispatchCompute
        private delegate void glDispatchComputeDelegate(GLuint num_groups_x, GLuint num_groups_y, GLuint num_groups_z);
        private static glDispatchComputeDelegate glDispatchCompute = null;
        public static void DispatchCompute(int num_groups_x, int num_groups_y, int num_groups_z)
        {
            glDispatchCompute((GLuint)num_groups_x, (GLuint)num_groups_y, (GLuint)num_groups_z);
        }
        #endregion
        #region glDispatchComputeIndirect
        private delegate void glDispatchComputeIndirectDelegate(GLintptr indirect);
        private static glDispatchComputeIndirectDelegate glDispatchComputeIndirect = null;
        public static void DispatchComputeIndirect(IntPtr indirect)
        {
            glDispatchComputeIndirect(indirect);
        }
        #endregion
        #region glCopyImageSubData
        private delegate void glCopyImageSubDataDelegate(GLuint srcName, GLenum srcTarget, GLint srcLevel, GLint srcX, GLint srcY, GLint srcZ, GLuint dstName, GLenum dstTarget, GLint dstLevel, GLint dstX, GLint dstY, GLint dstZ, GLsizei srcWidth, GLsizei srcHeight, GLsizei srcDepth);
        private static glCopyImageSubDataDelegate glCopyImageSubData = null;
        public static void CopyImageSubData(int srcName, TextureTarget srcTarget, int srcLevel, int srcX, int srcY, int srcZ, int dstName, TextureTarget dstTarget, int dstLevel, int dstX, int dstY, int dstZ, int srcWidth, int srcHeight, int srcDepth)
        {
            glCopyImageSubData((GLuint)srcName, (GLenum)srcTarget, srcLevel, srcX, srcY, srcZ, (GLuint)dstName, (GLenum)dstTarget, dstLevel, dstX, dstY, dstZ, srcWidth, srcHeight, srcDepth);
        }
        #endregion
        #region glFramebufferParameteri
        private delegate void glFramebufferParameteriDelegate(GLenum target, GLenum pname, GLint param);
        private static glFramebufferParameteriDelegate glFramebufferParameteri = null;
        public static void FramebufferParameter(FramebufferTarget target, FramebufferParamName pname, int param)
        {
            glFramebufferParameteri((GLenum)target, (GLenum)pname, param);
        }
        #endregion
        #region glGetFramebufferParameteriv
        private unsafe delegate void glGetFramebufferParameterivDelegate(GLenum target, GLenum pname, GLint* param);
        private static glGetFramebufferParameterivDelegate glGetFramebufferParameteriv = null;
        public static void GetFramebufferParameter(FramebufferTarget target, FramebufferParamName pname, out int param)
        {
            unsafe
            {
                fixed (int* param_ptr = &param)
                {
                    glGetFramebufferParameteriv((GLenum)target, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glGetInternalformati64v
        private unsafe delegate void glGetInternalformati64vDelegate(GLenum target, GLenum internalformat, GLenum pname, GLsizei bufSize, GLint64* param);
        private static glGetInternalformati64vDelegate glGetInternalformati64v = null;
        public static void GetInternalformat(TextureTarget target, PixelInternalFormat internalformat, InternalformatParamName pname, int bufSize, out long param)
        {
            unsafe
            {
                fixed (long* param_ptr = &param)
                {
                    glGetInternalformati64v((GLenum)target, (GLenum)internalformat, (GLenum)pname, bufSize, param_ptr);
                }
            }
        }
        #endregion
        #region glInvalidateTexSubImage
        private delegate void glInvalidateTexSubImageDelegate(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth);
        private static glInvalidateTexSubImageDelegate glInvalidateTexSubImage = null;
        public static void InvalidateTexSubImage(int texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth)
        {
            glInvalidateTexSubImage((GLuint)texture, level, xoffset, yoffset, zoffset, width, height, depth);
        }
        #endregion
        #region glInvalidateTexImage
        private delegate void glInvalidateTexImageDelegate(GLuint texture, GLint level);
        private static glInvalidateTexImageDelegate glInvalidateTexImage = null;
        public static void InvalidateTexImage(int texture, int level)
        {
            glInvalidateTexImage((GLuint)texture, level);
        }
        #endregion
        #region glInvalidateBufferSubData
        private delegate void glInvalidateBufferSubDataDelegate(GLuint buffer, GLintptr offset, GLsizeiptr length);
        private static glInvalidateBufferSubDataDelegate glInvalidateBufferSubData = null;
        public static void InvalidateBufferSubData(int buffer, IntPtr offset, IntPtr length)
        {
            glInvalidateBufferSubData((GLuint)buffer, offset, length);
        }
        #endregion
        #region glInvalidateBufferData
        private delegate void glInvalidateBufferDataDelegate(GLuint buffer);
        private static glInvalidateBufferDataDelegate glInvalidateBufferData = null;
        public static void InvalidateBufferData(int buffer)
        {
            glInvalidateBufferData((GLuint)buffer);
        }
        #endregion
        #region glInvalidateFramebuffer
        private unsafe delegate void glInvalidateFramebufferDelegate(GLenum target, GLsizei numAttachments, GLenum* attachments);
        private static glInvalidateFramebufferDelegate glInvalidateFramebuffer = null;
        public static void InvalidateFramebuffer(FramebufferTarget target, int numAttachments, FramebufferAttachment[] attachments)
        {
            unsafe
            {
                fixed (FramebufferAttachment* attachments_ptr = attachments)
                {
                    glInvalidateFramebuffer((GLenum)target, numAttachments, (GLenum*)attachments_ptr);
                }
            }
        }
        #endregion
        #region glInvalidateSubFramebuffer
        private unsafe delegate void glInvalidateSubFramebufferDelegate(GLenum target, GLsizei numAttachments, GLenum* attachments, GLint x, GLint y, GLsizei width, GLsizei height);
        private static glInvalidateSubFramebufferDelegate glInvalidateSubFramebuffer = null;
        public static void InvalidateSubFramebuffer(FramebufferTarget target, int numAttachments, FramebufferAttachment[] attachments, int x, int y, int width, int height)
        {
            unsafe
            {
                fixed (FramebufferAttachment* attachments_ptr = attachments)
                {
                    glInvalidateSubFramebuffer((GLenum)target, numAttachments, (GLenum*)attachments_ptr, x, y, width, height);
                }
            }
        }
        #endregion
        #region glMultiDrawArraysIndirect
        private delegate void glMultiDrawArraysIndirectDelegate(GLenum mode, IntPtr indirect, GLsizei drawcount, GLsizei stride);
        private static glMultiDrawArraysIndirectDelegate glMultiDrawArraysIndirect = null;
        public static void MultiDrawArraysIndirect(DrawMode mode, IntPtr indirect, int drawcount, int stride)
        {
            glMultiDrawArraysIndirect((GLenum)mode, indirect, drawcount, stride);
        }
        #endregion
        #region glMultiDrawElementsIndirect
        private delegate void glMultiDrawElementsIndirectDelegate(GLenum mode, GLenum type, IntPtr indirect, GLsizei drawcount, GLsizei stride);
        private static glMultiDrawElementsIndirectDelegate glMultiDrawElementsIndirect = null;
        public static void MultiDrawElementsIndirect(DrawMode mode, DrawElementsType type, IntPtr indirect, int drawcount, int stride)
        {
            glMultiDrawElementsIndirect((GLenum)mode, (GLenum)type, indirect, drawcount, stride);
        }
        #endregion
        #region glGetProgramInterfaceiv
        private unsafe delegate void glGetProgramInterfaceivDelegate(GLuint program, GLenum programInterface, GLenum pname, GLint* param);
        private static glGetProgramInterfaceivDelegate glGetProgramInterfaceiv = null;
        public static void GetProgramInterface(int program, ProgramInterface programInterface, ProgramInterfaceParamName pname, out int param)
        {
            unsafe
            {
                fixed (int* param_ptr = &param)
                {
                    glGetProgramInterfaceiv((GLuint)program, (GLenum)programInterface, (GLenum)pname, param_ptr);
                }
            }
        }
        #endregion
        #region glGetProgramResourceIndex
        private delegate GLuint glGetProgramResourceIndexDelegate(GLuint program, GLenum programInterface, string name);
        private static glGetProgramResourceIndexDelegate glGetProgramResourceIndex = null;
        public static int GetProgramResourceIndex(int program, ProgramInterface programInterface, string name)
        {
            return (int)glGetProgramResourceIndex((GLuint)program, (GLenum)programInterface, name);
        }
        #endregion
        #region glGetProgramResourceName
        private unsafe delegate void glGetProgramResourceNameDelegate(GLuint program, GLenum programInterface, GLuint index, GLsizei bufSize, GLsizei* length, StringBuilder name);
        private static glGetProgramResourceNameDelegate glGetProgramResourceName = null;
        public static void GetProgramResourceName(int program, ProgramInterface programInterface, int index, int bufSize, out int length, StringBuilder name)
        {
            unsafe
            {
                fixed (int* length_ptr = &length)
                {
                    glGetProgramResourceName((GLuint)program, (GLenum)programInterface, (GLuint)index, bufSize, length_ptr, name);
                }
            }
        }
        #endregion
        #region glGetProgramResourceiv
        private unsafe delegate void glGetProgramResourceivDelegate(GLuint program, GLenum programInterface, GLuint index, GLsizei propCount, GLenum* props, GLsizei bufSize, GLsizei* length, GLint* param);
        private static glGetProgramResourceivDelegate glGetProgramResourceiv = null;
        public static void GetProgramResource(int program, ProgramInterface programInterface, int index, int propCount, ProgramResourceProperty[] props, int bufSize, out int length, out int param)
        {
            unsafe
            {
                fixed (ProgramResourceProperty* props_ptr = props)
                fixed (int* length_ptr = &length, param_ptr = &param)
                {
                    glGetProgramResourceiv((GLuint)program, (GLenum)programInterface, (GLuint)index, propCount, (GLenum*)props_ptr, bufSize, length_ptr, param_ptr);
                }
            }
        }
        public static void GetProgramResource(int program, ProgramInterface programInterface, int index, int propCount, ProgramResourceProperty[] props, int bufSize, out int length, [Out] int[] param)
        {
            unsafe
            {
                fixed (ProgramResourceProperty* props_ptr = props)
                fixed (int* length_ptr = &length, param_ptr = param)
                {
                    glGetProgramResourceiv((GLuint)program, (GLenum)programInterface, (GLuint)index, propCount, (GLenum*)props_ptr, bufSize, length_ptr, param_ptr);
                }
            }
        }
        #endregion
        #region glGetProgramResourceLocation
        private delegate GLint glGetProgramResourceLocationDelegate(GLuint program, GLenum programInterface, string name);
        private static glGetProgramResourceLocationDelegate glGetProgramResourceLocation = null;
        public static int GetProgramResourceLocation(int program, ProgramInterface programInterface, string name)
        {
            return glGetProgramResourceLocation((GLuint)program, (GLenum)programInterface, name);
        }
        #endregion
        #region glGetProgramResourceLocationIndex
        private delegate GLint glGetProgramResourceLocationIndexDelegate(GLuint program, GLenum programInterface, string name);
        private static glGetProgramResourceLocationIndexDelegate glGetProgramResourceLocationIndex = null;
        public static int GetProgramResourceLocationIndex(int program, ProgramInterface programInterface, string name)
        {
            return glGetProgramResourceLocationIndex((GLuint)program, (GLenum)programInterface, name);
        }
        #endregion
        #region glShaderStorageBlockBinding
        private delegate void glShaderStorageBlockBindingDelegate(GLuint program, GLuint storageBlockIndex, GLuint storageBlockBinding);
        private static glShaderStorageBlockBindingDelegate glShaderStorageBlockBinding = null;
        public static void ShaderStorageBlockBinding(int program, int storageBlockIndex, int storageBlockBinding)
        {
            glShaderStorageBlockBinding((GLuint)program, (GLuint)storageBlockIndex, (GLuint)storageBlockBinding);
        }
        #endregion
        #region glTexBufferRange
        private delegate void glTexBufferRangeDelegate(GLenum target, GLenum internalformat, GLuint buffer, GLintptr offset, GLsizeiptr size);
        private static glTexBufferRangeDelegate glTexBufferRange = null;
        public static void TexBufferRange(TextureBufferTarget target, TextureBufferInternalFormat internalformat, int buffer, IntPtr offset, IntPtr size)
        {
            glTexBufferRange((GLenum)target, (GLenum)internalformat, (GLuint)buffer, offset, size);
        }
        #endregion
        #region glTexStorage2DMultisample
        private delegate void glTexStorage2DMultisampleDelegate(GLenum target, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height, GLboolean fixedsamplelocations);
        private static glTexStorage2DMultisampleDelegate glTexStorage2DMultisample = null;
        public static void TexStorage2DMultisample(TextureTargetMultisample target, int samples, PixelInternalFormat internalformat, int width, int height, bool fixedsamplelocations)
        {
            glTexStorage2DMultisample((GLenum)target, samples, (GLenum)internalformat, width, height, fixedsamplelocations);
        }
        #endregion
        #region glTexStorage3DMultisample
        private delegate void glTexStorage3DMultisampleDelegate(GLenum target, GLsizei samples, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLboolean fixedsamplelocations);
        private static glTexStorage3DMultisampleDelegate glTexStorage3DMultisample = null;
        public static void TexStorage3DMultisample(TextureTargetMultisample target, int samples, PixelInternalFormat internalformat, int width, int height, int depth, bool fixedsamplelocations)
        {
            glTexStorage3DMultisample((GLenum)target, samples, (GLenum)internalformat, width, height, depth, fixedsamplelocations);
        }
        #endregion
        #region glTextureView
        private delegate void glTextureViewDelegate(GLuint texture, GLenum target, GLuint origtexture, GLenum internalformat, GLuint minlevel, GLuint numlevels, GLuint minlayer, GLuint numlayers);
        private static glTextureViewDelegate glTextureView = null;
        public static void TextureView(int texture, TextureTarget target, int origtexture, PixelInternalFormat internalformat, int minlevel, int numlevels, int minlayer, int numlayers)
        {
            glTextureView((GLuint)texture, (GLenum)target, (GLuint)origtexture, (GLenum)internalformat, (GLuint)minlevel, (GLuint)numlevels, (GLuint)minlayer, (GLuint)numlayers);
        }
        #endregion
        #region glBindVertexBuffer
        private delegate void glBindVertexBufferDelegate(GLuint bindingindex, GLuint buffer, GLintptr offset, GLsizei stride);
        private static glBindVertexBufferDelegate glBindVertexBuffer = null;
        public static void BindVertexBuffer(int bindingindex, int buffer, IntPtr offset, int stride)
        {
            glBindVertexBuffer((GLuint)bindingindex, (GLuint)buffer, offset, stride);
        }
        #endregion
        #region glVertexAttribFormat
        private delegate void glVertexAttribFormatDelegate(GLuint attribindex, GLint size, GLenum type, GLboolean normalized, GLuint relativeoffset);
        private static glVertexAttribFormatDelegate glVertexAttribFormat = null;
        public static void VertexAttribFormat(int attribindex, int size, VertexAttribType type, bool normalized, int relativeoffset)
        {
            glVertexAttribFormat((GLuint)attribindex, size, (GLenum)type, normalized, (GLuint)relativeoffset);
        }
        #endregion
        #region glVertexAttribIFormat
        private delegate void glVertexAttribIFormatDelegate(GLuint attribindex, GLint size, GLenum type, GLuint relativeoffset);
        private static glVertexAttribIFormatDelegate glVertexAttribIFormat = null;
        public static void VertexAttribIFormat(int attribindex, int size, VertexAttribType type, int relativeoffset)
        {
            glVertexAttribIFormat((GLuint)attribindex, size, (GLenum)type, (GLuint)relativeoffset);
        }
        #endregion
        #region glVertexAttribLFormat
        private delegate void glVertexAttribLFormatDelegate(GLuint attribindex, GLint size, GLenum type, GLuint relativeoffset);
        private static glVertexAttribLFormatDelegate glVertexAttribLFormat = null;
        public static void VertexAttribLFormat(int attribindex, int size, VertexAttribType type, int relativeoffset)
        {
            glVertexAttribLFormat((GLuint)attribindex, size, (GLenum)type, (GLuint)relativeoffset);
        }
        #endregion
        #region glVertexAttribBinding
        private delegate void glVertexAttribBindingDelegate(GLuint attribindex, GLuint bindingindex);
        private static glVertexAttribBindingDelegate glVertexAttribBinding = null;
        public static void VertexAttribBinding(int attribindex, int bindingindex)
        {
            glVertexAttribBinding((GLuint)attribindex, (GLuint)bindingindex);
        }
        #endregion
        #region glVertexBindingDivisor
        private delegate void glVertexBindingDivisorDelegate(GLuint bindingindex, GLuint divisor);
        private static glVertexBindingDivisorDelegate glVertexBindingDivisor = null;
        private static void VertexBindingDivisor(int bindingindex, int divisor)
        {
            glVertexBindingDivisor((GLuint)bindingindex, (GLuint)divisor);
        }
        #endregion
        #region glDebugMessageControl
        private unsafe delegate void glDebugMessageControlDelegate(GLenum source, GLenum type, GLenum severity, GLsizei count, GLuint* ids, GLboolean enabled);
        private static glDebugMessageControlDelegate glDebugMessageControl = null;
        public static void DebugMessageControl(DebugSource source, DebugType type, DebugSeverity severity, int count, int[] ids, bool enabled)
        {
            unsafe
            {
                fixed (int* ids_ptr = ids)
                {
                    glDebugMessageControl((GLenum)source, (GLenum)type, (GLenum)severity, count, (GLuint*)ids_ptr, enabled);
                }
            }
        }
        #endregion
        #region glDebugMessageInsert
        private delegate void glDebugMessageInsertDelegate(GLenum source, GLenum type, GLuint id, GLenum severity, GLsizei length, string buf);
        private static glDebugMessageInsertDelegate glDebugMessageInsert = null;
        public static void DebugMessageInsert(DebugSource source, DebugType type, int id, DebugSeverity severity, int length, string buf)
        {
            glDebugMessageInsert((GLenum)source, (GLenum)type, (GLuint)id, (GLenum)severity, length, buf);
        }
        #endregion
        #region glDebugMessageCallback
        private delegate void glDebugMessageCallbackDelegate(GLDEBUGPROC callback, IntPtr userParam);
        private static glDebugMessageCallbackDelegate glDebugMessageCallback = null;
        public static void DebugMessageCallback(GLDEBUGPROC callback, IntPtr userParam)
        {
            glDebugMessageCallback(callback, userParam);
        }
        #endregion
        #region glGetDebugMessageLog
        private unsafe delegate GLuint glGetDebugMessageLogDelegate(GLuint count, GLsizei bufSize, GLenum* sources, GLenum* types, GLuint* ids, GLenum* severities, GLsizei* lengths, StringBuilder messageLog);
        private static glGetDebugMessageLogDelegate glGetDebugMessageLog = null;
        public static int GetDebugMessageLog(int count, int bufSize, DebugSource[] sources, DebugType[] types, [Out] int[] ids, DebugSeverity[] severities, [Out] int[] lengths, StringBuilder messageLog)
        {
            unsafe
            {
                fixed (DebugSource* sources_ptr = sources)
                fixed (DebugType* types_ptr = types)
                fixed (int* ids_ptr = ids, lengths_ptr=lengths)
                fixed (DebugSeverity* severities_ptr = severities)
                {
                    return (int)glGetDebugMessageLog((GLuint)count, bufSize, (GLenum*)sources_ptr, (GLenum*)types_ptr, (uint*)ids_ptr, (GLenum*)severities_ptr, lengths_ptr, messageLog);
                }
            }
        }
        #endregion
        #region glPushDebugGroup
        private delegate void glPushDebugGroupDelegate(GLenum source, GLuint id, GLsizei length, string message);
        private static glPushDebugGroupDelegate glPushDebugGroup = null;
        public static void PushDebugGroup(DebugSource source, int id, int length, string message)
        {
            glPushDebugGroup((GLenum)source, (GLuint)id, length, message);
        }
        #endregion
        #region glPopDebugGroup
        private delegate void glPopDebugGroupDelegate();
        private static glPopDebugGroupDelegate glPopDebugGroup = null;
        public static void PopDebugGroup()
        {
            glPopDebugGroup();
        }
        #endregion
        #region glObjectLabel
        private delegate void glObjectLabelDelegate(GLenum identifier, GLuint name, GLsizei length, string label);
        private static glObjectLabelDelegate glObjectLabel = null;
        public static void ObjectLabel(ObjectLabelIdentifier identifier, int name, int length, string label)
        {
            glObjectLabel((GLenum)identifier, (GLuint)name, length, label);
        }
        #endregion
        #region glGetObjectLabel
        private unsafe delegate void glGetObjectLabelDelegate(GLenum identifier, GLuint name, GLsizei bufSize, GLsizei* length, StringBuilder label);
        private static glGetObjectLabelDelegate glGetObjectLabel = null;
        public static void GetObjectLabel(ObjectLabelIdentifier identifier, int name, int bufSize, out int length, StringBuilder label)
        {
            unsafe
            {
                fixed (int* length_ptr = &length)
                {
                    glGetObjectLabel((GLenum)identifier, (GLuint)name, bufSize, length_ptr, label);
                }
            }
        }
        #endregion
        #region glObjectPtrLabel
        private delegate void glObjectPtrLabelDelegate(IntPtr ptr, GLsizei length, string label);
        private static glObjectPtrLabelDelegate glObjectPtrLabel = null;
        public static void ObjectPtrLabel(IntPtr ptr, int length, string label)
        {
            glObjectPtrLabel(ptr, length, label);
        }
        #endregion
        #region glGetObjectPtrLabel
        private unsafe delegate void glGetObjectPtrLabelDelegate(IntPtr ptr, GLsizei bufSize, GLsizei* length, StringBuilder label);
        private static glGetObjectPtrLabelDelegate glGetObjectPtrLabel = null;
        public static void GetObjectPtrLabel(IntPtr ptr, int bufSize, out int length, StringBuilder label)
        {
            unsafe
            {
                fixed (int* length_ptr = &length)
                {
                    glGetObjectPtrLabel(ptr, bufSize, length_ptr, label);
                }
            }
        }
        #endregion
        #endregion
        #region OPENGL 4.4
        #region glBufferStorage
        private delegate void glBufferStorageDelegate(GLenum target, GLsizeiptr size, IntPtr data, GLbitfield flags);
        private static glBufferStorageDelegate glBufferStorage = null;
        public static void BufferStorage(BufferTarget target, IntPtr size, IntPtr data, BufferStorageFlags flags)
        {
            glBufferStorage((GLenum)target, size, data, (GLbitfield)flags);
        }
        #endregion
        #region glClearTexImage
        private delegate void glClearTexImageDelegate(GLuint texture, GLint level, GLenum format, GLenum type, IntPtr data);
        private static glClearTexImageDelegate glClearTexImage = null;
        public static void ClearTexImage(int texture, int level, PixelFormat format, PixelType type, IntPtr data)
        {
            glClearTexImage((GLuint)texture, level, (GLenum)format, (GLenum)type, data);
        }
        #endregion
        #region glClearTexSubImage
        private delegate void glClearTexSubImageDelegate(GLuint texture, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, IntPtr data);
        private static glClearTexSubImageDelegate glClearTexSubImage = null;
        public static void ClearTexSubImage(int texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, IntPtr data)
        {
            glClearTexSubImage((GLuint)texture, level, xoffset, yoffset, zoffset, width, height, depth, (GLenum)format, (GLenum)type, data);
        }
        #endregion
        #region glBindBuffersBase
        private unsafe delegate void glBindBuffersBaseDelegate(GLenum target, GLuint first, GLsizei count, GLuint* buffers);
        private static glBindBuffersBaseDelegate glBindBuffersBase = null;
        public static void BindBuffersBase(BufferTarget target, int first, int count, int[] buffers)
        {
            unsafe
            {
                fixed (int* buffers_ptr = buffers)
                {
                    glBindBuffersBase((GLenum)target, (GLuint)first, count, (GLuint*)buffers_ptr);
                }
            }
        }
        #endregion
        #region glBindBuffersRange
        private unsafe delegate void glBindBuffersRangeDelegate(GLenum target, GLuint first, GLsizei count, GLuint* buffers, GLintptr* offsets, GLsizeiptr* sizes);
        private static glBindBuffersRangeDelegate glBindBuffersRange = null;
        public static void BindBuffersRange(BufferTarget target, int first, int count, int[] buffers, IntPtr[] offsets, IntPtr[] sizes)
        {
            unsafe
            {
                fixed (int* buffers_ptr = buffers)
                fixed (IntPtr* offsets_ptr = offsets, sizes_ptr = sizes)
                {
                    glBindBuffersRange((GLenum)target, (GLuint)first, count, (GLuint*)buffers_ptr, offsets_ptr, sizes_ptr);
                }
            }
        }
        #endregion
        #region glBindTextures
        private unsafe delegate void glBindTexturesDelegate(GLuint first, GLsizei count, GLuint* textures);
        private static glBindTexturesDelegate glBindTextures = null;
        public static void BindTextures(int first, int count, int[] textures)
        {
            unsafe
            {
                fixed (int* textures_ptr = textures)
                {
                    glBindTextures((GLuint)first, count, (GLuint*)textures_ptr);
                }
            }
        }
        #endregion
        #region glBindSamplers
        private unsafe delegate void glBindSamplersDelegate(GLuint first, GLsizei count, GLuint* samplers);
        private static glBindSamplersDelegate glBindSamplers = null;
        public static void BindSamplers(int first, int count, int[] samplers)
        {
            unsafe
            {
                fixed (int* samplers_ptr = samplers)
                {
                    glBindSamplers((GLuint)first, count, (GLuint*)samplers_ptr);
                }
            }
        }
        #endregion
        #region glBindImageTextures
        private unsafe delegate void glBindImageTexturesDelegate(GLuint first, GLsizei count, GLuint* textures);
        private static glBindImageTexturesDelegate glBindImageTextures = null;
        public static void BindImageTextures(int first, int count, int[] textures)
        {
            unsafe
            {
                fixed (int* textures_ptr = textures)
                {
                    glBindImageTextures((GLuint)first, count, (GLuint*)textures_ptr);
                }
            }
        }
        #endregion
        #region glBindVertexBuffers
        private unsafe delegate void glBindVertexBuffersDelegate(GLuint first, GLsizei count, GLuint* buffers, GLintptr* offsets, GLsizei* strides);
        private static glBindVertexBuffersDelegate glBindVertexBuffers = null;
        public static void BindVertexBuffers(int first, int count, int[] buffers, IntPtr[] offsets, int[] strides)
        {
            unsafe
            {
                fixed (int* buffers_ptr = buffers, strides_ptr = strides)
                fixed (IntPtr* offsets_ptr = offsets)
                {
                    glBindVertexBuffers((GLuint)first, count, (GLuint*)buffers_ptr, offsets_ptr, strides_ptr);
                }
            }
        }
        #endregion
        #endregion

        /// <summary>
        /// Load OpenGL extensions
        /// </summary>
        public static void LoadExtensions()
        {
            Logger.WriteLine("Loading GL Extensions");
            #region OPENGL 1.2
            glDrawRangeElements = WGL.GetExtension<glDrawRangeElementsDelegate>("glDrawRangeElements");
            glTexImage3D = WGL.GetExtension<glTexImage3DDelegate>("glTexImage3D");
            glTexSubImage3D = WGL.GetExtension<glTexSubImage3DDelegate>("glTexSubImage3D");
            glCopyTexSubImage3D = WGL.GetExtension<glCopyTexSubImage3DDelegate>("glCopyTexSubImage3D");
            #endregion
            #region OPENGL 1.3
            glActiveTexture = WGL.GetExtension<glActiveTextureDelegate>("glActiveTexture");
            glSampleCoverage = WGL.GetExtension<glSampleCoverageDelegate>("glSampleCoverage");
            glCompressedTexImage3D = WGL.GetExtension<glCompressedTexImage3DDelegate>("glCompressedTexImage3D");
            glCompressedTexImage2D = WGL.GetExtension<glCompressedTexImage2DDelegate>("glCompressedTexImage2D");
            glCompressedTexImage1D = WGL.GetExtension<glCompressedTexImage1DDelegate>("glCompressedTexImage1D");
            glCompressedTexSubImage3D = WGL.GetExtension<glCompressedTexSubImage3DDelegate>("glCompressedTexSubImage3D");
            glCompressedTexSubImage2D = WGL.GetExtension<glCompressedTexSubImage2DDelegate>("glCompressedTexSubImage2D");
            glCompressedTexSubImage1D = WGL.GetExtension<glCompressedTexSubImage1DDelegate>("glCompressedTexSubImage1D");
            glGetCompressedTexImage = WGL.GetExtension<glGetCompressedTexImageDelegate>("glGetCompressedTexImage");
            #endregion
            #region OPENGL 1.4
            glBlendFuncSeparate = WGL.GetExtension<glBlendFuncSeparateDelegate>("glBlendFuncSeparate");
            glMultiDrawArrays = WGL.GetExtension<glMultiDrawArraysDelegate>("glMultiDrawArrays");
            glMultiDrawElements = WGL.GetExtension<glMultiDrawElementsDelegate>("glMultiDrawElements");
            glPointParameterf = WGL.GetExtension<glPointParameterfDelegate>("glPointParameterf");
            glPointParameterfv = WGL.GetExtension<glPointParameterfvDelegate>("glPointParameterfv");
            glPointParameteri = WGL.GetExtension<glPointParameteriDelegate>("glPointParameteri");
            glPointParameteriv = WGL.GetExtension<glPointParameterivDelegate>("glPointParameteriv");
            glBlendColor = WGL.GetExtension<glBlendColorDelegate>("glBlendColor");
            glBlendEquation = WGL.GetExtension<glBlendEquationDelegate>("glBlendEquation");
            #endregion
            #region OPENGL 1.5
            glGenQueries = WGL.GetExtension<glGenQueriesDelegate>("glGenQueries");
            glDeleteQueries = WGL.GetExtension<glDeleteQueriesDelegate>("glDeleteQueries");
            glIsQuery = WGL.GetExtension<glIsQueryDelegate>("glIsQuery");
            glBeginQuery = WGL.GetExtension<glBeginQueryDelegate>("glBeginQuery");
            glEndQuery = WGL.GetExtension<glEndQueryDelegate>("glEndQuery");
            glGetQueryiv = WGL.GetExtension<glGetQueryivDelegate>("glGetQueryiv");
            glGetQueryObjectiv = WGL.GetExtension<glGetQueryObjectivDelegate>("glGetQueryObjectiv");
            glGetQueryObjectuiv = WGL.GetExtension<glGetQueryObjectuivDelegate>("glGetQueryObjectuiv");
            glBindBuffer = WGL.GetExtension<glBindBufferDelegate>("glBindBuffer");
            glDeleteBuffers = WGL.GetExtension<glDeleteBuffersDelegate>("glDeleteBuffers");
            glGenBuffers = WGL.GetExtension<glGenBuffersDelegate>("glGenBuffers");
            glIsBuffer = WGL.GetExtension<glIsBufferDelegate>("glIsBuffer");
            glBufferData = WGL.GetExtension<glBufferDataDelegate>("glBufferData");
            glBufferSubData = WGL.GetExtension<glBufferSubDataDelegate>("glBufferSubData");
            glGetBufferSubData = WGL.GetExtension<glGetBufferSubDataDelegate>("glGetBufferSubData");
            glMapBuffer = WGL.GetExtension<glMapBufferDelegate>("glMapBuffer");
            glUnmapBuffer = WGL.GetExtension<glUnmapBufferDelegate>("glUnmapBuffer");
            glGetBufferParameteriv = WGL.GetExtension<glGetBufferParameterivDelegate>("glGetBufferParameteriv");
            glGetBufferPointerv = WGL.GetExtension<glGetBufferPointervDelegate>("glGetBufferPointerv");
            #endregion
            #region OPENGL 2.0
            glBlendEquationSeparate = WGL.GetExtension<glBlendEquationSeparateDelegate>("glBlendEquationSeparate");
            glDrawBuffers = WGL.GetExtension<glDrawBuffersDelegate>("glDrawBuffers");
            glStencilOpSeparate = WGL.GetExtension<glStencilOpSeparateDelegate>("glStencilOpSeparate");
            glStencilFuncSeparate = WGL.GetExtension<glStencilFuncSeparateDelegate>("glStencilFuncSeparate");
            glStencilMaskSeparate = WGL.GetExtension<glStencilMaskSeparateDelegate>("glStencilMaskSeparate");
            glAttachShader = WGL.GetExtension<glAttachShaderDelegate>("glAttachShader");
            glBindAttribLocation = WGL.GetExtension<glBindAttribLocationDelegate>("glBindAttribLocation");
            glCompileShader = WGL.GetExtension<glCompileShaderDelegate>("glCompileShader");
            glCreateProgram = WGL.GetExtension<glCreateProgramDelegate>("glCreateProgram");
            glCreateShader = WGL.GetExtension<glCreateShaderDelegate>("glCreateShader");
            glDeleteProgram = WGL.GetExtension<glDeleteProgramDelegate>("glDeleteProgram");
            glDeleteShader = WGL.GetExtension<glDeleteShaderDelegate>("glDeleteShader");
            glDetachShader = WGL.GetExtension<glDetachShaderDelegate>("glDetachShader");
            glDisableVertexAttribArray = WGL.GetExtension<glDisableVertexAttribArrayDelegate>("glDisableVertexAttribArray");
            glEnableVertexAttribArray = WGL.GetExtension<glEnableVertexAttribArrayDelegate>("glEnableVertexAttribArray");
            glGetActiveAttrib = WGL.GetExtension<glGetActiveAttribDelegate>("glGetActiveAttrib");
            glGetActiveUniform = WGL.GetExtension<glGetActiveUniformDelegate>("glGetActiveUniform");
            glGetAttachedShaders = WGL.GetExtension<glGetAttachedShadersDelegate>("glGetAttachedShaders");
            glGetAttribLocation = WGL.GetExtension<glGetAttribLocationDelegate>("glGetAttribLocation");
            glGetProgramiv = WGL.GetExtension<glGetProgramivDelegate>("glGetProgramiv");
            glGetProgramInfoLog = WGL.GetExtension<glGetProgramInfoLogDelegate>("glGetProgramInfoLog");
            glGetShaderiv = WGL.GetExtension<glGetShaderivDelegate>("glGetShaderiv");
            glGetShaderInfoLog = WGL.GetExtension<glGetShaderInfoLogDelegate>("glGetShaderInfoLog");
            glGetShaderSource = WGL.GetExtension<glGetShaderSourceDelegate>("glGetShaderSource");
            glGetUniformLocation = WGL.GetExtension<glGetUniformLocationDelegate>("glGetUniformLocation");
            glGetUniformfv = WGL.GetExtension<glGetUniformfvDelegate>("glGetUniformfv");
            glGetUniformiv = WGL.GetExtension<glGetUniformivDelegate>("glGetUniformiv");
            glGetVertexAttribdv = WGL.GetExtension<glGetVertexAttribdvDelegate>("glGetVertexAttribdv");
            glGetVertexAttribfv = WGL.GetExtension<glGetVertexAttribfvDelegate>("glGetVertexAttribfv");
            glGetVertexAttribiv = WGL.GetExtension<glGetVertexAttribivDelegate>("glGetVertexAttribiv");
            glGetVertexAttribPointerv = WGL.GetExtension<glGetVertexAttribPointervDelegate>("glGetVertexAttribPointerv");
            glIsProgram = WGL.GetExtension<glIsProgramDelegate>("glIsProgram");
            glIsShader = WGL.GetExtension<glIsShaderDelegate>("glIsShader");
            glLinkProgram = WGL.GetExtension<glLinkProgramDelegate>("glLinkProgram");
            glShaderSource = WGL.GetExtension<glShaderSourceDelegate>("glShaderSource");
            glUseProgram = WGL.GetExtension<glUseProgramDelegate>("glUseProgram");
            glUniform1f = WGL.GetExtension<glUniform1fDelegate>("glUniform1f");
            glUniform2f = WGL.GetExtension<glUniform2fDelegate>("glUniform2f");
            glUniform3f = WGL.GetExtension<glUniform3fDelegate>("glUniform3f");
            glUniform4f = WGL.GetExtension<glUniform4fDelegate>("glUniform4f");
            glUniform1i = WGL.GetExtension<glUniform1iDelegate>("glUniform1i");
            glUniform2i = WGL.GetExtension<glUniform2iDelegate>("glUniform2i");
            glUniform3i = WGL.GetExtension<glUniform3iDelegate>("glUniform3i");
            glUniform4i = WGL.GetExtension<glUniform4iDelegate>("glUniform4i");
            glUniform1fv = WGL.GetExtension<glUniform1fvDelegate>("glUniform1fv");
            glUniform2fv = WGL.GetExtension<glUniform2fvDelegate>("glUniform2fv");
            glUniform3fv = WGL.GetExtension<glUniform3fvDelegate>("glUniform3fv");
            glUniform4fv = WGL.GetExtension<glUniform4fvDelegate>("glUniform4fv");
            glUniform1iv = WGL.GetExtension<glUniform1ivDelegate>("glUniform1iv");
            glUniform2iv = WGL.GetExtension<glUniform2ivDelegate>("glUniform2iv");
            glUniform3iv = WGL.GetExtension<glUniform3ivDelegate>("glUniform3iv");
            glUniform4iv = WGL.GetExtension<glUniform4ivDelegate>("glUniform4iv");
            glUniformMatrix2fv = WGL.GetExtension<glUniformMatrix2fvDelegate>("glUniformMatrix2fv");
            glUniformMatrix3fv = WGL.GetExtension<glUniformMatrix3fvDelegate>("glUniformMatrix3fv");
            glUniformMatrix4fv = WGL.GetExtension<glUniformMatrix4fvDelegate>("glUniformMatrix4fv");
            glValidateProgram = WGL.GetExtension<glValidateProgramDelegate>("glValidateProgram");
            glVertexAttrib1d = WGL.GetExtension<glVertexAttrib1dDelegate>("glVertexAttrib1d");
            glVertexAttrib1dv = WGL.GetExtension<glVertexAttrib1dvDelegate>("glVertexAttrib1dv");
            glVertexAttrib1f = WGL.GetExtension<glVertexAttrib1fDelegate>("glVertexAttrib1f");
            glVertexAttrib1fv = WGL.GetExtension<glVertexAttrib1fvDelegate>("glVertexAttrib1fv");
            glVertexAttrib1s = WGL.GetExtension<glVertexAttrib1sDelegate>("glVertexAttrib1s");
            glVertexAttrib1sv = WGL.GetExtension<glVertexAttrib1svDelegate>("glVertexAttrib1sv");
            glVertexAttrib2d = WGL.GetExtension<glVertexAttrib2dDelegate>("glVertexAttrib2d");
            glVertexAttrib2dv = WGL.GetExtension<glVertexAttrib2dvDelegate>("glVertexAttrib2dv");
            glVertexAttrib2f = WGL.GetExtension<glVertexAttrib2fDelegate>("glVertexAttrib2f");
            glVertexAttrib2fv = WGL.GetExtension<glVertexAttrib2fvDelegate>("glVertexAttrib2fv");
            glVertexAttrib2s = WGL.GetExtension<glVertexAttrib2sDelegate>("glVertexAttrib2s");
            glVertexAttrib2sv = WGL.GetExtension<glVertexAttrib2svDelegate>("glVertexAttrib2sv");
            glVertexAttrib3d = WGL.GetExtension<glVertexAttrib3dDelegate>("glVertexAttrib3d");
            glVertexAttrib3dv = WGL.GetExtension<glVertexAttrib3dvDelegate>("glVertexAttrib3dv");
            glVertexAttrib3f = WGL.GetExtension<glVertexAttrib3fDelegate>("glVertexAttrib3f");
            glVertexAttrib3fv = WGL.GetExtension<glVertexAttrib3fvDelegate>("glVertexAttrib3fv");
            glVertexAttrib3s = WGL.GetExtension<glVertexAttrib3sDelegate>("glVertexAttrib3s");
            glVertexAttrib3sv = WGL.GetExtension<glVertexAttrib3svDelegate>("glVertexAttrib3sv");
            glVertexAttrib4Nbv = WGL.GetExtension<glVertexAttrib4NbvDelegate>("glVertexAttrib4Nbv");
            glVertexAttrib4Niv = WGL.GetExtension<glVertexAttrib4NivDelegate>("glVertexAttrib4Niv");
            glVertexAttrib4Nsv = WGL.GetExtension<glVertexAttrib4NsvDelegate>("glVertexAttrib4Nsv");
            glVertexAttrib4Nub = WGL.GetExtension<glVertexAttrib4NubDelegate>("glVertexAttrib4Nub");
            glVertexAttrib4Nubv = WGL.GetExtension<glVertexAttrib4NubvDelegate>("glVertexAttrib4Nubv");
            glVertexAttrib4Nuiv = WGL.GetExtension<glVertexAttrib4NuivDelegate>("glVertexAttrib4Nuiv");
            glVertexAttrib4Nusv = WGL.GetExtension<glVertexAttrib4NusvDelegate>("glVertexAttrib4Nusv");
            glVertexAttrib4bv = WGL.GetExtension<glVertexAttrib4bvDelegate>("glVertexAttrib4bv");
            glVertexAttrib4d = WGL.GetExtension<glVertexAttrib4dDelegate>("glVertexAttrib4d");
            glVertexAttrib4dv = WGL.GetExtension<glVertexAttrib4dvDelegate>("glVertexAttrib4dv");
            glVertexAttrib4f = WGL.GetExtension<glVertexAttrib4fDelegate>("glVertexAttrib4f");
            glVertexAttrib4fv = WGL.GetExtension<glVertexAttrib4fvDelegate>("glVertexAttrib4fv");
            glVertexAttrib4iv = WGL.GetExtension<glVertexAttrib4ivDelegate>("glVertexAttrib4iv");
            glVertexAttrib4s = WGL.GetExtension<glVertexAttrib4sDelegate>("glVertexAttrib4s");
            glVertexAttrib4sv = WGL.GetExtension<glVertexAttrib4svDelegate>("glVertexAttrib4sv");
            glVertexAttrib4ubv = WGL.GetExtension<glVertexAttrib4ubvDelegate>("glVertexAttrib4ubv");
            glVertexAttrib4uiv = WGL.GetExtension<glVertexAttrib4uivDelegate>("glVertexAttrib4uiv");
            glVertexAttrib4usv = WGL.GetExtension<glVertexAttrib4usvDelegate>("glVertexAttrib4usv");
            glVertexAttribPointer = WGL.GetExtension<glVertexAttribPointerDelegate>("glVertexAttribPointer");
            #endregion
            #region OPENGL 2.1
            glUniformMatrix2x3fv = WGL.GetExtension<glUniformMatrix2x3fvDelegate>("glUniformMatrix2x3fv");
            glUniformMatrix3x2fv = WGL.GetExtension<glUniformMatrix3x2fvDelegate>("glUniformMatrix3x2fv");
            glUniformMatrix2x4fv = WGL.GetExtension<glUniformMatrix2x4fvDelegate>("glUniformMatrix2x4fv");
            glUniformMatrix4x2fv = WGL.GetExtension<glUniformMatrix4x2fvDelegate>("glUniformMatrix4x2fv");
            glUniformMatrix3x4fv = WGL.GetExtension<glUniformMatrix3x4fvDelegate>("glUniformMatrix3x4fv");
            glUniformMatrix4x3fv = WGL.GetExtension<glUniformMatrix4x3fvDelegate>("glUniformMatrix4x3fv");
            #endregion
            #region OPENGL 3.0
            glColorMaski = WGL.GetExtension<glColorMaskiDelegate>("glColorMaski");
            glGetBooleani_v = WGL.GetExtension<glGetBooleani_vDelegate>("glGetBooleani_v");
            glGetIntegeri_v = WGL.GetExtension<glGetIntegeri_vDelegate>("glGetIntegeri_v");
            glEnablei = WGL.GetExtension<glEnableiDelegate>("glEnablei");
            glDisablei = WGL.GetExtension<glDisableiDelegate>("glDisablei");
            glIsEnabledi = WGL.GetExtension<glIsEnablediDelegate>("glIsEnabledi");
            glBeginTransformFeedback = WGL.GetExtension<glBeginTransformFeedbackDelegate>("glBeginTransformFeedback");
            glEndTransformFeedback = WGL.GetExtension<glEndTransformFeedbackDelegate>("glEndTransformFeedback");
            glBindBufferRange = WGL.GetExtension<glBindBufferRangeDelegate>("glBindBufferRange");
            glBindBufferBase = WGL.GetExtension<glBindBufferBaseDelegate>("glBindBufferBase");
            glTransformFeedbackVaryings = WGL.GetExtension<glTransformFeedbackVaryingsDelegate>("glTransformFeedbackVaryings");
            glGetTransformFeedbackVarying = WGL.GetExtension<glGetTransformFeedbackVaryingDelegate>("glGetTransformFeedbackVarying");
            glClampColor = WGL.GetExtension<glClampColorDelegate>("glClampColor");
            glBeginConditionalRender = WGL.GetExtension<glBeginConditionalRenderDelegate>("glBeginConditionalRender");
            glEndConditionalRender = WGL.GetExtension<glEndConditionalRenderDelegate>("glEndConditionalRender");
            glVertexAttribIPointer = WGL.GetExtension<glVertexAttribIPointerDelegate>("glVertexAttribIPointer");
            glGetVertexAttribIiv = WGL.GetExtension<glGetVertexAttribIivDelegate>("glGetVertexAttribIiv");
            glGetVertexAttribIuiv = WGL.GetExtension<glGetVertexAttribIuivDelegate>("glGetVertexAttribIuiv");
            glVertexAttribI1i = WGL.GetExtension<glVertexAttribI1iDelegate>("glVertexAttribI1i");
            glVertexAttribI2i = WGL.GetExtension<glVertexAttribI2iDelegate>("glVertexAttribI2i");
            glVertexAttribI3i = WGL.GetExtension<glVertexAttribI3iDelegate>("glVertexAttribI3i");
            glVertexAttribI4i = WGL.GetExtension<glVertexAttribI4iDelegate>("glVertexAttribI4i");
            glVertexAttribI1ui = WGL.GetExtension<glVertexAttribI1uiDelegate>("glVertexAttribI1ui");
            glVertexAttribI2ui = WGL.GetExtension<glVertexAttribI2uiDelegate>("glVertexAttribI2ui");
            glVertexAttribI3ui = WGL.GetExtension<glVertexAttribI3uiDelegate>("glVertexAttribI3ui");
            glVertexAttribI4ui = WGL.GetExtension<glVertexAttribI4uiDelegate>("glVertexAttribI4ui");
            glVertexAttribI1iv = WGL.GetExtension<glVertexAttribI1ivDelegate>("glVertexAttribI1iv");
            glVertexAttribI2iv = WGL.GetExtension<glVertexAttribI2ivDelegate>("glVertexAttribI2iv");
            glVertexAttribI3iv = WGL.GetExtension<glVertexAttribI3ivDelegate>("glVertexAttribI3iv");
            glVertexAttribI4iv = WGL.GetExtension<glVertexAttribI4ivDelegate>("glVertexAttribI4iv");
            glVertexAttribI1uiv = WGL.GetExtension<glVertexAttribI1uivDelegate>("glVertexAttribI1uiv");
            glVertexAttribI2uiv = WGL.GetExtension<glVertexAttribI2uivDelegate>("glVertexAttribI2uiv");
            glVertexAttribI3uiv = WGL.GetExtension<glVertexAttribI3uivDelegate>("glVertexAttribI3uiv");
            glVertexAttribI4uiv = WGL.GetExtension<glVertexAttribI4uivDelegate>("glVertexAttribI4uiv");
            glVertexAttribI4bv = WGL.GetExtension<glVertexAttribI4bvDelegate>("glVertexAttribI4bv");
            glVertexAttribI4sv = WGL.GetExtension<glVertexAttribI4svDelegate>("glVertexAttribI4sv");
            glVertexAttribI4ubv = WGL.GetExtension<glVertexAttribI4ubvDelegate>("glVertexAttribI4ubv");
            glVertexAttribI4usv = WGL.GetExtension<glVertexAttribI4usvDelegate>("glVertexAttribI4usv");
            glGetUniformuiv = WGL.GetExtension<glGetUniformuivDelegate>("glGetUniformuiv");
            glBindFragDataLocation = WGL.GetExtension<glBindFragDataLocationDelegate>("glBindFragDataLocation");
            glGetFragDataLocation = WGL.GetExtension<glGetFragDataLocationDelegate>("glGetFragDataLocation");
            glUniform1ui = WGL.GetExtension<glUniform1uiDelegate>("glUniform1ui");
            glUniform2ui = WGL.GetExtension<glUniform2uiDelegate>("glUniform2ui");
            glUniform3ui = WGL.GetExtension<glUniform3uiDelegate>("glUniform3ui");
            glUniform4ui = WGL.GetExtension<glUniform4uiDelegate>("glUniform4ui");
            glUniform1uiv = WGL.GetExtension<glUniform1uivDelegate>("glUniform1uiv");
            glUniform2uiv = WGL.GetExtension<glUniform2uivDelegate>("glUniform2uiv");
            glUniform3uiv = WGL.GetExtension<glUniform3uivDelegate>("glUniform3uiv");
            glUniform4uiv = WGL.GetExtension<glUniform4uivDelegate>("glUniform4uiv");
            glTexParameterIiv = WGL.GetExtension<glTexParameterIivDelegate>("glTexParameterIiv");
            glTexParameterIuiv = WGL.GetExtension<glTexParameterIuivDelegate>("glTexParameterIuiv");
            glGetTexParameterIiv = WGL.GetExtension<glGetTexParameterIivDelegate>("glGetTexParameterIiv");
            glGetTexParameterIuiv = WGL.GetExtension<glGetTexParameterIuivDelegate>("glGetTexParameterIuiv");
            glClearBufferiv = WGL.GetExtension<glClearBufferivDelegate>("glClearBufferiv");
            glClearBufferuiv = WGL.GetExtension<glClearBufferuivDelegate>("glClearBufferuiv");
            glClearBufferfv = WGL.GetExtension<glClearBufferfvDelegate>("glClearBufferfv");
            glClearBufferfi = WGL.GetExtension<glClearBufferfiDelegate>("glClearBufferfi");
            glGetStringi = WGL.GetExtension<glGetStringiDelegate>("glGetStringi");
            glIsRenderbuffer = WGL.GetExtension<glIsRenderbufferDelegate>("glIsRenderbuffer");
            glBindRenderbuffer = WGL.GetExtension<glBindRenderbufferDelegate>("glBindRenderbuffer");
            glDeleteRenderbuffers = WGL.GetExtension<glDeleteRenderbuffersDelegate>("glDeleteRenderbuffers");
            glGenRenderbuffers = WGL.GetExtension<glGenRenderbuffersDelegate>("glGenRenderbuffers");
            glRenderbufferStorage = WGL.GetExtension<glRenderbufferStorageDelegate>("glRenderbufferStorage");
            glGetRenderbufferParameteriv = WGL.GetExtension<glGetRenderbufferParameterivDelegate>("glGetRenderbufferParameteriv");
            glIsFramebuffer = WGL.GetExtension<glIsFramebufferDelegate>("glIsFramebuffer");
            glBindFramebuffer = WGL.GetExtension<glBindFramebufferDelegate>("glBindFramebuffer");
            glDeleteFramebuffers = WGL.GetExtension<glDeleteFramebuffersDelegate>("glDeleteFramebuffers");
            glGenFramebuffers = WGL.GetExtension<glGenFramebuffersDelegate>("glGenFramebuffers");
            glCheckFramebufferStatus = WGL.GetExtension<glCheckFramebufferStatusDelegate>("glCheckFramebufferStatus");
            glFramebufferTexture1D = WGL.GetExtension<glFramebufferTexture1DDelegate>("glFramebufferTexture1D");
            glFramebufferTexture2D = WGL.GetExtension<glFramebufferTexture2DDelegate>("glFramebufferTexture2D");
            glFramebufferTexture3D = WGL.GetExtension<glFramebufferTexture3DDelegate>("glFramebufferTexture3D");
            glFramebufferRenderbuffer = WGL.GetExtension<glFramebufferRenderbufferDelegate>("glFramebufferRenderbuffer");
            glGetFramebufferAttachmentParameteriv = WGL.GetExtension<glGetFramebufferAttachmentParameterivDelegate>("glGetFramebufferAttachmentParameteriv");
            glGenerateMipmap = WGL.GetExtension<glGenerateMipmapDelegate>("glGenerateMipmap");
            glBlitFramebuffer = WGL.GetExtension<glBlitFramebufferDelegate>("glBlitFramebuffer");
            glRenderbufferStorageMultisample = WGL.GetExtension<glRenderbufferStorageMultisampleDelegate>("glRenderbufferStorageMultisample");
            glFramebufferTextureLayer = WGL.GetExtension<glFramebufferTextureLayerDelegate>("glFramebufferTextureLayer");
            glMapBufferRange = WGL.GetExtension<glMapBufferRangeDelegate>("glMapBufferRange");
            glFlushMappedBufferRange = WGL.GetExtension<glFlushMappedBufferRangeDelegate>("glFlushMappedBufferRange");
            glBindVertexArray = WGL.GetExtension<glBindVertexArrayDelegate>("glBindVertexArray");
            glDeleteVertexArrays = WGL.GetExtension<glDeleteVertexArraysDelegate>("glDeleteVertexArrays");
            glGenVertexArrays = WGL.GetExtension<glGenVertexArraysDelegate>("glGenVertexArrays");
            glIsVertexArray = WGL.GetExtension<glIsVertexArrayDelegate>("glIsVertexArray");
            #endregion
            #region OPENGL 3.1
            glDrawArraysInstanced = WGL.GetExtension<glDrawArraysInstancedDelegate>("glDrawArraysInstanced");
            glDrawElementsInstanced = WGL.GetExtension<glDrawElementsInstancedDelegate>("glDrawElementsInstanced");
            glTexBuffer = WGL.GetExtension<glTexBufferDelegate>("glTexBuffer");
            glPrimitiveRestartIndex = WGL.GetExtension<glPrimitiveRestartIndexDelegate>("glPrimitiveRestartIndex");
            glCopyBufferSubData = WGL.GetExtension<glCopyBufferSubDataDelegate>("glCopyBufferSubData");
            glGetUniformIndices = WGL.GetExtension<glGetUniformIndicesDelegate>("glGetUniformIndices");
            glGetActiveUniformsiv = WGL.GetExtension<glGetActiveUniformsivDelegate>("glGetActiveUniformsiv");
            glGetActiveUniformName = WGL.GetExtension<glGetActiveUniformNameDelegate>("glGetActiveUniformName");
            glGetUniformBlockIndex = WGL.GetExtension<glGetUniformBlockIndexDelegate>("glGetUniformBlockIndex");
            glGetActiveUniformBlockiv = WGL.GetExtension<glGetActiveUniformBlockivDelegate>("glGetActiveUniformBlockiv");
            glGetActiveUniformBlockName = WGL.GetExtension<glGetActiveUniformBlockNameDelegate>("glGetActiveUniformBlockName");
            glUniformBlockBinding = WGL.GetExtension<glUniformBlockBindingDelegate>("glUniformBlockBinding");
            #endregion
            #region OPENGL 3.2
            glDrawElementsBaseVertex = WGL.GetExtension<glDrawElementsBaseVertexDelegate>("glDrawElementsBaseVertex");
            glDrawRangeElementsBaseVertex = WGL.GetExtension<glDrawRangeElementsBaseVertexDelegate>("glDrawRangeElementsBaseVertex");
            glDrawElementsInstancedBaseVertex = WGL.GetExtension<glDrawElementsInstancedBaseVertexDelegate>("glDrawElementsInstancedBaseVertex");
            glMultiDrawElementsBaseVertex = WGL.GetExtension<glMultiDrawElementsBaseVertexDelegate>("glMultiDrawElementsBaseVertex");
            glProvokingVertex = WGL.GetExtension<glProvokingVertexDelegate>("glProvokingVertex");
            glFenceSync = WGL.GetExtension<glFenceSyncDelegate>("glFenceSync");
            glIsSync = WGL.GetExtension<glIsSyncDelegate>("glIsSync");
            glDeleteSync = WGL.GetExtension<glDeleteSyncDelegate>("glDeleteSync");
            glClientWaitSync = WGL.GetExtension<glClientWaitSyncDelegate>("glClientWaitSync");
            glWaitSync = WGL.GetExtension<glWaitSyncDelegate>("glWaitSync");
            glGetInteger64v = WGL.GetExtension<glGetInteger64vDelegate>("glGetInteger64v");
            glGetSynciv = WGL.GetExtension<glGetSyncivDelegate>("glGetSynciv");
            glGetInteger64i_v = WGL.GetExtension<glGetInteger64i_vDelegate>("glGetInteger64i_v");
            glGetBufferParameteri64v = WGL.GetExtension<glGetBufferParameteri64vDelegate>("glGetBufferParameteri64v");
            glFramebufferTexture = WGL.GetExtension<glFramebufferTextureDelegate>("glFramebufferTexture");
            glTexImage2DMultisample = WGL.GetExtension<glTexImage2DMultisampleDelegate>("glTexImage2DMultisample");
            glTexImage3DMultisample = WGL.GetExtension<glTexImage3DMultisampleDelegate>("glTexImage3DMultisample");
            glGetMultisamplefv = WGL.GetExtension<glGetMultisamplefvDelegate>("glGetMultisamplefv");
            glSampleMaski = WGL.GetExtension<glSampleMaskiDelegate>("glSampleMaski");
            #endregion
            #region OPENGL 3.3
            glBindFragDataLocationIndexed = WGL.GetExtension<glBindFragDataLocationIndexedDelegate>("glBindFragDataLocationIndexed");
            glGetFragDataIndex = WGL.GetExtension<glGetFragDataIndexDelegate>("glGetFragDataIndex");
            glGenSamplers = WGL.GetExtension<glGenSamplersDelegate>("glGenSamplers");
            glDeleteSamplers = WGL.GetExtension<glDeleteSamplersDelegate>("glDeleteSamplers");
            glIsSampler = WGL.GetExtension<glIsSamplerDelegate>("glIsSampler");
            glBindSampler = WGL.GetExtension<glBindSamplerDelegate>("glBindSampler");
            glSamplerParameteri = WGL.GetExtension<glSamplerParameteriDelegate>("glSamplerParameteri");
            glSamplerParameteriv = WGL.GetExtension<glSamplerParameterivDelegate>("glSamplerParameteriv");
            glSamplerParameterf = WGL.GetExtension<glSamplerParameterfDelegate>("glSamplerParameterf");
            glSamplerParameterfv = WGL.GetExtension<glSamplerParameterfvDelegate>("glSamplerParameterfv");
            glSamplerParameterIiv = WGL.GetExtension<glSamplerParameterIivDelegate>("glSamplerParameterIiv");
            glSamplerParameterIuiv = WGL.GetExtension<glSamplerParameterIuivDelegate>("glSamplerParameterIuiv");
            glGetSamplerParameteriv = WGL.GetExtension<glGetSamplerParameterivDelegate>("glGetSamplerParameteriv");
            glGetSamplerParameterIiv = WGL.GetExtension<glGetSamplerParameterIivDelegate>("glGetSamplerParameterIiv");
            glGetSamplerParameterfv = WGL.GetExtension<glGetSamplerParameterfvDelegate>("glGetSamplerParameterfv");
            glGetSamplerParameterIuiv = WGL.GetExtension<glGetSamplerParameterIuivDelegate>("glGetSamplerParameterIuiv");
            glQueryCounter = WGL.GetExtension<glQueryCounterDelegate>("glQueryCounter");
            glGetQueryObjecti64v = WGL.GetExtension<glGetQueryObjecti64vDelegate>("glGetQueryObjecti64v");
            glGetQueryObjectui64v = WGL.GetExtension<glGetQueryObjectui64vDelegate>("glGetQueryObjectui64v");
            glVertexAttribDivisor = WGL.GetExtension<glVertexAttribDivisorDelegate>("glVertexAttribDivisor");
            glVertexAttribP1ui = WGL.GetExtension<glVertexAttribP1uiDelegate>("glVertexAttribP1ui");
            glVertexAttribP1uiv = WGL.GetExtension<glVertexAttribP1uivDelegate>("glVertexAttribP1uiv");
            glVertexAttribP2ui = WGL.GetExtension<glVertexAttribP2uiDelegate>("glVertexAttribP2ui");
            glVertexAttribP2uiv = WGL.GetExtension<glVertexAttribP2uivDelegate>("glVertexAttribP2uiv");
            glVertexAttribP3ui = WGL.GetExtension<glVertexAttribP3uiDelegate>("glVertexAttribP3ui");
            glVertexAttribP3uiv = WGL.GetExtension<glVertexAttribP3uivDelegate>("glVertexAttribP3uiv");
            glVertexAttribP4ui = WGL.GetExtension<glVertexAttribP4uiDelegate>("glVertexAttribP4ui");
            glVertexAttribP4uiv = WGL.GetExtension<glVertexAttribP4uivDelegate>("glVertexAttribP4uiv");
            #endregion
            #region OPENGL 4.0
            glMinSampleShading = WGL.GetExtension<glMinSampleShadingDelegate>("glMinSampleShading");
            glBlendEquationi = WGL.GetExtension<glBlendEquationiDelegate>("glBlendEquationi");
            glBlendEquationSeparatei = WGL.GetExtension<glBlendEquationSeparateiDelegate>("glBlendEquationSeparatei");
            glBlendFunci = WGL.GetExtension<glBlendFunciDelegate>("glBlendFunci");
            glBlendFuncSeparatei = WGL.GetExtension<glBlendFuncSeparateiDelegate>("glBlendFuncSeparatei");
            glDrawArraysIndirect = WGL.GetExtension<glDrawArraysIndirectDelegate>("glDrawArraysIndirect");
            glDrawElementsIndirect = WGL.GetExtension<glDrawElementsIndirectDelegate>("glDrawElementsIndirect");
            glUniform1d = WGL.GetExtension<glUniform1dDelegate>("glUniform1d");
            glUniform2d = WGL.GetExtension<glUniform2dDelegate>("glUniform2d");
            glUniform3d = WGL.GetExtension<glUniform3dDelegate>("glUniform3d");
            glUniform4d = WGL.GetExtension<glUniform4dDelegate>("glUniform4d");
            glUniform1dv = WGL.GetExtension<glUniform1dvDelegate>("glUniform1dv");
            glUniform2dv = WGL.GetExtension<glUniform2dvDelegate>("glUniform2dv");
            glUniform3dv = WGL.GetExtension<glUniform3dvDelegate>("glUniform3dv");
            glUniform4dv = WGL.GetExtension<glUniform4dvDelegate>("glUniform4dv");
            glUniformMatrix2dv = WGL.GetExtension<glUniformMatrix2dvDelegate>("glUniformMatrix2dv");
            glUniformMatrix3dv = WGL.GetExtension<glUniformMatrix3dvDelegate>("glUniformMatrix3dv");
            glUniformMatrix4dv = WGL.GetExtension<glUniformMatrix4dvDelegate>("glUniformMatrix4dv");
            glUniformMatrix2x3dv = WGL.GetExtension<glUniformMatrix2x3dvDelegate>("glUniformMatrix2x3dv");
            glUniformMatrix2x4dv = WGL.GetExtension<glUniformMatrix2x4dvDelegate>("glUniformMatrix2x4dv");
            glUniformMatrix3x2dv = WGL.GetExtension<glUniformMatrix3x2dvDelegate>("glUniformMatrix3x2dv");
            glUniformMatrix3x4dv = WGL.GetExtension<glUniformMatrix3x4dvDelegate>("glUniformMatrix3x4dv");
            glUniformMatrix4x2dv = WGL.GetExtension<glUniformMatrix4x2dvDelegate>("glUniformMatrix4x2dv");
            glUniformMatrix4x3dv = WGL.GetExtension<glUniformMatrix4x3dvDelegate>("glUniformMatrix4x3dv");
            glGetUniformdv = WGL.GetExtension<glGetUniformdvDelegate>("glGetUniformdv");
            glGetSubroutineUniformLocation = WGL.GetExtension<glGetSubroutineUniformLocationDelegate>("glGetSubroutineUniformLocation");
            glGetSubroutineIndex = WGL.GetExtension<glGetSubroutineIndexDelegate>("glGetSubroutineIndex");
            glGetActiveSubroutineUniformiv = WGL.GetExtension<glGetActiveSubroutineUniformivDelegate>("glGetActiveSubroutineUniformiv");
            glGetActiveSubroutineUniformName = WGL.GetExtension<glGetActiveSubroutineUniformNameDelegate>("glGetActiveSubroutineUniformName");
            glGetActiveSubroutineName = WGL.GetExtension<glGetActiveSubroutineNameDelegate>("glGetActiveSubroutineName");
            glUniformSubroutinesuiv = WGL.GetExtension<glUniformSubroutinesuivDelegate>("glUniformSubroutinesuiv");
            glGetUniformSubroutineuiv = WGL.GetExtension<glGetUniformSubroutineuivDelegate>("glGetUniformSubroutineuiv");
            glGetProgramStageiv = WGL.GetExtension<glGetProgramStageivDelegate>("glGetProgramStageiv");
            glPatchParameteri = WGL.GetExtension<glPatchParameteriDelegate>("glPatchParameteri");
            glPatchParameterfv = WGL.GetExtension<glPatchParameterfvDelegate>("glPatchParameterfv");
            glBindTransformFeedback = WGL.GetExtension<glBindTransformFeedbackDelegate>("glBindTransformFeedback");
            glDeleteTransformFeedbacks = WGL.GetExtension<glDeleteTransformFeedbacksDelegate>("glDeleteTransformFeedbacks");
            glGenTransformFeedbacks = WGL.GetExtension<glGenTransformFeedbacksDelegate>("glGenTransformFeedbacks");
            glIsTransformFeedback = WGL.GetExtension<glIsTransformFeedbackDelegate>("glIsTransformFeedback");
            glPauseTransformFeedback = WGL.GetExtension<glPauseTransformFeedbackDelegate>("glPauseTransformFeedback");
            glResumeTransformFeedback = WGL.GetExtension<glResumeTransformFeedbackDelegate>("glResumeTransformFeedback");
            glDrawTransformFeedback = WGL.GetExtension<glDrawTransformFeedbackDelegate>("glDrawTransformFeedback");
            glDrawTransformFeedbackStream = WGL.GetExtension<glDrawTransformFeedbackStreamDelegate>("glDrawTransformFeedbackStream");
            glBeginQueryIndexed = WGL.GetExtension<glBeginQueryIndexedDelegate>("glBeginQueryIndexed");
            glEndQueryIndexed = WGL.GetExtension<glEndQueryIndexedDelegate>("glEndQueryIndexed");
            glGetQueryIndexediv = WGL.GetExtension<glGetQueryIndexedivDelegate>("glGetQueryIndexediv");
            #endregion
            #region OPENGL 4.1
            glReleaseShaderCompiler = WGL.GetExtension<glReleaseShaderCompilerDelegate>("glReleaseShaderCompiler");
            glShaderBinary = WGL.GetExtension<glShaderBinaryDelegate>("glShaderBinary");
            glGetShaderPrecisionFormat = WGL.GetExtension<glGetShaderPrecisionFormatDelegate>("glGetShaderPrecisionFormat");
            glDepthRangef = WGL.GetExtension<glDepthRangefDelegate>("glDepthRangef");
            glClearDepthf = WGL.GetExtension<glClearDepthfDelegate>("glClearDepthf");
            glGetProgramBinary = WGL.GetExtension<glGetProgramBinaryDelegate>("glGetProgramBinary");
            glProgramBinary = WGL.GetExtension<glProgramBinaryDelegate>("glProgramBinary");
            glProgramParameteri = WGL.GetExtension<glProgramParameteriDelegate>("glProgramParameteri");
            glUseProgramStages = WGL.GetExtension<glUseProgramStagesDelegate>("glUseProgramStages");
            glActiveShaderProgram = WGL.GetExtension<glActiveShaderProgramDelegate>("glActiveShaderProgram");
            glCreateShaderProgramv = WGL.GetExtension<glCreateShaderProgramvDelegate>("glCreateShaderProgramv");
            glBindProgramPipeline = WGL.GetExtension<glBindProgramPipelineDelegate>("glBindProgramPipeline");
            glDeleteProgramPipelines = WGL.GetExtension<glDeleteProgramPipelinesDelegate>("glDeleteProgramPipelines");
            glGenProgramPipelines = WGL.GetExtension<glGenProgramPipelinesDelegate>("glGenProgramPipelines");
            glIsProgramPipeline = WGL.GetExtension<glIsProgramPipelineDelegate>("glIsProgramPipeline");
            glGetProgramPipelineiv = WGL.GetExtension<glGetProgramPipelineivDelegate>("glGetProgramPipelineiv");
            glProgramUniform1i = WGL.GetExtension<glProgramUniform1iDelegate>("glProgramUniform1i");
            glProgramUniform1iv = WGL.GetExtension<glProgramUniform1ivDelegate>("glProgramUniform1iv");
            glProgramUniform1f = WGL.GetExtension<glProgramUniform1fDelegate>("glProgramUniform1f");
            glProgramUniform1fv = WGL.GetExtension<glProgramUniform1fvDelegate>("glProgramUniform1fv");
            glProgramUniform1d = WGL.GetExtension<glProgramUniform1dDelegate>("glProgramUniform1d");
            glProgramUniform1dv = WGL.GetExtension<glProgramUniform1dvDelegate>("glProgramUniform1dv");
            glProgramUniform1ui = WGL.GetExtension<glProgramUniform1uiDelegate>("glProgramUniform1ui");
            glProgramUniform1uiv = WGL.GetExtension<glProgramUniform1uivDelegate>("glProgramUniform1uiv");
            glProgramUniform2i = WGL.GetExtension<glProgramUniform2iDelegate>("glProgramUniform2i");
            glProgramUniform2iv = WGL.GetExtension<glProgramUniform2ivDelegate>("glProgramUniform2iv");
            glProgramUniform2f = WGL.GetExtension<glProgramUniform2fDelegate>("glProgramUniform2f");
            glProgramUniform2fv = WGL.GetExtension<glProgramUniform2fvDelegate>("glProgramUniform2fv");
            glProgramUniform2d = WGL.GetExtension<glProgramUniform2dDelegate>("glProgramUniform2d");
            glProgramUniform2dv = WGL.GetExtension<glProgramUniform2dvDelegate>("glProgramUniform2dv");
            glProgramUniform2ui = WGL.GetExtension<glProgramUniform2uiDelegate>("glProgramUniform2ui");
            glProgramUniform2uiv = WGL.GetExtension<glProgramUniform2uivDelegate>("glProgramUniform2uiv");
            glProgramUniform3i = WGL.GetExtension<glProgramUniform3iDelegate>("glProgramUniform3i");
            glProgramUniform3iv = WGL.GetExtension<glProgramUniform3ivDelegate>("glProgramUniform3iv");
            glProgramUniform3f = WGL.GetExtension<glProgramUniform3fDelegate>("glProgramUniform3f");
            glProgramUniform3fv = WGL.GetExtension<glProgramUniform3fvDelegate>("glProgramUniform3fv");
            glProgramUniform3d = WGL.GetExtension<glProgramUniform3dDelegate>("glProgramUniform3d");
            glProgramUniform3dv = WGL.GetExtension<glProgramUniform3dvDelegate>("glProgramUniform3dv");
            glProgramUniform3ui = WGL.GetExtension<glProgramUniform3uiDelegate>("glProgramUniform3ui");
            glProgramUniform3uiv = WGL.GetExtension<glProgramUniform3uivDelegate>("glProgramUniform3uiv");
            glProgramUniform4i = WGL.GetExtension<glProgramUniform4iDelegate>("glProgramUniform4i");
            glProgramUniform4iv = WGL.GetExtension<glProgramUniform4ivDelegate>("glProgramUniform4iv");
            glProgramUniform4f = WGL.GetExtension<glProgramUniform4fDelegate>("glProgramUniform4f");
            glProgramUniform4fv = WGL.GetExtension<glProgramUniform4fvDelegate>("glProgramUniform4fv");
            glProgramUniform4d = WGL.GetExtension<glProgramUniform4dDelegate>("glProgramUniform4d");
            glProgramUniform4dv = WGL.GetExtension<glProgramUniform4dvDelegate>("glProgramUniform4dv");
            glProgramUniform4ui = WGL.GetExtension<glProgramUniform4uiDelegate>("glProgramUniform4ui");
            glProgramUniform4uiv = WGL.GetExtension<glProgramUniform4uivDelegate>("glProgramUniform4uiv");
            glProgramUniformMatrix2fv = WGL.GetExtension<glProgramUniformMatrix2fvDelegate>("glProgramUniformMatrix2fv");
            glProgramUniformMatrix3fv = WGL.GetExtension<glProgramUniformMatrix3fvDelegate>("glProgramUniformMatrix3fv");
            glProgramUniformMatrix4fv = WGL.GetExtension<glProgramUniformMatrix4fvDelegate>("glProgramUniformMatrix4fv");
            glProgramUniformMatrix2dv = WGL.GetExtension<glProgramUniformMatrix2dvDelegate>("glProgramUniformMatrix2dv");
            glProgramUniformMatrix3dv = WGL.GetExtension<glProgramUniformMatrix3dvDelegate>("glProgramUniformMatrix3dv");
            glProgramUniformMatrix4dv = WGL.GetExtension<glProgramUniformMatrix4dvDelegate>("glProgramUniformMatrix4dv");
            glProgramUniformMatrix2x3fv = WGL.GetExtension<glProgramUniformMatrix2x3fvDelegate>("glProgramUniformMatrix2x3fv");
            glProgramUniformMatrix3x2fv = WGL.GetExtension<glProgramUniformMatrix3x2fvDelegate>("glProgramUniformMatrix3x2fv");
            glProgramUniformMatrix2x4fv = WGL.GetExtension<glProgramUniformMatrix2x4fvDelegate>("glProgramUniformMatrix2x4fv");
            glProgramUniformMatrix4x2fv = WGL.GetExtension<glProgramUniformMatrix4x2fvDelegate>("glProgramUniformMatrix4x2fv");
            glProgramUniformMatrix3x4fv = WGL.GetExtension<glProgramUniformMatrix3x4fvDelegate>("glProgramUniformMatrix3x4fv");
            glProgramUniformMatrix4x3fv = WGL.GetExtension<glProgramUniformMatrix4x3fvDelegate>("glProgramUniformMatrix4x3fv");
            glProgramUniformMatrix2x3dv = WGL.GetExtension<glProgramUniformMatrix2x3dvDelegate>("glProgramUniformMatrix2x3dv");
            glProgramUniformMatrix3x2dv = WGL.GetExtension<glProgramUniformMatrix3x2dvDelegate>("glProgramUniformMatrix3x2dv");
            glProgramUniformMatrix2x4dv = WGL.GetExtension<glProgramUniformMatrix2x4dvDelegate>("glProgramUniformMatrix2x4dv");
            glProgramUniformMatrix4x2dv = WGL.GetExtension<glProgramUniformMatrix4x2dvDelegate>("glProgramUniformMatrix4x2dv");
            glProgramUniformMatrix3x4dv = WGL.GetExtension<glProgramUniformMatrix3x4dvDelegate>("glProgramUniformMatrix3x4dv");
            glProgramUniformMatrix4x3dv = WGL.GetExtension<glProgramUniformMatrix4x3dvDelegate>("glProgramUniformMatrix4x3dv");
            glValidateProgramPipeline = WGL.GetExtension<glValidateProgramPipelineDelegate>("glValidateProgramPipeline");
            glGetProgramPipelineInfoLog = WGL.GetExtension<glGetProgramPipelineInfoLogDelegate>("glGetProgramPipelineInfoLog");
            glVertexAttribL1d = WGL.GetExtension<glVertexAttribL1dDelegate>("glVertexAttribL1d");
            glVertexAttribL2d = WGL.GetExtension<glVertexAttribL2dDelegate>("glVertexAttribL2d");
            glVertexAttribL3d = WGL.GetExtension<glVertexAttribL3dDelegate>("glVertexAttribL3d");
            glVertexAttribL4d = WGL.GetExtension<glVertexAttribL4dDelegate>("glVertexAttribL4d");
            glVertexAttribL1dv = WGL.GetExtension<glVertexAttribL1dvDelegate>("glVertexAttribL1dv");
            glVertexAttribL2dv = WGL.GetExtension<glVertexAttribL2dvDelegate>("glVertexAttribL2dv");
            glVertexAttribL3dv = WGL.GetExtension<glVertexAttribL3dvDelegate>("glVertexAttribL3dv");
            glVertexAttribL4dv = WGL.GetExtension<glVertexAttribL4dvDelegate>("glVertexAttribL4dv");
            glVertexAttribLPointer = WGL.GetExtension<glVertexAttribLPointerDelegate>("glVertexAttribLPointer");
            glGetVertexAttribLdv = WGL.GetExtension<glGetVertexAttribLdvDelegate>("glGetVertexAttribLdv");
            glViewportArrayv = WGL.GetExtension<glViewportArrayvDelegate>("glViewportArrayv");
            glViewportIndexedf = WGL.GetExtension<glViewportIndexedfDelegate>("glViewportIndexedf");
            glViewportIndexedfv = WGL.GetExtension<glViewportIndexedfvDelegate>("glViewportIndexedfv");
            glScissorArrayv = WGL.GetExtension<glScissorArrayvDelegate>("glScissorArrayv");
            glScissorIndexed = WGL.GetExtension<glScissorIndexedDelegate>("glScissorIndexed");
            glScissorIndexedv = WGL.GetExtension<glScissorIndexedvDelegate>("glScissorIndexedv");
            glDepthRangeArrayv = WGL.GetExtension<glDepthRangeArrayvDelegate>("glDepthRangeArrayv");
            glDepthRangeIndexed = WGL.GetExtension<glDepthRangeIndexedDelegate>("glDepthRangeIndexed");
            glGetFloati_v = WGL.GetExtension<glGetFloati_vDelegate>("glGetFloati_v");
            glGetDoublei_v = WGL.GetExtension<glGetDoublei_vDelegate>("glGetDoublei_v");
            #endregion
            #region OPENGL 4.2
            glDrawArraysInstancedBaseInstance = WGL.GetExtension<glDrawArraysInstancedBaseInstanceDelegate>("glDrawArraysInstancedBaseInstance");
            glDrawElementsInstancedBaseInstance = WGL.GetExtension<glDrawElementsInstancedBaseInstanceDelegate>("glDrawElementsInstancedBaseInstance");
            glDrawElementsInstancedBaseVertexBaseInstance = WGL.GetExtension<glDrawElementsInstancedBaseVertexBaseInstanceDelegate>("glDrawElementsInstancedBaseVertexBaseInstance");
            glGetInternalformativ = WGL.GetExtension<glGetInternalformativDelegate>("glGetInternalformativ");
            glGetActiveAtomicCounterBufferiv = WGL.GetExtension<glGetActiveAtomicCounterBufferivDelegate>("glGetActiveAtomicCounterBufferiv");
            glBindImageTexture = WGL.GetExtension<glBindImageTextureDelegate>("glBindImageTexture");
            glMemoryBarrier = WGL.GetExtension<glMemoryBarrierDelegate>("glMemoryBarrier");
            glTexStorage1D = WGL.GetExtension<glTexStorage1DDelegate>("glTexStorage1D");
            glTexStorage2D = WGL.GetExtension<glTexStorage2DDelegate>("glTexStorage2D");
            glTexStorage3D = WGL.GetExtension<glTexStorage3DDelegate>("glTexStorage3D");
            glDrawTransformFeedbackInstanced = WGL.GetExtension<glDrawTransformFeedbackInstancedDelegate>("glDrawTransformFeedbackInstanced");
            glDrawTransformFeedbackStreamInstanced = WGL.GetExtension<glDrawTransformFeedbackStreamInstancedDelegate>("glDrawTransformFeedbackStreamInstanced");
            #endregion
            #region OPENGL 4.3
            glClearBufferData = WGL.GetExtension<glClearBufferDataDelegate>("glClearBufferData");
            glClearBufferSubData = WGL.GetExtension<glClearBufferSubDataDelegate>("glClearBufferSubData");
            glDispatchCompute = WGL.GetExtension<glDispatchComputeDelegate>("glDispatchCompute");
            glDispatchComputeIndirect = WGL.GetExtension<glDispatchComputeIndirectDelegate>("glDispatchComputeIndirect");
            glCopyImageSubData = WGL.GetExtension<glCopyImageSubDataDelegate>("glCopyImageSubData");
            glFramebufferParameteri = WGL.GetExtension<glFramebufferParameteriDelegate>("glFramebufferParameteri");
            glGetFramebufferParameteriv = WGL.GetExtension<glGetFramebufferParameterivDelegate>("glGetFramebufferParameteriv");
            glGetInternalformati64v = WGL.GetExtension<glGetInternalformati64vDelegate>("glGetInternalformati64v");
            glInvalidateTexSubImage = WGL.GetExtension<glInvalidateTexSubImageDelegate>("glInvalidateTexSubImage");
            glInvalidateTexImage = WGL.GetExtension<glInvalidateTexImageDelegate>("glInvalidateTexImage");
            glInvalidateBufferSubData = WGL.GetExtension<glInvalidateBufferSubDataDelegate>("glInvalidateBufferSubData");
            glInvalidateBufferData = WGL.GetExtension<glInvalidateBufferDataDelegate>("glInvalidateBufferData");
            glInvalidateFramebuffer = WGL.GetExtension<glInvalidateFramebufferDelegate>("glInvalidateFramebuffer");
            glInvalidateSubFramebuffer = WGL.GetExtension<glInvalidateSubFramebufferDelegate>("glInvalidateSubFramebuffer");
            glMultiDrawArraysIndirect = WGL.GetExtension<glMultiDrawArraysIndirectDelegate>("glMultiDrawArraysIndirect");
            glMultiDrawElementsIndirect = WGL.GetExtension<glMultiDrawElementsIndirectDelegate>("glMultiDrawElementsIndirect");
            glGetProgramInterfaceiv = WGL.GetExtension<glGetProgramInterfaceivDelegate>("glGetProgramInterfaceiv");
            glGetProgramResourceIndex = WGL.GetExtension<glGetProgramResourceIndexDelegate>("glGetProgramResourceIndex");
            glGetProgramResourceName = WGL.GetExtension<glGetProgramResourceNameDelegate>("glGetProgramResourceName");
            glGetProgramResourceiv = WGL.GetExtension<glGetProgramResourceivDelegate>("glGetProgramResourceiv");
            glGetProgramResourceLocation = WGL.GetExtension<glGetProgramResourceLocationDelegate>("glGetProgramResourceLocation");
            glGetProgramResourceLocationIndex = WGL.GetExtension<glGetProgramResourceLocationIndexDelegate>("glGetProgramResourceLocationIndex");
            glShaderStorageBlockBinding = WGL.GetExtension<glShaderStorageBlockBindingDelegate>("glShaderStorageBlockBinding");
            glTexBufferRange = WGL.GetExtension<glTexBufferRangeDelegate>("glTexBufferRange");
            glTexStorage2DMultisample = WGL.GetExtension<glTexStorage2DMultisampleDelegate>("glTexStorage2DMultisample");
            glTexStorage3DMultisample = WGL.GetExtension<glTexStorage3DMultisampleDelegate>("glTexStorage3DMultisample");
            glTextureView = WGL.GetExtension<glTextureViewDelegate>("glTextureView");
            glBindVertexBuffer = WGL.GetExtension<glBindVertexBufferDelegate>("glBindVertexBuffer");
            glVertexAttribFormat = WGL.GetExtension<glVertexAttribFormatDelegate>("glVertexAttribFormat");
            glVertexAttribIFormat = WGL.GetExtension<glVertexAttribIFormatDelegate>("glVertexAttribIFormat");
            glVertexAttribLFormat = WGL.GetExtension<glVertexAttribLFormatDelegate>("glVertexAttribLFormat");
            glVertexAttribBinding = WGL.GetExtension<glVertexAttribBindingDelegate>("glVertexAttribBinding");
            glVertexBindingDivisor = WGL.GetExtension<glVertexBindingDivisorDelegate>("glVertexBindingDivisor");
            glDebugMessageControl = WGL.GetExtension<glDebugMessageControlDelegate>("glDebugMessageControl");
            glDebugMessageInsert = WGL.GetExtension<glDebugMessageInsertDelegate>("glDebugMessageInsert");
            glDebugMessageCallback = WGL.GetExtension<glDebugMessageCallbackDelegate>("glDebugMessageCallback");
            glGetDebugMessageLog = WGL.GetExtension<glGetDebugMessageLogDelegate>("glGetDebugMessageLog");
            glPushDebugGroup = WGL.GetExtension<glPushDebugGroupDelegate>("glPushDebugGroup");
            glPopDebugGroup = WGL.GetExtension<glPopDebugGroupDelegate>("glPopDebugGroup");
            glObjectLabel = WGL.GetExtension<glObjectLabelDelegate>("glObjectLabel");
            glGetObjectLabel = WGL.GetExtension<glGetObjectLabelDelegate>("glGetObjectLabel");
            glObjectPtrLabel = WGL.GetExtension<glObjectPtrLabelDelegate>("glObjectPtrLabel");
            glGetObjectPtrLabel = WGL.GetExtension<glGetObjectPtrLabelDelegate>("glGetObjectPtrLabel");
            #endregion
            #region OPENGL 4.4
            glBufferStorage = WGL.GetExtension<glBufferStorageDelegate>("glBufferStorage");
            glClearTexImage = WGL.GetExtension<glClearTexImageDelegate>("glClearTexImage");
            glClearTexSubImage = WGL.GetExtension<glClearTexSubImageDelegate>("glClearTexSubImage");
            glBindBuffersBase = WGL.GetExtension<glBindBuffersBaseDelegate>("glBindBuffersBase");
            glBindBuffersRange = WGL.GetExtension<glBindBuffersRangeDelegate>("glBindBuffersRange");
            glBindTextures = WGL.GetExtension<glBindTexturesDelegate>("glBindTextures");
            glBindSamplers = WGL.GetExtension<glBindSamplersDelegate>("glBindSamplers");
            glBindImageTextures = WGL.GetExtension<glBindImageTexturesDelegate>("glBindImageTextures");
            glBindVertexBuffers = WGL.GetExtension<glBindVertexBuffersDelegate>("glBindVertexBuffers");
            #endregion
            Logger.WriteLine("GL Extensions loaded");
        }
    }
}
