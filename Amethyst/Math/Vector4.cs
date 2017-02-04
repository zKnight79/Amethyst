using System;
using System.Runtime.InteropServices;

using Amethyst.Graphics;

namespace Amethyst.Math
{
    /// <summary>
    /// Structure representing a Vector in homogeneous coordinates
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector4
    {
        #region MEMBERS
        /// <summary>
        /// The X Component of the Vector4
        /// </summary>
        public float X;
        /// <summary>
        /// The Y Component of the Vector4
        /// </summary>
        public float Y;
        /// <summary>
        /// The Z Component of the Vector4
        /// </summary>
        public float Z;
        /// <summary>
        /// The W Component of the Vector4
        /// </summary>
        public float W;
        #endregion

        #region CONSTRUCTORS
        /// <summary>
        /// Creates a new Vector4 by specifiying X, Y, Z and W components
        /// </summary>
        /// <param name="x">The X Component of the Vector4</param>
        /// <param name="y">The Y Component of the Vector4</param>
        /// <param name="z">The Z Component of the Vector4</param>
        /// <param name="w">The W Component of the Vector4</param>
        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }
        /// <summary>
        /// Creates a new Vector4 by specifiying X, Y and Z components, W will be set to 1
        /// </summary>
        /// <param name="x">The X Component of the Vector4</param>
        /// <param name="y">The Y Component of the Vector4</param>
        /// <param name="z">The Z Component of the Vector4</param>
        public Vector4(float x, float y, float z) : this(x, y, z, 1.0f) { }
        /// <summary>
        /// Creates a new Vector4 by specifiying X and Y components, Z will be set to zero, W will be set to 1
        /// </summary>
        /// <param name="x">The X Component of the Vector4</param>
        /// <param name="y">The Y Component of the Vector4</param>
        public Vector4(float x, float y) : this(x, y, 0.0f) { }
        /// <summary>
        /// Creates a new Vector4 by copying a Vector2 and adding the Z and W components
        /// </summary>
        /// <param name="v">A Vector2 that will set X and Y components of the Vector4</param>
        /// <param name="z">The Z Component of the Vector4</param>
        /// <param name="w">The W Component of the Vector4</param>
        public Vector4(Vector2 v, float z, float w) : this(v.X, v.Y, z, w) { }
        /// <summary>
        /// Creates a new Vector4 by copying a Vector2 and adding the Z component, W component will be set to 1
        /// </summary>
        /// <param name="v">A Vector2 that will set X and Y components of the Vector4</param>
        /// <param name="z">The Z Component of the Vector4</param>
        public Vector4(Vector2 v, float z) : this(v, z, 1.0f) { }
        /// <summary>
        /// Creates a new Vector4 by copying a Vector2, Z component will be set to zero, W component will be set to 1
        /// </summary>
        /// <param name="v">A Vector2 that will set X and Y components of the Vector4</param>
        public Vector4(Vector2 v) : this(v, 0.0f) { }
        /// <summary>
        /// Creates a new Vector4 from a Color4<br />
        /// X will be set with Red<br />
        /// Y will be set with Green<br />
        /// Z will be set with Blue<br />
        /// W will be set with Alpha<br />
        /// </summary>
        /// <param name="c">The Color4 that will set the X, Y, Z and W components</param>
        public Vector4(Color4 c) : this(c.Red, c.Green, c.Blue, c.Alpha) { }
        #endregion

