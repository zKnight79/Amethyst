using System;
using System.Runtime.InteropServices;

namespace Amethyst.Math
{
    /// <summary>
    /// Structure representing a 2D Vector
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2
    {
        #region MEMBERS
        /// <summary>
        /// X component of the vector
        /// </summary>
        public float X;
        /// <summary>
        /// Y component of the vector
        /// </summary>
        public float Y;
        #endregion

        #region CONSTRUCTORS
        /// <summary>
        /// Creates a new Vector2 by specifiying X and Y components
        /// </summary>
        /// <param name="x">The X component of the vector</param>
        /// <param name="y">The Y component of the vector</param>
        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }
        /// <summary>
        /// Creates a new Vector2 from a Vector4, by keeping only X and Y components
        /// </summary>
        /// <param name="v">The reference Vector4</param>
        public Vector2(Vector4 v) : this(v.X, v.Y) { }
        /// <summary>
        /// Creates a new Vector2 from a Point
        /// </summary>
        /// <param name="point">The reference Point</param>
        public Vector2(Point point) : this(point.X, point.Y) { }
        #endregion

        #region OPERATORS
        /// <summary>
        /// Negate a Vector2
        /// </summary>
        /// <param name="v">The Vector2 to negate</param>
        /// <returns>A Vector2 which is -v</returns>
        public static Vector2 operator -(Vector2 v)
        {
            return new Vector2(-v.X, -v.Y);
        }
        /// <summary>
        /// Add 2 Vector2
        /// </summary>
        /// <param name="v1">A Vector2</param>
        /// <param name="v2">Another Vector2</param>
        /// <returns>A Vector2 which is v1+v2</returns>
        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
        }
        /// <summary>
        /// Subtract 2 Vector2
        /// </summary>
        /// <param name="v1">A Vector2</param>
        /// <param name="v2">Another Vector2</param>
        /// <returns>A Vector2 which is v1-v2</returns>
        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
        }
        /// <summary>
        /// Multiply a Vector2 by a scalar
        /// </summary>
        /// <param name="v">A Vector2</param>
        /// <param name="f">A scalar</param>
        /// <returns>A Vector2 which is v*f</returns>
        public static Vector2 operator *(Vector2 v, float f)
        {
            return new Vector2(v.X * f, v.Y * f);
        }
        /// <summary>
        /// Divide a Vector2 by a scalar
        /// </summary>
        /// <param name="v">A Vector2</param>
        /// <param name="f">A scalar</param>
        /// <returns>A Vector2 which is v/f</returns>
        public static Vector2 operator /(Vector2 v, float f)
        {
            return new Vector2(v.X / f, v.Y / f);
        }
        /// <summary>
        /// Multiply a Vector2 by another Vector2
        /// </summary>
        /// <param name="v">A Vector2</param>
        /// <param name="scale">Another Vector2</param>
        /// <returns>A Vector2 which is v*scale</returns>
        public static Vector2 operator *(Vector2 v, Vector2 scale)
        {
            return new Vector2(v.X * scale.X, v.Y * scale.Y);
        }
        /// <summary>
        /// Tests if 2 Vector2 have the same coordinates
        /// </summary>
        /// <param name="v1">A Vector2</param>
        /// <param name="v2">Another Vector2</param>
        /// <returns>true if v1 is equal to v2, false if v1 is different of v2</returns>
        public static bool operator ==(Vector2 v1, Vector2 v2)
        {
            return (v1.X == v2.X) && (v1.Y == v2.Y);
        }
        /// <summary>
        /// Tests if 2 Vector2 are differents
        /// </summary>
        /// <param name="v1">A Vector2</param>
        /// <param name="v2">Another Vector2</param>
        /// <returns>true if v1 is different of v2, false if v1 is equal to v2</returns>
        public static bool operator !=(Vector2 v1, Vector2 v2)
        {
            return (v1.X != v2.X) || (v1.Y != v2.Y);
        } 
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Get the size of the Vector2 structure
        /// </summary>
        public static int Size
        {
            get { return 2 * sizeof(float); }
        }
        /// <summary>
        /// Get the magnitude of the Vector2
        /// </summary>
        public float Magnitude
        {
            get
            {
                return (float)System.Math.Sqrt(X * X + Y * Y);
            }
        }
        /// <summary>
        /// Get the squared magnitude (Magnitude²) of the Vector2
        /// </summary>
        public float MagnitudeSquared
        {
            get
            {
                return (X * X + Y * Y);
            }
        }
        /// <summary>
        /// Get the normalized version of the Vector2
        /// </summary>
        public Vector2 Normalized
        {
            get
            {
                return this / Magnitude;
            }
        }
        #endregion

        #region OBJECT OVERRIDES
        /// <summary>
        /// Convert the Vector2 to an explicit string
        /// </summary>
        /// <returns>A string representing the Vector2</returns>
        public override string ToString()
        {
            return string.Format("({0}, {1})", X, Y);
        }
        /// <summary>
        /// Return a hash code for this Vector2
        /// </summary>
        /// <returns>An int that is the hash code of this Vector2</returns>
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
        /// <summary>
        /// Get if this Vector2 has the same coordinates than the specified object
        /// </summary>
        /// <param name="obj">The object to compare with this Vector2</param>
        /// <returns>true if obj is a Vector2 and has the same coordinates than this Vector2, false otherwise</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Vector2))
            {
                return false;
            }
            return this == ((Vector2)obj);
        }
        #endregion

        #region STATIC METHODS
        /// <summary>
        /// Computes the dot product of 2 Vector2
        /// </summary>
        /// <param name="v1">A Vector2</param>
        /// <param name="v2">Another Vector2</param>
        /// <returns>The dot product of the 2 Vector2</returns>
        public static float Dot(ref Vector2 v1, ref Vector2 v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y;
        }
        #endregion

        #region PRE-DEFINED VECTORS
        /// <summary>
        /// Retrieves a unit Vector2 that points toward X axis
        /// </summary>
        public static readonly Vector2 UnitX = new Vector2(1, 0);
        /// <summary>
        /// Retrieves a unit Vector2 that points toward Y axis
        /// </summary>
        public static readonly Vector2 UnitY = new Vector2(0, 1);
        /// <summary>
        /// Retrieves a zero Vector2
        /// </summary>
        public static readonly Vector2 Zero = new Vector2(0, 0);
        /// <summary>
        /// Retrieves a 'one' Vector2
        /// </summary>
        public static readonly Vector2 One = new Vector2(1, 1);
        #endregion
    }
}
