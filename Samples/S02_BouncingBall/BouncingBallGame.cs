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
        static void Main()
        {
            using (BouncingBallGame game = new BouncingBallGame())
            {
                game.Run();
            }
        }

        Texture ballTexture;
        Sprite ballSprite;
        MoveStraightAnimator ballAnimator;
        int ballClickCounter;

        protected override bool OnInit()
        {
            Random rnd = new Random();

            BackgroundColor = Color4.Colors.SandyBrown;

            ballTexture = new Texture(Textures.TOYBALL, TextureFiltering.Bilinear);

            ballSprite = new Sprite(new Box(0, 0, 100, 100), ballTexture)
            {
                BoxCenter = ViewPort.Center
            };
            ballSprite.AddAnimator(new RotateAnimator(360));
            ballSprite.AddAnimator(ballAnimator = new MoveStraightAnimator(rnd.Next(20,71), 500));

            Mouse.LeftClick += (MouseState) =>
            {
                if (ballSprite.Box.Contains(MouseState.X, MouseState.Y))
                {
                    ++ballClickCounter;
                } else
                {
                    --ballClickCounter;
                }
            };

            Keyboard.KeyDown += (key, modifiers) => { if (key == Keys.Tab) { VSync = !VSync; } };

            return base.OnInit();
        }

        protected override void OnRelease()
        {
            ballTexture.Dispose();
        }

        protected override void OnUpdate(float elapsedTime)
        {
            ballSprite.Update(elapsedTime);

            #region Apply x-axis speed
            if ((ballAnimator.SpeedX < 0 && ballSprite.BoxLeft <= ViewPort.Left)
                ||
               (ballAnimator.SpeedX > 0 && ballSprite.BoxRight >= ViewPort.Right))
            {
                ballAnimator.SpeedX = -ballAnimator.SpeedX;
            }
            #endregion

            #region Apply y-axis speed
            if ((ballAnimator.SpeedY < 0 && ballSprite.BoxTop <= ViewPort.Top)
                ||
               (ballAnimator.SpeedY > 0 && ballSprite.BoxBottom >= ViewPort.Bottom))
            {
                ballAnimator.SpeedY = -ballAnimator.SpeedY;
            }
            #endregion

            #region Change opacity of the ball with Up and Down arrows
            if (Keyboard[Keys.Up])
            {
                ballSprite.ColorAlpha += 0.5f * elapsedTime;
            }
            else if (Keyboard[Keys.Down])
            {
                ballSprite.ColorAlpha -= 0.5f * elapsedTime;
            }
            #endregion
        }
        protected override void OnRender(SpriteBatch spriteBatch)
        {
            ballSprite.Render(spriteBatch);
            spriteBatch.DrawText(string.Format("FPS : {0}\nScore : {1}", GameTime.FramesPerSecond, ballClickCounter),
                SystemFont,
                TextRenderMode.Inline,
                ViewPort,
                BackgroundColor.Invert()
            );
        }
    }
}
