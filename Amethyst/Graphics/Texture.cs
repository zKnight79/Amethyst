using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using Amethyst.Graphics.OpenGL;

namespace Amethyst.Graphics
{
    public enum TextureFiltering
    {
        Nearest,
        Linear,
        Bilinear
    }

    /// <summary>
    /// Represent a 2D Texture
    /// </summary>
    public class Texture : IDisposable
    {
        /// <summary>
        /// Get the ID of the texture
        /// </summary>
        public int ID { get; private set; }
        /// <summary>
        /// Get the base-image width of the texture
        /// </summary>
        public int Width { get; private set; }
        /// <summary>
        /// Get the base-image height of the texture
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Creates a new Texture from a GDI Bitmap, with given colorkey
        /// </summary>
        /// <param name="bmp">The GDI bitmap that will fill texture data</param>
        /// <param name="colorKey">The color that is assumed to be transparent</param>
        public Texture(Bitmap bmp, Color colorKey, TextureFiltering filtering)
        {
            Bitmap bmpTex = new Bitmap(bmp);
            if (colorKey != Color.Empty)
            {
                bmpTex.MakeTransparent(colorKey);
            }

            Width = bmpTex.Width;
            Height = bmpTex.Height;
            int id;
            GL.GenTextures(1, out id);
            ID = id;
            SetFilter(filtering);
            GL.TexParameter(TextureTarget.GL_TEXTURE_2D, TextureParamName.GL_TEXTURE_WRAP_S, (int)GLConst.GL_REPEAT);
            GL.TexParameter(TextureTarget.GL_TEXTURE_2D, TextureParamName.GL_TEXTURE_WRAP_T, (int)GLConst.GL_REPEAT);

            BitmapData data = bmpTex.LockBits(new Rectangle(0, 0, bmpTex.Width, bmpTex.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexImage2D(TextureTarget.GL_TEXTURE_2D, 0, PixelInternalFormat.GL_RGBA, bmpTex.Width, bmpTex.Height, 0, OpenGL.PixelFormat.GL_BGRA, PixelType.GL_UNSIGNED_BYTE, data.Scan0);
            bmpTex.UnlockBits(data);

            bmpTex.Dispose();
        }
        public Texture(Bitmap bmp, Color colorKey)
            : this(bmp, colorKey, TextureFiltering.Nearest) { }
        public Texture(Bitmap bmp, TextureFiltering filtering)
            : this(bmp, Color.Empty, filtering) { }
        public Texture(Bitmap bmp)
            : this(bmp, Color.Empty) { }
        /// <summary>
        /// Creates a new Texture from an image file, with given colorkey
        /// </summary>
        /// <param name="fileName">The filename of the image that will fill texture data</param>
        /// <param name="colorKey">The color that is assumed to be transparent</param>
        public Texture(string fileName, Color colorKey, TextureFiltering filtering)
            : this(new Bitmap(TexturePath.GetFilePath(fileName)), colorKey, filtering) { }
        public Texture(string fileName, Color colorKey)
            : this(new Bitmap(TexturePath.GetFilePath(fileName)), colorKey) { }
        public Texture(string fileName, TextureFiltering filtering)
            : this(new Bitmap(TexturePath.GetFilePath(fileName)), filtering) { }
        public Texture(string fileName)
            : this(new Bitmap(TexturePath.GetFilePath(fileName))) { }

        /// <summary>
        /// Delete the texture
        /// </summary>
        public void Dispose()
        {
            int id = ID;
            GL.DeleteTextures(1, ref id);
            ID = 0;
        }

        /// <summary>
        /// Compute U texture coord from a X pixel coord
        /// </summary>
        /// <param name="x">The X pixel coord</param>
        /// <returns>The U texture coord</returns>
        public float UFromPixelX(float x)
        {
            return x / Width;
        }
        /// <summary>
        /// Compute V texture coord from a Y pixel coord
        /// </summary>
        /// <param name="y">The Y pixel coord</param>
        /// <returns>The V texture coord</returns>
        public float VFromPixelY(float y)
        {
            return y / Height;
        }

        /// <summary>
        /// Bind the texture to the current active texture unit
        /// </summary>
        public void Bind()
        {
            GL.BindTexture(TextureTarget.GL_TEXTURE_2D, ID);
        }

        /// <summary>
        /// Set texture filter
        /// </summary>
        /// <param name="minFilter">Minification filter</param>
        /// <param name="magFilter">Magnification filter</param>
        public void SetFilter(TextureFilter minFilter, TextureFilter magFilter)
        {
            Bind();
            GL.TexParameter(TextureTarget.GL_TEXTURE_2D, TextureParamName.GL_TEXTURE_MIN_FILTER, (int)minFilter);
            GL.TexParameter(TextureTarget.GL_TEXTURE_2D, TextureParamName.GL_TEXTURE_MAG_FILTER, (int)magFilter);
        }
        public void SetFilter(TextureFiltering filtering)
        {
            switch (filtering)
            {
                case TextureFiltering.Linear:
                    SetFilter(TextureFilter.GL_NEAREST, TextureFilter.GL_LINEAR);
                    break;
                case TextureFiltering.Bilinear:
                    SetFilter(TextureFilter.GL_LINEAR, TextureFilter.GL_LINEAR);
                    break;
                case TextureFiltering.Nearest:
                default:
                    SetFilter(TextureFilter.GL_NEAREST, TextureFilter.GL_NEAREST);
                    break;
            }
        }
        /// <summary>
        /// Set anisotropy filter
        /// </summary>
        /// <param name="maxAnisotropy">Max anisotropy. Set it to 1 for standard filtering</param>
        public void SetAnisotropy(float maxAnisotropy)
        {
            Bind();
            GL.TexParameter(TextureTarget.GL_TEXTURE_2D, TextureParamName.GL_TEXTURE_MAX_ANISOTROPY_EXT, maxAnisotropy);
        }
    }

    public static class TexturePath
    {
        static List<string> m_PathList = new List<string>(new string[] { "" });

        public static void AddPath(string path)
        {
            if (!m_PathList.Contains(path))
            {
                m_PathList.Add(path);
            }
        }

        public static string GetFilePath(string fileName)
        {
            foreach (string path in m_PathList)
            {
                string p = Path.Combine(path, fileName);
                if (File.Exists(p))
                {
                    return p;
                }
            }
            return fileName;
        }
    }
}
