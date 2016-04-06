﻿using System;

namespace Map_Tool
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();

                //game.EnableVisualStyles();
                //game.SetCompatibleTextRenderingDefault(false);
                //game.Run(new Form1());

        }
    }
#endif
}
