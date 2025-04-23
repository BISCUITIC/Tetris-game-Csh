using System;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Tetris_game
{
    internal class Program
    {
        const int Tick = 100;
        static void Main(string[] args)
        {
            Progress progress = new Progress();
            Game game = new Game(progress.GetSavedScore());
            Clock clock = new Clock();
                      
            //Console.BackgroundColor = ConsoleColor.Gray;
            //Console.ForegroundColor = ConsoleColor.Black;         
                        
            double pastTime = 0;

            while (!game.over)
            {
                clock.Update();

                pastTime += clock.DeltaTima();
                if (pastTime >= Tick)
                {                    
                    game.Update();
                    pastTime = 0;
                }

            }

            progress.Save(game.GetScore());

        }
    }
}
