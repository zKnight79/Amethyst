using System;
using System.Drawing;
using System.Xml.Serialization;

namespace Amethyst.Math
{
    /// <summary>
    /// Structure representing a 2D (integer coords) box
    /// </summary>
    public struct Box
    {
        /// <summary>
        /// The top-left corner of the box
        /// </summary>
        public Point Position;
        /// <summary>
        /// The size of the box
        /// </summary>
        public Size Size;

        /// <summary>
        /// Get or set the left position of the box
        /// </summary>
        [XmlIgnore]
        public float X
        {
            get { return Position.X; }
            set { Position.X = value; }
        }
        /// <summary>
        /// Get or set the top position of the box
        /// </summary>
        [XmlIgnore]
        public float Y
        {
            get { return Position.Y; }
            set { Position.Y = value; }
        }
        /// <summary>
        /// Get or set the width of the box
        /// </summary>
        [XmlIgnore]
        public float Width
        {
            get { return Size.Width; }
            set { Size.Width = value; }
        }
        /// <summary>
        /// Get or set the height of the box
        /// </summary>
        [XmlIgnore]
        public float Height
        {
            get { return Size.Height; }
            set { Size.Height = value; }
        }
        /// <summary>
        /// Get or set a Point that is the center of the box
        /// </summary>
        [XmlIgnore]
        public Point Center
        {
            get
            {
                return Position + Size / 2.0f;
            }
            set
            {
                Position = value - Size / 2.0f;
            }
        }

        /// <summary>
        /// Get or set the Left of the Box
        /// </summary>
        [XmlIgnore]
        public float Left
        {
            get { return X; }
            set { X = value; }
        }
        /// <summary>
        /// Get or set the Right of the Box
        /// </summary>
        [XmlIgnore]
        public float Right
        {
            get { return X + Width; }
            set { X = value - Width; }
        }
        /// <summary>
        /// Get or set the Top of the Box
        /// </summary>
        [XmlIgnore]
        public float Top
        {
            get { return Y; }
            set { Y = value; }
        }
        /// <summary>
        /// Get or set the Bottom of the Box
        /// </summary>
        [XmlIgnore]
        public float Bottom
        {
            get { return Y + Height; }
            set { Y = value - Height; }
        }

        /// <summary>
        /// Get the Top-Left corner of the Box
        /// </summary>
        [XmlIgnore]
        public Point TopLeft => Position;
        /// <summary>
        /// Get the Top-Right corner of the Box
        /// </summary>
        [XmlIgnore]
        public Point TopRight => new Point(Right, Top);
        /// <summary>
        /// Get the Bottom-Left corner of the Box
        /// </summary>
        [XmlIgnore]
        public Point BottomLeft => new Point(Left, Bottom);
        /// <summary>
        /// Get the Bottom-Right corner of the Box
        /// </summary>
        [XmlIgnore]
        public Point BottomRight => new Point(Right, Bottom);

        /// <summary>
        /// Creates a new Rectangle by explicitely setting its top-left coords and size
        /// </summary>
        /// <param name="position">The top-left coords of the box</param>
        /// <param name="size">The size of the box</param>
        public Box(Point position, Size size)
        {
            Position = position;
            Size = size;
        }
        /// <summary>
        /// Creates a new Rectangle by explicitely setting its top-left coords and size
        /// </summary>
        /// <param name="x">Left of the box</param>
        /// <param name="y">Top of the box</param>
        /// <param name="width">Width of the box</param>
        /// <param name="height">Height of the box</param>
        public Box(float x, float y, float width, float height) : this(new Point(x, y), new Size(width, height)) { }
        /// <summary>
        /// Creates a new Box based on GDI Rectangle structure
        /// </summary>
        /// <param name="r">A GDI Rectangle</param>
        public Box(Rectangle r) : this(r.X, r.Y, r.Width, r.Height) { }

        /// <summary>
        /// Tests if the Box intersects with a given Box
        /// </summary>
        /// <param name="box">The Box we want to know if our Box intersects with</param>
        /// <returns>true if there is an intersection, false otherwise</returns>
        public bool IntersectsWith(Box box) => !((Left > box.Right) || (Right < box.Left) || (Top > box.Bottom) || (Bottom < box.Top));
        /// <summary>
        /// Tests if a coordinate is contained in the Box
        /// </summary>
        /// <param name="x">The abscissa of the coordinate to be tested</param>
        /// <param name="y">The ordinate of the coordinate to be tested</param>
        /// <returns>true if the coordinate is contained in the Box, false otherwise</returns>
        public bool Contains(float x, float y) => !((x < Left) || (x > Right) || (y < Top) || (y > Bottom));
        /// <summary>
        /// Tests if a Point is contained in the Box
        /// </summary>
        /// <param name="p">The Point to be tested</param>
        /// <returns>true if the Point is contained in the Box, false otherwise</returns>
        public bool Contains(Point p) => Contains(p.X, p.Y);

        /// <summary>
        /// Explicit conversion into a GDI Rectangle
        /// </summary>
        /// <param name="box">The Box to convert</param>
        /// <returns>A GDI Rectangle</returns>
        public static explicit operator Rectangle(Box box) => new Rectangle((int)box.X, (int)box.Y, (int)box.Width, (int)box.Height);

        /// <summary>
        /// Get a text representation of the Box
        /// </summary>
        /// <returns>A text representation of the Box</returns>
        public override string ToString() => string.Format("[Box](X : {0}, Y : {1}, Width : {2}, Height : {3})", X, Y, Width, Height);
    }
}
