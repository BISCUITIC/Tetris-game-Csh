using System;

namespace Tetris_game
{
    internal class Clock
    {
        DateTime dateTime1 = new DateTime();
        DateTime dateTime2 = new DateTime();
        public Clock() {
            dateTime1 = DateTime.Now;
            dateTime2 = DateTime.Now;
        }
        public void Update()
        {
            dateTime2 = dateTime1;
            dateTime1 = DateTime.Now;
        }
        public double DeltaTima() {
            return (dateTime1 - dateTime2).TotalMilliseconds;
        }
    }
}
