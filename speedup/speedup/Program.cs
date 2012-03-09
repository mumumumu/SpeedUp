using System;
using System.Windows.Forms;
using fbDeprofiler;

namespace speedup {
    static class Program {
        // The main entry point for the application.
        static void Main( string[] args ) {
            DeProfiler.Run();
            using ( GameEngine game = new GameEngine() )
                game.Run();

        }
    }
}