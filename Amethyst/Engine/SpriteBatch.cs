using Amethyst.Graphics;
using Amethyst.Graphics.BMFont;
using Amethyst.Graphics.OpenGL;
using Amethyst.Math;
using System.Collections.Generic;

namespace Amethyst.Engine
{
    /// <summary>
    /// SpriteBatch is the class that contains all base drawing methods for Amethyst<br />
    /// It's designed to buffer rendering in an efficient way
    /// </summary>
    public class SpriteBatch
    {
        Texture m_ShapeTexture = new Texture(Textures.Blank);
        GLSLProgram m_Program = null;
        List<SpriteBatchQueueItem> m_SpriteBatchQueue = new List<SpriteBatchQueueItem>();
        int m_VAO = -1;
        int m_VBO = -1;

        /// <summary>
        /// Creates a new instance of SpriteBatch
        /// </summary>
        public SpriteBatch()
        {
            GL.GenVertexArrays(1, out m_VAO);
            GL.BindVertexArray(m_VAO);
            GL.GenBuffers(1, out m_VBO);
        }

        private SpriteBatchQueueItem GetLastQueueItem(Texture texture)
        {
            if ((m_SpriteBatchQueue.Count == 0) || (m_SpriteBatchQueue[m_SpriteBatchQueue.Count - 1].Texture != texture))
            {
                m_SpriteBatchQueue.Add(new SpriteBatchQueueItem(texture));
            }
            SpriteBatchQueueItem spqi = m_SpriteBatchQueue[m_SpriteBatchQueue.Count - 1];
            return spqi;
        }

        /// <summary>
        /// Begin SpriteBatch with a given GLSL Program
        /// </summary>
        /// <param name="program2D">The GLSL Program used for this rendering</param>
        public void Begin(GLSLProgram program2D)
        {
            m_Program = program2D;
            m_SpriteBatchQueue.Clear();
        }
        /// <summary>
        /// Render all drawing "commands" that have been sent to the SpriteBatch since the Begin() call
        /// </summary>
        public void End()
        {
            m_Program.Use();

            GL.BindVertexArray(m_VAO);
            GL.BindBuffer(BufferTarget.GL_ARRAY_BUFFER, m_VBO);

            foreach (SpriteBatchQueueItem spqi in m_SpriteBatchQueue)
            {
                if (spqi.Vertices.Count == 0)
                {
                    continue;
                }

                #region GENERATE VBO
                Vertex[] vertices = spqi.Vertices.ToArray();
                GL.BufferData<Vertex>(BufferTarget.GL_ARRAY_BUFFER, Vertex.Size * vertices.Length, vertices, BufferUsage.GL_STATIC_DRAW);
                int loc = m_Program.VertexPositionLocation;
                GL.EnableVertexAttribArray(loc);
                GL.VertexAttribPointer(loc, Vertex.PositionSize, VertexAttribType.GL_FLOAT, false, Vertex.Size, Vertex.PositionOffset);
                loc = m_Program.VertexColorLocation;
                GL.EnableVertexAttribArray(loc);
                GL.VertexAttribPointer(loc, Vertex.ColorSize, VertexAttribType.GL_FLOAT, false, Vertex.Size, Vertex.ColorOffset);
                loc = m_Program.VertexTextureCoordLocation;
                GL.EnableVertexAttribArray(loc);
                GL.VertexAttribPointer(loc, Vertex.TexCoordSize, VertexAttribType.GL_FLOAT, false, Vertex.Size, Vertex.TexCoordOffset);
                #endregion

                #region DRAW VAO
                GL.ActiveTexture(TextureUnit.GL_TEXTURE0);
                spqi.Texture.Bind();
                m_Program.ChangeTextureSampler(0);
                GL.BindVertexArray(m_VAO);
                GL.DrawArrays(DrawMode.GL_TRIANGLES, 0, vertices.Length);
                #endregion
            }

            m_Program = null;
        }

