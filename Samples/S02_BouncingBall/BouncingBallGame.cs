﻿using Amethyst.Engine;
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
        public const string TEXTURE_TOYBALL = "TOYBALL";

        Font fpsFont;
        protected override bool OnInit()
        {
            BackgroundColor = Color4.Colors.SandyBrown;
            fpsFont = AssetManager.Instance.GetFont(AssetManager.BuiltinFonts.SYSTEM_24);

            Keyboard.KeyDown += (key, modifiers) =>
            {
                if (key == Keys.Tab)
                {
                    VSync = !VSync;
                }
            };

            AssetManager.Instance.AddTexture(TEXTURE_TOYBALL, new Texture(Textures.TOYBALL, TextureFiltering.Bilinear));

            SceneManager.PushScene(new BouncingBallScene());

            return base.OnInit();
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