        #region OPERATORS
        /// <summary>
        /// Negate a Vector4
        /// </summary>
        /// <param name="v">The Vector4 to negate</param>
        /// <returns>A Vector4 which is -v</returns>
        public static Vector4 operator -(Vector4 v)
        {
            return new Vector4(-v.X, -v.Y, -v.Z, -v.W);
        }
        /// <summary>
        /// Add 2 Vector4
        /// </summary>
        /// <param name="v1">A Vector4</param>
        /// <param name="v2">Another Vector4</param>
        /// <returns>A Vector4 which is v1+v2</returns>
        public static Vector4 operator +(Vector4 v1, Vector4 v2)
        {
            return new Vector4(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z, v1.W + v2.W);
        }
        /// <summary>
        /// Subtract 2 Vector4
        /// </summary>
        /// <param name="v1">A Vector4</param>
        /// <param name="v2">Another Vector4</param>
        /// <returns>A Vector4 which is v1-v2</returns>
        public static Vector4 operator -(Vector4 v1, Vector4 v2)
        {
            return new Vector4(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z, v1.W - v2.W);
        }
        /// <summary>
        /// Multiply a Vector4 by a scalar
        /// </summary>
        /// <param name="v">A Vector4</param>
        /// <param name="f">A scalar</param>
        /// <returns>A Vector4 which is v*f</returns>
        public static Vector4 operator *(Vector4 v, float f)
        {
            return new Vector4(v.X * f, v.Y * f, v.Z * f, v.W / f);
        }
        /// <summary>
        /// Divide a Vector4 by a scalar
        /// </summary>
        /// <param name="v">A Vector4</param>
        /// <param name="f">A scalar</param>
        /// <returns>A Vector4 which is v/f</returns>
        public static Vector4 operator /(Vector4 v, float f)
        {
            return new Vector4(v.X / f, v.Y / f, v.Z / f, v.W / f);
        }
        /// <summary>
        /// Multiply a Vector4 by another Vector4
        /// </summary>
        /// <param name="v">A Vector4</param>
        /// <param name="scale">Another Vector4</param>
        /// <returns>A Vector4 which is v*scale</returns>
        public static Vector4 operator *(Vector4 v, Vector4 scale)
        {
            return new Vector4(v.X * scale.X, v.Y * scale.Y, v.Z * scale.Z, v.W * scale.W);
        }
        /// <summary>
        /// Tests if 2 Vector4 have the same coordinates
        /// </summary>
        /// <param name="v1">A Vector4</param>
        /// <param name="v2">Another Vector4</param>
        /// <returns>true if v1 is equal to v2, false if v1 is different of v2</returns>
        public static bool operator ==(Vector4 v1, Vector4 v2)
        {
            return (v1.X == v2.X) && (v1.Y == v2.Y) && (v1.Z == v2.Z) && (v1.W == v2.W);
        }
        /// <summary>
        /// Tests if 2 Vector4 are differents
        /// </summary>
        /// <param name="v1">A Vector4</param>
        /// <param name="v2">Another Vector4</param>
        /// <returns>true if v1 is different of v2, false if v1 is equal to v2</returns>
        public static bool operator !=(Vector4 v1, Vector4 v2)
        {
            return (v1.X != v2.X) || (v1.Y != v2.Y) || (v1.Z != v2.Z) || (v1.W != v2.W);
        } 
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Get the size of the Vector4 structure
        /// </summary>
        public static int Size
        {
            get { return 4 * sizeof(float); }
        }
        /// <summary>
        /// Get the magnitude of the Vector4
        /// </summary>
        public float Magnitude
        {
            get
            {
                return (float)System.Math.Sqrt(X * X + Y * Y + Z * Z + W * W);
            }
        }
        /// <summary>
        /// Get the squared magnitude (Magnitude²) of the Vector4
        /// </summary>
        public float MagnitudeSquared
        {
            get
            {
                return (X * X + Y * Y + Z * Z + W * W);
            }
        }
        /// <summary>
        /// Get the normalized version of the Vector4
        /// </summary>
        public Vector4 Normalized
        {
            get
            {
                return this / Magnitude;
            }
        }
        #endregion

        #region OBJECT OVERRIDES
        /// <summary>
        /// Convert the Vector4 to an explicit string
        /// </summary>
        /// <returns>A string representing the Vector4</returns>
        public override string ToString()
        {
            return string.Format("({0}, {1}, {2}, {3})", X, Y, Z, W);
        }
        /// <summary>
        /// Return a hash code for this Vector4
        /// </summary>
        /// <returns>An int that is the hash code of this Vector4</returns>
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode() ^ W.GetHashCode();
        }
        /// <summary>
        /// Get if this Vector4 has the same coordinates than the specified object
        /// </summary>
        /// <param name="obj">The object to compare with this Vector4</param>
        /// <returns>true if obj is a Vector4 and has the same coordinates than this Vector4, false otherwise</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Vector4))
            {
                return false;
            }
            return this == ((Vector4)obj);
        }
        #endregion

        #region STATIC METHODS
        /// <summary>
        /// Computes the dot product of 2 Vector4
        /// </summary>
        /// <param name="v1">A Vector4</param>
        /// <param name="v2">Another Vector4</param>
        /// <returns>The dot product of the 2 Vector4</returns>
        public static float Dot(ref Vector4 v1, ref Vector4 v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z + v1.W * v2.W;
        }
        /// <summary>
        /// Computes the cross product of 2 Vector3
        /// </summary>
        /// <param name="v1">A Vector3</param>
        /// <param name="v2">Another Vector3</param>
        /// <returns>The cross product of the 2 Vector3</returns>
        public static Vector4 Cross(ref Vector4 v1, ref Vector4 v2)
        {
            return new Vector4((v1.Y * v2.Z) - (v1.Z * v2.Y), (v1.Z * v2.X) - (v1.X * v2.Z), (v1.X * v2.Y) - (v1.Y * v2.X), 1);
        }
        #endregion

        #region PRE-DEFINED VECTORS
        /// <summary>
        /// Retrieves a unit Vector4 that points toward X axis
        /// </summary>
        public static readonly Vector4 UnitX = new Vector4(1, 0, 0, 0);
        /// <summary>
        /// Retrieves a unit Vector4 that points toward Y axis
        /// </summary>
        public static readonly Vector4 UnitY = new Vector4(0, 1, 0, 0);
        /// <summary>
        /// Retrieves a unit Vector4 that points toward Z axis
        /// </summary>
        public static readonly Vector4 UnitZ = new Vector4(0, 0, 1, 0);
        /// <summary>
        /// Retrieves a zero Vector4
        /// </summary>
        public static readonly Vector4 Zero = new Vector4(0, 0, 0, 0);
        /// <summary>
        /// Retrieves a 'one' Vector4
        /// </summary>
        public static readonly Vector4 One = new Vector4(1, 1, 1, 1);
        #endregion
    }
}
