using Amethyst.Engine;
using Amethyst.Engine.Animators;
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

        Texture beachTexture;
        Texture ballTexture;
        Sprite backroundSprite;
        Sprite ballSprite;

        protected override void OnInit()
        {
            BackgroundColor = Color4.Colors.SandyBrown;

            ballTexture = new Texture(Textures.TOYBALL, TextureFiltering.Bilinear);
            beachTexture = new Texture(Textures.BEACH_800x600, TextureFiltering.Bilinear);

            backroundSprite = new Sprite(ViewPort, beachTexture);
            ballSprite = new Sprite(new Box(0, 0, 100, 100), ballTexture)
            {
                BoxCenter = ViewPort.Center
            };
            ballSprite.AddAnimator(new RotateAnimator(360, 10));
        }
        protected override void OnRelease()
        {
            ballTexture.Dispose();
            beachTexture.Dispose();
        }

        private float xAxisSpeed = 300;    // (pixels per second)
        private float yAxisSpeed = 240;    // (pixels per second)
        protected override void OnUpdate(float elapsedTime)
        {
            ballSprite.Update(elapsedTime);

            // Apply x-axis speed
            ballSprite.BoxX += elapsedTime * xAxisSpeed;
            if((xAxisSpeed<0 && ballSprite.BoxLeft<=ViewPort.Left)
                ||
               (xAxisSpeed > 0 && ballSprite.BoxRight >= ViewPort.Right))
            {
                xAxisSpeed = -xAxisSpeed;
            }

            // Apply y-axis speed
            ballSprite.BoxY += elapsedTime * yAxisSpeed;
            if ((yAxisSpeed < 0 && ballSprite.BoxTop <= ViewPort.Top)
                ||
               (yAxisSpeed > 0 && ballSprite.BoxBottom >= ViewPort.Bottom))
            {
                yAxisSpeed = -yAxisSpeed;
            }
        }
        protected override void OnRender(SpriteBatch spriteBatch)
        {
            backroundSprite.Render(spriteBatch);
            ballSprite.Render(spriteBatch);
            spriteBatch.DrawText("FPS : " + GameTime.FramesPerSecond, SystemFont, TextRenderMode.Inline, ViewPort, Color4.Colors.DarkRed);
        }
    }
}
