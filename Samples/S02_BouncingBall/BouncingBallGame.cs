using Amethyst.Engine;
using Amethyst.Engine.SceneNodes;
using Amethyst.Graphics;
using Amethyst.Math;

namespace S02_BouncingBall
{
    class BouncingBallGame : Game
    {
        static void Main()
        {
            using (BouncingBallGame game = new BouncingBallGame())
            {
                game.Run();
            }
        }

        Texture ballTexture;
        Sprite ballSprite;

        protected override void OnInit()
        {
            BackgroundColor = Color4.Colors.SandyBrown;

            ballTexture = new Texture(Textures.TOYBALL, TextureFiltering.Bilinear);

            ballSprite = new Sprite(new Box(0, 0, 100, 100))
            {
                Texture = ballTexture,
                BoxCenter = ViewPort.Center
            };
        }
        protected override void OnRelease()
        {
            ballTexture?.Dispose();
        }

        protected override void OnUpdate(float elapsedTime)
        {
            ballSprite.Angle += elapsedTime * 360;
            ballSprite?.Update(elapsedTime);
        }
        protected override void OnRender(SpriteBatch spriteBatch)
        {
            ballSprite?.Render(spriteBatch);
            spriteBatch.DrawText("FPS : " + GameTime.FramesPerSecond, SystemFont, TextRenderMode.Inline, ViewPort, Color4.Colors.White);
        }
    }
}
