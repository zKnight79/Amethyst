using Amethyst.Graphics;
using Amethyst.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Amethyst.Engine.Scenes
{
    /// <summary>
    /// Basic base Scene for Assets loading
    /// </summary>
    public abstract class AssetsLoadingScene : Scene
    {
        /// <summary>
        /// Get or set if loading is finished or not
        /// </summary>
        public bool LoadingFinished { get; protected set; } = false;
        /// <summary>
        /// Get or set the Game we want to load assets for
        /// </summary>
        public Game Game { get; set; }

        /// <summary>
        /// Default render "Loading ..." on the Screen
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch used to render the Scene</param>
        public override void Render(SpriteBatch spriteBatch)
        {
            Font font = AssetManager.BuiltinFonts.ARIAL_BLACK_48;
            Box box = Game?.ViewPort ?? new Box(0, 0, 200, 200);
            Color4 color = Color4.Colors.White;

            spriteBatch.DrawText("Loading ...", font, TextRenderMode.Inline, box, color, TextAlign.MiddleCenter);
        }
    }
}
