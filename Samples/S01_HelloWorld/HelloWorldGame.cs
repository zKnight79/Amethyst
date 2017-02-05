using Amethyst.Engine;

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
    }
}
