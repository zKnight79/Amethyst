using System;
using System.Runtime.InteropServices;

using Amethyst.Math;

namespace Amethyst.Graphics
{
    /// <summary>
    /// Structure representing a 2D Vertex with :<br />
    /// - 2 components (X, Y) Position<br />
    /// - 4 components (R, G, B, A) Color<br />
    /// - 2 components (U, V) texture coordinates
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Vertex
    {
        /// <summary>
        /// The offset of the Position part of the Vertex
        /// </summary>
        public static readonly int PositionOffset = 0;
        /// <summary>
        /// The size of the Position part of the Vertex
        /// </summary>
        public static readonly int PositionSize = 2;
        /// <summary>
        /// The offset of the Color part of the Vertex
        /// </summary>
        public static readonly int ColorOffset = PositionOffset + Vector2.Size;
        /// <summary>
        /// The size of the Color part of the Vertex
        /// </summary>
        public static readonly int ColorSize = 4;
        /// <summary>
        /// The offset of the Texture Coord part of the Vertex
        /// </summary>
        public static readonly int TexCoordOffset = ColorOffset + Vector4.Size;
        /// <summary>
        /// The size of the Texture Coord part of the Vertex
        /// </summary>
        public static readonly int TexCoordSize = 2;
        
        /// <summary>
        /// The position of the vertex
        /// </summary>
        public Vector2 Position;
        /// <summary>
        /// The color of the vertex
        /// </summary>
        public Vector4 Color;
        /// <summary>
        /// The texture coordinates of the vertex
        /// </summary>
        public Vector2 TexCoord;

        /// <summary>
        /// Creates a new 2D vertex with position, color and texture coordinates
        /// </summary>
        /// <param name="position">The position of the vertex</param>
        /// <param name="color">The color of the vertex</param>
        /// <param name="texCoord">The texture coordinates of the vertex</param>
        public Vertex(Vector2 position, Vector4 color, Vector2 texCoord)
        {
            Position = position;
            Color = color;
            TexCoord = texCoord;
        }
        /// <summary>
        /// Creates a new 2D vertex with position, color and texture coordinates
        /// </summary>
        /// <param name="position">The position of the vertex</param>
        /// <param name="color">The color of the vertex</param>
        /// <param name="texCoord">The texture coordinates of the vertex</param>
        public Vertex(Vector2 position, Color4 color, Vector2 texCoord) : this(position, new Vector4(color), texCoord) { }

        /// <summary>
        /// Get the size in bytes of a VertexP2C4T2
        /// </summary>
        public static int Size
        {
            get
            {
                return Vector2.Size + Vector4.Size + Vector2.Size;
            }
        }
    }
}
