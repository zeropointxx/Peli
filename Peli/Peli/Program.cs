using System;

namespace Peli
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            Game1 game = new Game1();
            
                game.Run();
            
        }
    }
#endif
}

