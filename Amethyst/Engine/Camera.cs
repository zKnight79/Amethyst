using System;

using Amethyst.Math;

namespace Amethyst.Engine
{
    public class Camera
    {
        Box m_ViewRectangle;

        public Box ViewRectangle
        {
            get { return m_ViewRectangle; }
            set
            {
                m_ViewRectangle = value;
                ComputeProjectionMatrix();
            }
        }
        public Point Position
        {
            get { return m_ViewRectangle.Position; }
            set
            {
                m_ViewRectangle.Position = value;
                ComputeProjectionMatrix();
            }
        }
        public Point Center
        {
            get { return m_ViewRectangle.Center; }
            set
            {
                m_ViewRectangle.Center = value;
                ComputeProjectionMatrix();
            }
        }
        public Size Size
        {
            get { return m_ViewRectangle.Size; }
            set
            {
                m_ViewRectangle.Size = value;
                ComputeProjectionMatrix();
            }
        }
        public Matrix4 ProjectionMatrix { get; private set; }

        private void ComputeProjectionMatrix()
        {
            ProjectionMatrix = Matrix4.Ortho2DOffCenter(m_ViewRectangle.Center, m_ViewRectangle.Size);
        }

        public Camera(Box viewRectangle)
        {
            ViewRectangle = viewRectangle;
        }
        public Camera(Point center, Size size) : this(new Box(center - size / 2, size)) { }
    }
}
