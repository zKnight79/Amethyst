using Amethyst.Graphics;
using Amethyst.Math;

namespace Amethyst.Engine.SceneNodes
{
    /// <summary>
    /// A Sprite is a Node that render its texture.
    /// </summary>
    public class Sprite : SceneNode
    {
        /// <summary>
        /// Creates an instance of Sprite
        /// </summary>
        /// <param name="box">The Box where to render the Sprite</param>
        /// <param name="texture">The Texture of the Sprite</param>
        public Sprite(Box box, Texture texture) : base(box)
        {
            Texture = texture;
        }
    }
}
