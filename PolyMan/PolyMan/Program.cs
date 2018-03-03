using System;

namespace PolyMan
{
//#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (GameStateHandler game = new GameStateHandler())
            {
                game.Run();
            }
        }
    }
//#endif
}

