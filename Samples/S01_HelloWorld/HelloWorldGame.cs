using Amethyst.Engine;
using Amethyst.Graphics;
using Amethyst.Math;

namespace S01_HelloWorld
{
    class HelloWorldGame : Game
    {
        static void Main()
        {
            using (HelloWorldGame game = new HelloWorldGame())
            {
                game.Run();
            }
        }

        Box box = new Box(300, 250, 200, 100);
        protected override void OnRender()
        {
            SpriteBatch.DrawText("Hello World", SystemFont, TextRenderMode.Inline, box, Color4.Colors.White, TextAlign.MiddleCenter);
            SpriteBatch.DrawRectangle(box, 3, Color4.Colors.AntiqueWhite);
        }
    }
}
