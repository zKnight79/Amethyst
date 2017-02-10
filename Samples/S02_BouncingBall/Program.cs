using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
