using Amethyst.Engine;
using Amethyst.Engine.Animators;
using Amethyst.Engine.SceneNodes;
using Amethyst.Graphics;
using Amethyst.Input;
using Amethyst.Math;
using System;

namespace S02_BouncingBall
{
    class BouncingBallGame : Game
    {
        protected override bool OnInit()
        {
            BackgroundColor = Color4.Colors.SandyBrown;

            Keyboard.KeyDown += (key, modifiers) =>
            {
                if (key == Keys.Tab)
                {
                    VSync = !VSync;
                }
            };

            SceneManager.PushScene(new BouncingBallScene());

            return base.OnInit();
        }

        protected override void OnRender(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawText(string.Format("FPS : {0}", GameTime.FramesPerSecond),
                SystemFont,
                TextRenderMode.Inline,
                ViewPort,
                BackgroundColor.Invert()
            );
        }
    }
}
