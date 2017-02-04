using System;
using System.Runtime.InteropServices;

namespace Amethyst.Math
{
    /// <summary>
    /// Structure representing a 4x4 matrix
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix4
    {
        float m_R1C1;
        float m_R1C2;
        float m_R1C3;
        float m_R1C4;
        float m_R2C1;
        float m_R2C2;
        float m_R2C3;
        float m_R2C4;
        float m_R3C1;
        float m_R3C2;
        float m_R3C3;
        float m_R3C4;
        float m_R4C1;
        float m_R4C2;
        float m_R4C3;
        float m_R4C4;

        /// <summary>
        /// Construct a new 4x4 matrix with diagonal filled by a value
        /// </summary>
        /// <param name="value">The value that will fill the diagonal</param>
        public Matrix4(float value)
        {
            m_R1C1 = m_R2C2 = m_R3C3 = m_R4C4 = value;
            m_R1C2 = m_R1C3 = m_R1C4 = m_R2C1 = m_R2C3 = m_R2C4 = m_R3C1 = m_R3C2 = m_R3C4 = m_R4C1 = m_R4C2 = m_R4C3 = 0;
        }
        /// <summary>
        /// Construct a new 4x4 matrix which is a copy another 4x4 matrix
        /// </summary>
        /// <param name="matrix"></param>
        public Matrix4(ref Matrix4 matrix)
        {
            m_R1C1 = matrix.m_R1C1;
            m_R1C2 = matrix.m_R1C2;
            m_R1C3 = matrix.m_R1C3;
            m_R1C4 = matrix.m_R1C4;
            m_R2C1 = matrix.m_R2C1;
            m_R2C2 = matrix.m_R2C2;
            m_R2C3 = matrix.m_R2C3;
            m_R2C4 = matrix.m_R2C4;
            m_R3C1 = matrix.m_R3C1;
            m_R3C2 = matrix.m_R3C2;
            m_R3C3 = matrix.m_R3C3;
            m_R3C4 = matrix.m_R3C4;
            m_R4C1 = matrix.m_R4C1;
            m_R4C2 = matrix.m_R4C2;
            m_R4C3 = matrix.m_R4C3;
            m_R4C4 = matrix.m_R4C4;
        }
        /// <summary>
        /// Construct a new 4x4 matrix filled by an array.<br />
        /// The array length must be at least 16.<br />
        /// The values must be row major order.
        /// </summary>
        /// <param name="values">An array of floats</param>
        public Matrix4(float[] values)
        {
            m_R1C1 = values[0];
            m_R1C2 = values[1];
            m_R1C3 = values[2];
            m_R1C4 = values[3];
            m_R2C1 = values[4];
            m_R2C2 = values[5];
            m_R2C3 = values[6];
            m_R2C4 = values[7];
            m_R3C1 = values[8];
            m_R3C2 = values[9];
            m_R3C3 = values[10];
            m_R3C4 = values[11];
            m_R4C1 = values[12];
            m_R4C2 = values[13];
            m_R4C3 = values[14];
            m_R4C4 = values[15];
        }
        /// <summary>
        /// Construct a new 4x4 matrix filled by the parameters values
        /// </summary>
        /// <param name="r1c1">Value for Row 1, Column 1</param>
        /// <param name="r1c2">Value for Row 1, Column 2</param>
        /// <param name="r1c3">Value for Row 1, Column 3</param>
        /// <param name="r1c4">Value for Row 1, Column 4</param>
        /// <param name="r2c1">Value for Row 2, Column 1</param>
        /// <param name="r2c2">Value for Row 2, Column 2</param>
        /// <param name="r2c3">Value for Row 2, Column 3</param>
        /// <param name="r2c4">Value for Row 2, Column 4</param>
        /// <param name="r3c1">Value for Row 3, Column 1</param>
        /// <param name="r3c2">Value for Row 3, Column 2</param>
        /// <param name="r3c3">Value for Row 3, Column 3</param>
        /// <param name="r3c4">Value for Row 3, Column 4</param>
        /// <param name="r4c1">Value for Row 4, Column 1</param>
        /// <param name="r4c2">Value for Row 4, Column 2</param>
        /// <param name="r4c3">Value for Row 4, Column 3</param>
        /// <param name="r4c4">Value for Row 4, Column 4</param>
        public Matrix4(float r1c1, float r1c2, float r1c3, float r1c4, float r2c1, float r2c2, float r2c3, float r2c4, float r3c1, float r3c2, float r3c3, float r3c4, float r4c1, float r4c2, float r4c3, float r4c4)
        {
            m_R1C1 = r1c1;
            m_R1C2 = r1c2;
            m_R1C3 = r1c3;
            m_R1C4 = r1c4;
            m_R2C1 = r2c1;
            m_R2C2 = r2c2;
            m_R2C3 = r2c3;
            m_R2C4 = r2c4;
            m_R3C1 = r3c1;
            m_R3C2 = r3c2;
            m_R3C3 = r3c3;
            m_R3C4 = r3c4;
            m_R4C1 = r4c1;
            m_R4C2 = r4c2;
            m_R4C3 = r4c3;
            m_R4C4 = r4c4;
        }

        /// <summary>
        /// Multiply 2 4x4 matrices
        /// </summary>
        /// <param name="mRight">The left operand</param>
        /// <param name="mLeft">The right operand</param>
        /// <returns>The 4x4 matrix result of the multiplication</returns>
        [Obsolete]
        public static Matrix4 operator *(Matrix4 mLeft, Matrix4 mRight)
        {
            return new Matrix4(mLeft.m_R1C1 * mRight.m_R1C1 + mLeft.m_R1C2 * mRight.m_R2C1 + mLeft.m_R1C3 * mRight.m_R3C1 + mLeft.m_R1C4 * mRight.m_R4C1
                             , mLeft.m_R1C1 * mRight.m_R1C2 + mLeft.m_R1C2 * mRight.m_R2C2 + mLeft.m_R1C3 * mRight.m_R3C2 + mLeft.m_R1C4 * mRight.m_R4C2
                             , mLeft.m_R1C1 * mRight.m_R1C3 + mLeft.m_R1C2 * mRight.m_R2C3 + mLeft.m_R1C3 * mRight.m_R3C3 + mLeft.m_R1C4 * mRight.m_R4C3
                             , mLeft.m_R1C1 * mRight.m_R1C4 + mLeft.m_R1C2 * mRight.m_R2C4 + mLeft.m_R1C3 * mRight.m_R3C4 + mLeft.m_R1C4 * mRight.m_R4C4
                             , mLeft.m_R2C1 * mRight.m_R1C1 + mLeft.m_R2C2 * mRight.m_R2C1 + mLeft.m_R2C3 * mRight.m_R3C1 + mLeft.m_R2C4 * mRight.m_R4C1
                             , mLeft.m_R2C1 * mRight.m_R1C2 + mLeft.m_R2C2 * mRight.m_R2C2 + mLeft.m_R2C3 * mRight.m_R3C2 + mLeft.m_R2C4 * mRight.m_R4C2
                             , mLeft.m_R2C1 * mRight.m_R1C3 + mLeft.m_R2C2 * mRight.m_R2C3 + mLeft.m_R2C3 * mRight.m_R3C3 + mLeft.m_R2C4 * mRight.m_R4C3
                             , mLeft.m_R2C1 * mRight.m_R1C4 + mLeft.m_R2C2 * mRight.m_R2C4 + mLeft.m_R2C3 * mRight.m_R3C4 + mLeft.m_R2C4 * mRight.m_R4C4
                             , mLeft.m_R3C1 * mRight.m_R1C1 + mLeft.m_R3C2 * mRight.m_R2C1 + mLeft.m_R3C3 * mRight.m_R3C1 + mLeft.m_R3C4 * mRight.m_R4C1
                             , mLeft.m_R3C1 * mRight.m_R1C2 + mLeft.m_R3C2 * mRight.m_R2C2 + mLeft.m_R3C3 * mRight.m_R3C2 + mLeft.m_R3C4 * mRight.m_R4C2
                             , mLeft.m_R3C1 * mRight.m_R1C3 + mLeft.m_R3C2 * mRight.m_R2C3 + mLeft.m_R3C3 * mRight.m_R3C3 + mLeft.m_R3C4 * mRight.m_R4C3
                             , mLeft.m_R3C1 * mRight.m_R1C4 + mLeft.m_R3C2 * mRight.m_R2C4 + mLeft.m_R3C3 * mRight.m_R3C4 + mLeft.m_R3C4 * mRight.m_R4C4
                             , mLeft.m_R4C1 * mRight.m_R1C1 + mLeft.m_R4C2 * mRight.m_R2C1 + mLeft.m_R4C3 * mRight.m_R3C1 + mLeft.m_R4C4 * mRight.m_R4C1
                             , mLeft.m_R4C1 * mRight.m_R1C2 + mLeft.m_R4C2 * mRight.m_R2C2 + mLeft.m_R4C3 * mRight.m_R3C2 + mLeft.m_R4C4 * mRight.m_R4C2
                             , mLeft.m_R4C1 * mRight.m_R1C3 + mLeft.m_R4C2 * mRight.m_R2C3 + mLeft.m_R4C3 * mRight.m_R3C3 + mLeft.m_R4C4 * mRight.m_R4C3
                             , mLeft.m_R4C1 * mRight.m_R1C4 + mLeft.m_R4C2 * mRight.m_R2C4 + mLeft.m_R4C3 * mRight.m_R3C4 + mLeft.m_R4C4 * mRight.m_R4C4);
        }

        /// <summary>
        /// Multiply 2 Matrices
        /// </summary>
        /// <param name="mLeft">Left operand</param>
        /// <param name="mRight">Right operand</param>
        /// <param name="mResult">The computed matrix</param>
        public static void Multiply(ref Matrix4 mLeft, ref Matrix4 mRight, out Matrix4 mResult)
        {
            mResult.m_R1C1 = mLeft.m_R1C1 * mRight.m_R1C1 + mLeft.m_R1C2 * mRight.m_R2C1 + mLeft.m_R1C3 * mRight.m_R3C1 + mLeft.m_R1C4 * mRight.m_R4C1;
            mResult.m_R1C2 = mLeft.m_R1C1 * mRight.m_R1C2 + mLeft.m_R1C2 * mRight.m_R2C2 + mLeft.m_R1C3 * mRight.m_R3C2 + mLeft.m_R1C4 * mRight.m_R4C2;
            mResult.m_R1C3 = mLeft.m_R1C1 * mRight.m_R1C3 + mLeft.m_R1C2 * mRight.m_R2C3 + mLeft.m_R1C3 * mRight.m_R3C3 + mLeft.m_R1C4 * mRight.m_R4C3;
            mResult.m_R1C4 = mLeft.m_R1C1 * mRight.m_R1C4 + mLeft.m_R1C2 * mRight.m_R2C4 + mLeft.m_R1C3 * mRight.m_R3C4 + mLeft.m_R1C4 * mRight.m_R4C4;
            mResult.m_R2C1 = mLeft.m_R2C1 * mRight.m_R1C1 + mLeft.m_R2C2 * mRight.m_R2C1 + mLeft.m_R2C3 * mRight.m_R3C1 + mLeft.m_R2C4 * mRight.m_R4C1;
            mResult.m_R2C2 = mLeft.m_R2C1 * mRight.m_R1C2 + mLeft.m_R2C2 * mRight.m_R2C2 + mLeft.m_R2C3 * mRight.m_R3C2 + mLeft.m_R2C4 * mRight.m_R4C2;
            mResult.m_R2C3 = mLeft.m_R2C1 * mRight.m_R1C3 + mLeft.m_R2C2 * mRight.m_R2C3 + mLeft.m_R2C3 * mRight.m_R3C3 + mLeft.m_R2C4 * mRight.m_R4C3;
            mResult.m_R2C4 = mLeft.m_R2C1 * mRight.m_R1C4 + mLeft.m_R2C2 * mRight.m_R2C4 + mLeft.m_R2C3 * mRight.m_R3C4 + mLeft.m_R2C4 * mRight.m_R4C4;
            mResult.m_R3C1 = mLeft.m_R3C1 * mRight.m_R1C1 + mLeft.m_R3C2 * mRight.m_R2C1 + mLeft.m_R3C3 * mRight.m_R3C1 + mLeft.m_R3C4 * mRight.m_R4C1;
            mResult.m_R3C2 = mLeft.m_R3C1 * mRight.m_R1C2 + mLeft.m_R3C2 * mRight.m_R2C2 + mLeft.m_R3C3 * mRight.m_R3C2 + mLeft.m_R3C4 * mRight.m_R4C2;
            mResult.m_R3C3 = mLeft.m_R3C1 * mRight.m_R1C3 + mLeft.m_R3C2 * mRight.m_R2C3 + mLeft.m_R3C3 * mRight.m_R3C3 + mLeft.m_R3C4 * mRight.m_R4C3;
            mResult.m_R3C4 = mLeft.m_R3C1 * mRight.m_R1C4 + mLeft.m_R3C2 * mRight.m_R2C4 + mLeft.m_R3C3 * mRight.m_R3C4 + mLeft.m_R3C4 * mRight.m_R4C4;
            mResult.m_R4C1 = mLeft.m_R4C1 * mRight.m_R1C1 + mLeft.m_R4C2 * mRight.m_R2C1 + mLeft.m_R4C3 * mRight.m_R3C1 + mLeft.m_R4C4 * mRight.m_R4C1;
            mResult.m_R4C2 = mLeft.m_R4C1 * mRight.m_R1C2 + mLeft.m_R4C2 * mRight.m_R2C2 + mLeft.m_R4C3 * mRight.m_R3C2 + mLeft.m_R4C4 * mRight.m_R4C2;
            mResult.m_R4C3 = mLeft.m_R4C1 * mRight.m_R1C3 + mLeft.m_R4C2 * mRight.m_R2C3 + mLeft.m_R4C3 * mRight.m_R3C3 + mLeft.m_R4C4 * mRight.m_R4C3;
            mResult.m_R4C4 = mLeft.m_R4C1 * mRight.m_R1C4 + mLeft.m_R4C2 * mRight.m_R2C4 + mLeft.m_R4C3 * mRight.m_R3C4 + mLeft.m_R4C4 * mRight.m_R4C4;
        }

        /// <summary>
        /// Explicit conversion to a row major array of float.
        /// </summary>
        /// <param name="matrix">The matrix to convert</param>
        /// <returns>An array of 16 floats</returns>
        public static explicit operator float[](Matrix4 matrix)
        {
            return new float[16] { matrix.m_R1C1, matrix.m_R1C2, matrix.m_R1C3, matrix.m_R1C4
                                 , matrix.m_R2C1, matrix.m_R2C2, matrix.m_R2C3, matrix.m_R2C4
                                 , matrix.m_R3C1, matrix.m_R3C2, matrix.m_R3C3, matrix.m_R3C4
                                 , matrix.m_R4C1, matrix.m_R4C2, matrix.m_R4C3, matrix.m_R4C4};
        }
        /// <summary>
        /// Convert the 4x4 matrix to a column major array of float
        /// </summary>
        /// <returns>An array of 16 float</returns>
        public float[] ToUniformMatrix()
        {
            return new float[16] { m_R1C1, m_R2C1, m_R3C1, m_R4C1
                                 , m_R1C2, m_R2C2, m_R3C2, m_R4C2
                                 , m_R1C3, m_R2C3, m_R3C3, m_R4C3
                                 , m_R1C4, m_R2C4, m_R3C4, m_R4C4};
        }
        
        /// <summary>
        /// Computes a translation matrix from the given 3D coord values
        /// </summary>
        /// <param name="x">X component of the 3D coord values</param>
        /// <param name="y">Y component of the 3D coord values</param>
        /// <param name="z">Z component of the 3D coord values</param>
        /// <returns>A 4x4 translation matrix</returns>
        public static Matrix4 Translation(float x, float y, float z)
        {
            return new Matrix4(1, 0, 0, x
                             , 0, 1, 0, y
                             , 0, 0, 1, z
                             , 0, 0, 0, 1);
        }
        /// <summary>
        /// Computes a translation matrix from the given 2D coord values
        /// </summary>
        /// <param name="v">A 2D coord value, Z will be 0</param>
        /// <returns>A 4x4 translation matrix</returns>
        public static Matrix4 Translation(Vector2 v)
        {
            return Translation(v.X, v.Y, 0);
        }
        /// <summary>
        /// Computes a translation matrix from the given homogeneous coord values
        /// </summary>
        /// <param name="v">An homogeneous coord value. W is not used</param>
        /// <returns>A 4x4 translation matrix</returns>
        public static Matrix4 Translation(Vector4 v)
        {
            return Translation(v.X, v.Y, v.Z);
        }

        /// <summary>
        /// Computes a scaling matrix from the given 3D coord values
        /// </summary>
        /// <param name="x">X component of the 3D coord values</param>
        /// <param name="y">Y component of the 3D coord values</param>
        /// <param name="z">Z component of the 3D coord values</param>
        /// <returns>A 4x4 translation matrix</returns>
        public static Matrix4 Scale(float x, float y, float z)
        {
            return new Matrix4(x, 0, 0, 0
                             , 0, y, 0, 0
                             , 0, 0, z, 0
                             , 0, 0, 0, 1);
        }
        /// <summary>
        /// Computes a scaling matrix from the given 2D coord values
        /// </summary>
        /// <param name="v">A 2D coord value, Z will be 1</param>
        /// <returns>A 4x4 translation matrix</returns>
        public static Matrix4 Scale(Vector2 v)
        {
            return Scale(v.X, v.Y, 1);
        }
        /// <summary>
        /// Computes a scaling matrix from the given homogeneous coord values
        /// </summary>
        /// <param name="v">An homogeneous coord value. W is not used</param>
        /// <returns>A 4x4 translation matrix</returns>
        public static Matrix4 Scale(Vector4 v)
        {
            return Scale(v.X, v.Y, v.Z);
        }
        
        /// <summary>
        /// Creates a rotation matrix, through X axis
        /// </summary>
        /// <param name="angleInDegrees">Rotation angle in degrees</param>
        /// <returns>a 4x4 rotation matrix</returns>
        public static Matrix4 RotationX(float angleInDegrees)
        {
            double a = angleInDegrees * Helper.DEG2RAD;
            float cos = (float)System.Math.Cos(a);
            float sin = (float)System.Math.Sin(a);
            return new Matrix4(1,   0,    0, 0
                             , 0, cos, -sin, 0
                             , 0, sin,  cos, 0
                             , 0,   0,    0, 1);
        }
        /// <summary>
        /// Creates a rotation matrix, through Y axis
        /// </summary>
        /// <param name="angleInDegrees">Rotation angle in degrees</param>
        /// <returns>a 4x4 rotation matrix</returns>
        public static Matrix4 RotationY(float angleInDegrees)
        {
            double a = angleInDegrees * Helper.DEG2RAD;
            float cos = (float)System.Math.Cos(a);
            float sin = (float)System.Math.Sin(a);
            return new Matrix4(cos, 0, sin, 0
                             ,   0, 1,   0, 0
                             ,-sin, 0, cos, 0
                             ,   0, 0,   0, 1);
        }
        /// <summary>
        /// Creates a rotation matrix, through Z axis
        /// </summary>
        /// <param name="angleInDegrees">Rotation angle in degrees</param>
        /// <returns>a 4x4 rotation matrix</returns>
        public static Matrix4 RotationZ(float angleInDegrees)
        {
            double a = angleInDegrees * Helper.DEG2RAD;
            float cos = (float)System.Math.Cos(a);
            float sin = (float)System.Math.Sin(a);
            return new Matrix4(cos, -sin, 0, 0
                             , sin,  cos, 0, 0
                             ,   0,    0, 1, 0
                             ,   0,    0, 0, 1);
        }

        /// <summary>
        /// Creates a Yaw, Pitch, Roll rotation matrix
        /// </summary>
        /// <param name="yawPitchRoll">A Vector4 where :<br />- X is Pitch<br />- Y is Yaw<br />- Z is Roll</param>
        /// <param name="matYawPitchRoll">The computed Yaw, Pitch, Roll rotation matrix</param>
        public static void RotationYawPitchRoll(Vector4 yawPitchRoll, out Matrix4 matYawPitchRoll)
        {
            //return RotationY(yawPitchRoll.Y) * RotationX(yawPitchRoll.X) * RotationZ(yawPitchRoll.Z);
            Matrix4 mRotY = RotationY(yawPitchRoll.Y);
            Matrix4 mRotX = RotationX(yawPitchRoll.X);
            Matrix4 mRotZ = RotationZ(yawPitchRoll.Z);
            Matrix4 mRotYX;
            Matrix4.Multiply(ref mRotY, ref mRotX, out mRotYX);
            Matrix4.Multiply(ref mRotYX, ref mRotZ, out matYawPitchRoll);
        }
        
        /// <summary>
        /// Creates a Perspective projection matrix, from a frustum
        /// </summary>
        /// <param name="left">Left vertical clipping plane</param>
        /// <param name="right">Right vertical clipping plane</param>
        /// <param name="bottom">Bottom horizontal clipping plane</param>
        /// <param name="top">Top horizontal clipping plane</param>
        /// <param name="near">Near depth clipping plane</param>
        /// <param name="far">Far depth clipping plane</param>
        /// <returns>a 4x4 projection matrix</returns>
        public static Matrix4 PerspectiveOffCenter(float left, float right, float bottom, float top, float near, float far)
        {
            float near2 = near * 2.0f;
            float rSl = right - left;
            float tSb = top - bottom;
            float fSn = far - near;
            return new Matrix4(near2 / rSl,           0, (right + left) / rSl,                    0
                             ,           0, near2 / tSb, (top + bottom) / tSb,                    0
                             ,           0,           0,  -(far + near) / fSn, -(near2 * far) / fSn
                             ,           0,           0,                   -1,                    0);
        }
        /// <summary>
        /// Creates a Perspective projection matrix, from FOV, aspect ration and near and far depth clipping planes
        /// </summary>
        /// <param name="fovY">Specifies the field of view angle, in degrees, in the y direction</param>
        /// <param name="aspect">Specifies the aspect ratio that determines the field of view in the x direction. The aspect ratio is the ratio of x (width) to y (height)</param>
        /// <param name="near">Specifies the distance from the viewer to the near clipping plane (always positive)</param>
        /// <param name="far">Specifies the distance from the viewer to the far clipping plane (always positive)</param>
        /// <returns>a 4x4 projection matrix</returns>
        public static Matrix4 PerpectiveFOV(float fovY, float aspect, float near, float far)
        {
            float top = near * (float)System.Math.Tan(0.5 * fovY * Helper.DEG2RAD);
            float bottom = -top;
            float left = bottom * aspect;
            float right = top * aspect;
            return PerspectiveOffCenter(left, right, bottom, top, near, far);
        }
        /// <summary>
        /// Creates an Orthogonal projection matrix
        /// </summary>
        /// <param name="left">Left vertical clipping plane</param>
        /// <param name="right">Right vertical clipping plane</param>
        /// <param name="bottom">Bottom horizontal clipping plane</param>
        /// <param name="top">Top horizontal clipping plane</param>
        /// <param name="near">Near depth clipping plane</param>
        /// <param name="far">Far depth clipping plane</param>
        /// <returns>a 4x4 projection matrix</returns>
        public static Matrix4 OrthoOffCenter(float left, float right, float bottom, float top, float near, float far)
        {
            float invRSL = 1 / (right - left);
            float invTSB = 1 / (top - bottom);
            float invFSN = 1 / (far - near);
            return new Matrix4(2 * invRSL,          0,           0, -(right + left) * invRSL
                             ,          0, 2 * invTSB,           0, -(top + bottom) * invTSB
                             ,          0,          0, -2 * invFSN,   -(far + near) * invFSN
                             ,          0,          0,           0,                        1);
        }
        /// <summary>
        /// Creates a centered Orthogonal projection matrix
        /// </summary>
        /// <param name="width">Width between the verticals clipping planes</param>
        /// <param name="height">Height between the horizontals clipping planes</param>
        /// <param name="near">Near depth clipping plane</param>
        /// <param name="far">Far depth clipping plane</param>
        /// <returns>a 4x4 projection matrix</returns>
        public static Matrix4 Ortho(float width, float height, float near, float far)
        {
            return OrthoOffCenter(-width / 2.0f, width / 2.0f, -height / 2.0f, height / 2.0f, near, far);
        }
        /// <summary>
        /// Creates a 2D Orthogonal projection matrix
        /// </summary>
        /// <param name="width">Width of the 2D projection</param>
        /// <param name="height">Height of the 2D projection</param>
        /// <returns>a 4x4 projection matrix</returns>
        public static Matrix4 Ortho2D(float width, float height)
        {
            return OrthoOffCenter(0, width, 0, height, -1.0f, 1.0f);
        }
        /// <summary>
        /// Creates a 2D Orthogonal projection matrix<br />
        /// (0, 0) will be at the top-left corner of the viewport, instead of the bottom-left corner
        /// </summary>
        /// <param name="width">Width of the 2D projection</param>
        /// <param name="height">Height of the 2D projection</param>
        /// <returns>a 4x4 projection matrix</returns>
        public static Matrix4 Ortho2DInv(float width, float height)
        {
            return OrthoOffCenter(0, width, height, 0, -1.0f, 1.0f);
        }

        /// <summary>
        /// Creates a 2D Orthogonal projection matrix
        /// </summary>
        /// <param name="center">The center of the 2D projection rectangle</param>
        /// <param name="size">The size of the 2D projection rectangle</param>
        /// <returns>a 4x4 projection matrix</returns>
        public static Matrix4 Ortho2DOffCenter(Point center, Size size)
        {
            return OrthoOffCenter(center.X - size.Width / 2, center.X + size.Width / 2, center.Y + size.Height / 2, center.Y - size.Height / 2, -1.0f, 1.0f);
        }
        
        /// <summary>
        /// Creates a "Look at" view matrix
        /// </summary>
        /// <param name="eye">Specifies the position of the eye point</param>
        /// <param name="target">Specifies the position of the reference point</param>
        /// <param name="up">Specifies the direction of the up vector</param>
        /// <returns>a 4x4 view matrix</returns>
        public static Matrix4 LookAt(Vector4 eye, Vector4 target, Vector4 up)
        {
            Vector4 dirN = (eye - target).Normalized;
            Vector4 sideN = Vector4.Cross(ref up, ref dirN).Normalized;
            Vector4 upN = Vector4.Cross(ref dirN, ref sideN).Normalized;
            Matrix4 mRot = new Matrix4(sideN.X, sideN.Y, sideN.Z, 0
                                   ,   upN.X,   upN.Y,   upN.Z, 0
                                   ,  dirN.X,  dirN.Y,  dirN.Z, 0
                                   ,       0,       0,       0, 1);
            Matrix4 mTrans = Translation(-eye);
            Matrix4 mLookAt;
            Matrix4.Multiply(ref mRot, ref mTrans, out mLookAt);
            return mLookAt;
        }
        
        /// <summary>
        /// Computes a Model-View-Projection matrix from the 3 separated matrices
        /// </summary>
        /// <param name="matModel">The model matrix</param>
        /// <param name="matView">The view matrix</param>
        /// <param name="matProj">The projection matrix</param>
        /// <param name="matMVP">a 4x4 Model-View-Projection matrix</param>
        public static void ComputeMVP(ref Matrix4 matModel, ref Matrix4 matView, ref Matrix4 matProj, out Matrix4 matMVP)
        {
            Matrix4 matMV;
            Matrix4.Multiply(ref matView, ref matModel, out matMV);
            Matrix4.Multiply(ref matProj, ref matMV, out matMVP);
        }

        /// <summary>
        /// A 4x4 identity matrix
        /// </summary>
        public static readonly Matrix4 Identity = new Matrix4(1);

        /// <summary>
        /// Transform a Vector2, using the Matrix
        /// </summary>
        /// <param name="v">The Vector2 to transform</param>
        /// <returns>The transformed Vector2</returns>
        public Vector2 Transform(Vector2 v)
        {
            return new Vector2(m_R1C1 * v.X + m_R1C2 * v.Y, m_R2C1 * v.X + m_R2C2 * v.Y);
        }
    }
}
