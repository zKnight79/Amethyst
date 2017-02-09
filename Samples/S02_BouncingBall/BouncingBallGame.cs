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
        MoveStraightAnimator ballAnimator;

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
            ballSprite.AddAnimator(new RotateAnimator(360));
            ballSprite.AddAnimator(ballAnimator = new MoveStraightAnimator(new Point(300, 240)));
        }
        protected override void OnRelease()
        {
            ballTexture.Dispose();
            beachTexture.Dispose();
        }

        protected override void OnUpdate(float elapsedTime)
        {
            ballSprite.Update(elapsedTime);

            // Apply x-axis speed
            if ((ballAnimator.SpeedX < 0 && ballSprite.BoxLeft <= ViewPort.Left)
                ||
               (ballAnimator.SpeedX > 0 && ballSprite.BoxRight >= ViewPort.Right))
            {
                ballAnimator.SpeedX = -ballAnimator.SpeedX;
            }

            // Apply y-axis speed
            if ((ballAnimator.SpeedY < 0 && ballSprite.BoxTop <= ViewPort.Top)
                ||
               (ballAnimator.SpeedY > 0 && ballSprite.BoxBottom >= ViewPort.Bottom))
            {
                ballAnimator.SpeedY = -ballAnimator.SpeedY;
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
