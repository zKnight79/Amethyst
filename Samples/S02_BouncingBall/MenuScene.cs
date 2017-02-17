using Amethyst.Engine;
using Amethyst.Engine.UINodes;
using Amethyst.Graphics;
using Amethyst.Math;

namespace S02_BouncingBall
{
    class MenuScene : Scene
    {

        Label startLabel;
        Label quitLabel;

        public override void OnLoad()
        {
            Box b = SceneManager.Game.ViewPort;

            Box bStart = new Box()
            {
                Size = new Size(400, 100),
                Center = b.Center - new Point(0, 60)
            };
            startLabel = new Label(bStart, "Start", AssetManager.CustomFonts[Fonts.COMIC72_FONT_NAME], Color4.Colors.LightSeaGreen.Brighter(1.25f));
            AddUINode(startLabel);

            Box bQuit = new Box()
            {
                Size = new Size(400, 100),
                Center = b.Center + new Point(0, 60)
            };
            quitLabel = new Label(bQuit, "Quit", AssetManager.CustomFonts[Fonts.COMIC72_FONT_NAME], Color4.Colors.LightSeaGreen.Brighter(1.25f));
            AddUINode(quitLabel);
        }
    }
}
