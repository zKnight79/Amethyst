using Amethyst.Graphics;
using Amethyst.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Amethyst.Engine
{
    class SpriteBatchQueueItem
    {
        public Texture Texture;
        public List<Vertex> Vertices = new List<Vertex>();

        public SpriteBatchQueueItem(Texture texture)
        {
            Texture = texture;
        }

        public void AddQuad(Box? src, Box dest, Color4 color, float angle, Vector2? rotationCenter, FlipEffect flipEffect)
        {
            #region VERTEX POSITION
            Vector2[] xy = new Vector2[4];
            xy[0] = new Vector2(dest.Position);
            xy[1] = new Vector2(dest.Left, dest.Bottom);
            xy[2] = new Vector2(dest.Right, dest.Top);
            xy[3] = new Vector2(dest.Right, dest.Bottom);
            #endregion
            AddQuad(src, xy, color, angle, (rotationCenter == null) ? new Vector2(dest.Center) : rotationCenter, flipEffect);
        }
        public void AddQuad(Box? src, Vector2[] xy, Color4 color, float angle, Vector2? rotationCenter, FlipEffect flipEffect)
        {
            #region VERTICES COMPUTATION
            #region APPLY ROTATION
            if ((angle != 0) && (rotationCenter != null))
            {
                Vector2 offset = rotationCenter.Value;
                Matrix4 mat = Matrix4.RotationZ(angle);
                for (int i = 0; i < 4; ++i)
                {
                    xy[i] -= offset;
                    xy[i] = mat.Transform(xy[i]);
                    xy[i] += offset;
                }
            }
            #endregion

            #region VERTEX TEXTURE COORD
            Box rSrc = (src == null) ? new Box(0, 0, Texture.Width, Texture.Height) : src.Value;
            Vector2 uvTopLeft = new Vector2(Texture.UFromPixelX(rSrc.Left), Texture.UFromPixelX(rSrc.Top));
            Vector2 uvBottomLeft = new Vector2(Texture.UFromPixelX(rSrc.Left), Texture.UFromPixelX(rSrc.Bottom));
            Vector2 uvTopRight = new Vector2(Texture.UFromPixelX(rSrc.Right), Texture.UFromPixelX(rSrc.Top));
            Vector2 uvBottomRight = new Vector2(Texture.UFromPixelX(rSrc.Right), Texture.UFromPixelX(rSrc.Bottom));
            #region APPLY FLIP EFFECT
            if ((flipEffect & FlipEffect.Horizontally) == FlipEffect.Horizontally)
            {
                Helper.Swap<Vector2>(ref uvTopLeft, ref uvBottomLeft);
                Helper.Swap<Vector2>(ref uvTopRight, ref uvBottomRight);
            }
            if ((flipEffect & FlipEffect.Vertically) == FlipEffect.Vertically)
            {
                Helper.Swap<Vector2>(ref uvTopLeft, ref uvTopRight);
                Helper.Swap<Vector2>(ref uvBottomLeft, ref uvBottomRight);
            }
            #endregion
            #endregion

            #region VERTEX DEFINITION
            Vertex vTopLeft = new Vertex(xy[0], color, uvTopLeft);
            Vertex vBottomLeft = new Vertex(xy[1], color, uvBottomLeft);
            Vertex vTopRight = new Vertex(xy[2], color, uvTopRight);
            Vertex vBottomRight = new Vertex(xy[3], color, uvBottomRight);
            #endregion
            #endregion

            Vertices.Add(vTopLeft);
            Vertices.Add(vBottomLeft);
            Vertices.Add(vTopRight);
            Vertices.Add(vTopRight);
            Vertices.Add(vBottomLeft);
            Vertices.Add(vBottomRight);
        }
        public void AddVertices(Vertex[] vertices)
        {
            Vertices.AddRange(vertices);
        }
    }
}
