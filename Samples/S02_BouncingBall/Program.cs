namespace S02_BouncingBall
{
    static class Program
    {
        static void Main()
        {
            using (BouncingBallGame game = new BouncingBallGame())
            {
                game.Run();
            }
        }
    }
}
