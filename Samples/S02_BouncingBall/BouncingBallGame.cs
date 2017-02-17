using Amethyst.Engine;
using Amethyst.Graphics;
using Amethyst.Input;

namespace S02_BouncingBall
{
    class BouncingBallGame : Game
    {
        Font fpsFont;

        protected override bool OnInit()
        {
            AssetsLoadingScene = new BBAssetsLoadingScene()
            {
                Game = this
            };
            return base.OnInit();
        }

        protected override void OnStart()
        {
            BackgroundColor = Color4.Colors.SandyBrown;
            fpsFont = AssetManager.BuiltinFonts.SYSTEM_24;

            Keyboard.KeyDown += (key, modifiers) =>
            {
                if (key == Keys.Tab)
                {
                    VSync = !VSync;
                }
            };

            SceneManager.PushScene(new MenuScene());
        }

        protected override void OnRender(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawText(string.Format("FPS : {0}", GameTime.FramesPerSecond),
                fpsFont,
                TextRenderMode.Inline,
                ViewPort,
                BackgroundColor.Invert()
            );
        }
    }
}
