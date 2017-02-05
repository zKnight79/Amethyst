using System;

using Amethyst.Math;

namespace Amethyst.Engine
{
    /// <summary>
    /// Camera used for 2D rendering
    /// </summary>
    public class Camera
    {
        Box m_ViewRectangle;

        /// <summary>
        /// Get or set the View Rectangle used to compute the projection Matrix
        /// </summary>
        public Box ViewRectangle
        {
            get { return m_ViewRectangle; }
            set
            {
                m_ViewRectangle = value;
                ComputeProjectionMatrix();
            }
        }
        /// <summary>
        /// Get or set the position (top-left) of the camera's View Rectangle
        /// </summary>
        public Point Position
        {
            get { return m_ViewRectangle.Position; }
            set
            {
                m_ViewRectangle.Position = value;
                ComputeProjectionMatrix();
            }
        }
        /// <summary>
        /// Get or set the center of the camera's View Rectangle
        /// </summary>
        public Point Center
        {
            get { return m_ViewRectangle.Center; }
            set
            {
                m_ViewRectangle.Center = value;
                ComputeProjectionMatrix();
            }
        }
        /// <summary>
        /// Get or set the size of the camera's View Rectangle
        /// </summary>
        public Size Size
        {
            get { return m_ViewRectangle.Size; }
            set
            {
                m_ViewRectangle.Size = value;
                ComputeProjectionMatrix();
            }
        }
        /// <summary>
        /// Get the Projection matrix
        /// </summary>
        public Matrix4 ProjectionMatrix { get; private set; }

        private void ComputeProjectionMatrix()
        {
            ProjectionMatrix = Matrix4.Ortho2DOffCenter(m_ViewRectangle.Center, m_ViewRectangle.Size);
        }

        /// <summary>
        /// Create a new instance of Camera, using the given View Rectangle
        /// </summary>
        /// <param name="viewRectangle">The View Rectangle the Calera is "looking at"</param>
        public Camera(Box viewRectangle)
        {
            ViewRectangle = viewRectangle;
        }
        /// <summary>
        /// Create a new instance of Camera, providing the center and the size View Rectangle
        /// </summary>
        /// <param name="center">The center of the View Rectangle</param>
        /// <param name="size">The size of the View Rectangle</param>
        public Camera(Point center, Size size) : this(new Box(center - size / 2, size)) { }
    }
}
