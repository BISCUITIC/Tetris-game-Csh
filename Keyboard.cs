using System;

namespace Tetris_game
{
    internal class Keyboard
    {
        private string lastPressedKey = " ";
        public Keyboard() { }

        public void Update()
        { 
            string pressedKey = " ";            
            while (Console.KeyAvailable)
            {
                pressedKey = Console.ReadKey(true).Key.ToString();                                        
            }
            lastPressedKey = pressedKey;
        }
        public string GetLastKey() => lastPressedKey;
    }
}
