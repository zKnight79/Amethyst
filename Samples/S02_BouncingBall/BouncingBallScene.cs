using Amethyst.Engine;
using Amethyst.Engine.Animators;
using Amethyst.Engine.SceneNodes;
using Amethyst.Engine.UINodes;
using Amethyst.Graphics;
using Amethyst.Input;
using Amethyst.Math;
using System;

namespace S02_BouncingBall
{
    class BouncingBallScene : Scene
    {
        Game gameInstance;
        Sprite ballSprite;
        Label scoreLabel;
        MoveStraightAnimator ballAnimator;
        int ballClickCounter;
        Random rnd = new Random();

        public override void OnLoad()
        {
            gameInstance = SceneManager.Game;
            
            ballSprite = new Sprite(new Box(0, 0, 100, 100), AssetManager.Instance.GetTexture(Textures.TOYBALL_TEX_NAME));
            AddNode(ballSprite);

            scoreLabel = new Label(gameInstance.ViewPort, "Score : 0", AssetManager.Instance.GetFont(AssetManager.BuiltinFonts.ARIAL_BLACK_48), gameInstance.BackgroundColor.Invert())
            {
                TextAlign = TextAlign.Right,
                TextRenderMode = TextRenderMode.Inline
            };
            AddUINode(scoreLabel);
        }
        public override void OnGetFocus()
        {
            ballSprite.BoxCenter = gameInstance.ViewPort.Center;
            ballSprite.AddAnimator(new RotateAnimator(360));
            ballSprite.AddAnimator(ballAnimator = new MoveStraightAnimator(rnd.Next(20, 71), 500));
        }
        public override void OnLoseFocus()
        {
            ballSprite.ClearAnimators();
        }

        public override void OnMouseLeftClick(MouseState mouseState)
        {
            if (ballSprite.Box.Contains(mouseState.X, mouseState.Y))
            {
                ++ballClickCounter;
            }
            else
            {
                --ballClickCounter;
            }
            scoreLabel.Text = string.Format("Score : {0}", ballClickCounter);
        }

        public override void OnUpdate(float elapsedTime)
        {
            #region Check Viewport Left or Right collision
            if ((ballAnimator.SpeedX < 0 && ballSprite.BoxLeft <= gameInstance.ViewPort.Left)
                ||
               (ballAnimator.SpeedX > 0 && ballSprite.BoxRight >= gameInstance.ViewPort.Right))
            {
                ballAnimator.SpeedX = -ballAnimator.SpeedX;
            }
            #endregion

            #region Check Viewport Top or Bottom collision
            if ((ballAnimator.SpeedY < 0 && ballSprite.BoxTop <= gameInstance.ViewPort.Top)
                ||
               (ballAnimator.SpeedY > 0 && ballSprite.BoxBottom >= gameInstance.ViewPort.Bottom))
            {
                ballAnimator.SpeedY = -ballAnimator.SpeedY;
            }
            #endregion
        }
    }
}