        /// <summary>
        /// Fill a rectangle with a given color.<br />
        /// Rectangle can be rotated
        /// </summary>
        /// <param name="dest">Destination rectangle</param>
        /// <param name="color">The color of the rectangle</param>
        /// <param name="angle">The rotation angle</param>
        public void FillRectangle(Box dest, Color4 color, float angle = 0f)
        {
            SpriteBatchQueueItem spqi = GetLastQueueItem(m_ShapeTexture);

            spqi.AddQuad(null, dest, color, angle, null, FlipEffect.None);
        }
        /// <summary>
        /// Draw the outline of a rectangle.
        /// </summary>
        /// <param name="dest">Destination rectangle</param>
        /// <param name="thickness">Thickness of the outline</param>
        /// <param name="color">Color of the outline</param>
        /// <param name="angle">The rotation angle</param>
        public void DrawRectangle(Box dest, int thickness, Color4 color, float angle = 0f)
        {
            SpriteBatchQueueItem spqi = GetLastQueueItem(m_ShapeTexture);

            Vector2 rotCenter = new Vector2(dest.Center);
            float t = thickness / 2f;
            Box rDest = new Box(dest.Left - t, dest.Top - t, dest.Width + thickness, thickness);
            spqi.AddQuad(null, rDest, color, angle, rotCenter, FlipEffect.None);
            rDest = new Box(dest.Left - t, dest.Top - t, thickness, dest.Height + thickness);
            spqi.AddQuad(null, rDest, color, angle, rotCenter, FlipEffect.None);
            rDest = new Box(dest.Right - t, dest.Top - t, thickness, dest.Height + thickness);
            spqi.AddQuad(null, rDest, color, angle, rotCenter, FlipEffect.None);
            rDest = new Box(dest.Left - t, dest.Bottom - t, dest.Width + thickness, thickness);
            spqi.AddQuad(null, rDest, color, angle, rotCenter, FlipEffect.None);
        }
        /// <summary>
        /// Draw a line between 2 points
        /// </summary>
        /// <param name="start">The start point</param>
        /// <param name="end">The end point</param>
        /// <param name="thickness">The tickness of the line</param>
        /// <param name="color">The color of the line</param>
        public void DrawLine(Point start, Point end, int thickness, Color4 color)
        {
            SpriteBatchQueueItem spqi = GetLastQueueItem(m_ShapeTexture);

            Vector2 dir = new Vector2(end - start).Normalized;
            float halfThick = thickness / 2.0f;
            float cos = halfThick * dir.X;
            float sin = halfThick * dir.Y;
            Vector2[] xy = new Vector2[4];
            xy[0] = new Vector2(start.X - cos + sin, start.Y - cos - sin);
            xy[1] = new Vector2(start.X - cos - sin, start.Y + cos - sin);
            xy[2] = new Vector2(end.X + cos + sin, end.Y - cos + sin);
            xy[3] = new Vector2(end.X + cos - sin, end.Y + cos + sin);

            spqi.AddQuad(null, xy, color, 0, null, FlipEffect.None);
        }
        /// <summary>
        /// Draw a texture
        /// </summary>
        /// <param name="texture">The texture to draw</param>
        /// <param name="textureRegion">The part of the texture to draw, or null to render all the texture</param>
        /// <param name="dest">The destination rectangle</param>
        /// <param name="color">The color to apply to the texture</param>
        /// <param name="angle">The rotation angle</param>
        /// <param name="flipEffect">The flip effect to apply to the texture</param>
        public void DrawTexture(Texture texture, Box? textureRegion, Box dest, Color4 color, float angle = 0f, FlipEffect flipEffect = FlipEffect.None)
        {
            SpriteBatchQueueItem spqi = GetLastQueueItem(texture);

            spqi.AddQuad(textureRegion, dest, color, angle, null, flipEffect);
        }
        /// <summary>
        /// Draw Text
        /// </summary>
        /// <param name="text">The text to render</param>
        /// <param name="font">The font used to render the text</param>
        /// <param name="textRenderMode">The way the text should be rendered</param>
        /// <param name="dest">The destination rectangle</param>
        /// <param name="color">The color to apply to the text</param>
        /// <param name="textAlign">The alignment of the text in the destination rectangle</param>
        /// <param name="angle">The rotation angle</param>
        public void DrawText(string text, Font font, TextRenderMode textRenderMode, Box dest, Color4 color, TextAlign textAlign = 0, float angle = 0f)
        {
            SpriteBatchQueueItem spqi = GetLastQueueItem(font.Texture);
            Box destA = dest;

            string s = ((textRenderMode == TextRenderMode.Box) ? font.GenerateWordWrap(text, (int)dest.Width) : text);
            string[] lines = s.Split('\n');
            if (textAlign >= TextAlign.Middle)
            {
                int height = lines.Length * font.FontDesc.Common.LineHeight;
                if ((textAlign & TextAlign.Middle) != 0)
                {
                    destA.Y = dest.Top + ((dest.Height - height) / 2);
                    destA.Height = height;
                }
                else if ((textAlign & TextAlign.Bottom) != 0)
                {
                    destA.Y = dest.Top + dest.Height - height;
                    destA.Height = height;
                }
            }

            foreach (string line in lines)
            {
                int width = font.GetTextLength(line);
                if ((textAlign & TextAlign.Center) != 0)
                {
                    destA.X = dest.X + ((dest.Width - width) / 2);
                    destA.Width = width;
                }
                else if ((textAlign & TextAlign.Right) != 0)
                {
                    destA.X = dest.X + dest.Width - width;
                    destA.Width = width;
                }
                else
                {
                    destA.X = dest.X;
                    destA.Width = dest.Width;
                }
                FontChar[] chars = font.GetChars(line);
                if (chars != null)
                {
                    Point pStart = destA.Position;
                    int outline = font.FontDesc.Info.OutLine;
                    Vector2 rotCenter = new Vector2(destA.Center);
                    foreach (FontChar fc in chars)
                    {
                        if (fc == null)
                        {
                            pStart.X = destA.X;
                            pStart.Y += font.FontDesc.Common.LineHeight;
                            continue;
                        }
                        Box rSrc = new Box(fc.X, fc.Y, fc.Width, fc.Height);
                        Box rDest = new Box(pStart.X + fc.XOffset, pStart.Y + fc.YOffset, fc.Width, fc.Height);

                        spqi.AddQuad(rSrc, rDest, color, angle, rotCenter, FlipEffect.None);

                        pStart.X += fc.XAdvance + outline;
                    }
                }
                destA.Y += font.FontDesc.Common.LineHeight;
                destA.Height -= font.FontDesc.Common.LineHeight;
            }
        }
        /// <summary>
        /// Fill a polygon with a given color
        /// </summary>
        /// <param name="points">The points that define the polygon</param>
        /// <param name="color">The color of the polygon</param>
        public void FillConvexPolygon(Point[] points, Color4 color)
        {
            SpriteBatchQueueItem spqi = GetLastQueueItem(m_ShapeTexture);

            Vertex[] vertices = new Vertex[points.Length];
            for (int i = 0; i < vertices.Length; ++i)
            {
                vertices[i] = new Vertex(new Vector2(points[i]), color, Vector2.Zero);
            }

            List<Vertex> poly = new List<Vertex>((vertices.Length - 2) * 3);
            for (int i = 2; i < vertices.Length; ++i)
            {
                poly.Add(vertices[0]);
                poly.Add(vertices[i - 1]);
                poly.Add(vertices[i]);
            }

            spqi.AddVertices(poly.ToArray());
        }
        /// <summary>
        /// Draw the outline of a convex polygon
        /// </summary>
        /// <param name="points">The points that define the polygon</param>
        /// <param name="thickness">The tickness of the outline</param>
        /// <param name="color">The color of the outline</param>
        public void DrawConvexPolygon(Point[] points, int thickness, Color4 color)
        {
            for (int i = 0; i < points.Length; ++i)
            {
                DrawLine(points[i], points[(i + 1) % points.Length], thickness, color);
            }
        }
        /// <summary>
        /// Draw the outline of an Arc
        /// </summary>
        /// <param name="center">The center of the Arc</param>
        /// <param name="radius">The Radius of the Arc</param>
        /// <param name="start">The start angle of the Arc</param>
        /// <param name="end">The end angle of the Arc</param>
        /// <param name="step">The size of each portion of the Arc</param>
        /// <param name="thickness">The tickness of the outline</param>
        /// <param name="color">The color of the outline</param>
        public void DrawArc(Point center, float radius, float start, float end, float step, int thickness, Color4 color)
        {
            for (float s = start; s < end; s += step)
            {
                float e = s + step;
                Point pStart = center + ((new Point(Helper.Cos(s), Helper.Sin(s))) * radius);
                Point pEnd = center + ((new Point(Helper.Cos(e), Helper.Sin(e))) * radius);

                DrawLine(pStart, pEnd, thickness, color);
            }
        }
    }
}
