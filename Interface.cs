    using System;
using System.Runtime.InteropServices;

namespace Tetris_game
{
    internal class Interface
    {
        private const int InterfaceWigth = 50;
        private const int InterfaceHeight = 29;

        private char[,] interfaceField = new char[InterfaceHeight, InterfaceWigth];

        private int frame = 0;

       
        public Interface() {
            for (int i = 0; i < InterfaceHeight; i++)
            {
                for (int j = 0; j < InterfaceWigth; j++)
                {
                    interfaceField[i, j] = ' ';
                }
            }
            
        }

        public void Update(GameField gameField, int indexOfFigure, bool gameOver, int score, int bestScore)
        {
            Console.SetCursorPosition(0, 0);
            PrintGameField(1, 1, gameField);

            int padding = 3;
            PrintText(padding + gameField.GetWidth() + 1, 1, "NEXT FIGURE");
            PrintText(padding + gameField.GetWidth(), 2, "-------------");
            PrintNextFigure(padding + gameField.GetWidth() + 4, 3, indexOfFigure);
            PrintText(padding + gameField.GetWidth(), 7, "-------------");

            PrintText(padding + gameField.GetWidth() + 1, 10, "YOUT  SCORE");
            PrintText(padding + gameField.GetWidth(), 11, "-------------");
            PrintText(padding + gameField.GetWidth() + 4, 12, string.Format("{0:d5}", score));
            PrintText(padding + gameField.GetWidth(), 13, "-------------");

            PrintText(padding + gameField.GetWidth() + 1 + 16, 10, "BEST  SCORE");
            PrintText(padding + gameField.GetWidth() + 16, 11, "-------------");
            PrintText(padding + gameField.GetWidth() + 4 + 16, 12, string.Format("{0:d5}", bestScore));
            PrintText(padding + gameField.GetWidth() + 16, 13, "-------------");

            if (gameOver)
            {                
                PrintText(padding + gameField.GetWidth() + 2 + 4, 15, "█▀▀ ▄▀█ █▀▄▀█ █▀▀");
                PrintText(padding + gameField.GetWidth() + 2 + 4, 16, "█▄█ █▀█ █░▀░█ ██▄");
                PrintText(padding + gameField.GetWidth() + 2 + 5, 18, "█▀█ █░█ █▀▀ █▀█");
                PrintText(padding + gameField.GetWidth() + 2 + 5, 19, "█▄█ ▀▄▀ ██▄ █▀▄");
            }                
        }

        private void PrintGameField(int x, int y, GameField gameField)
        {
            for (int i = 0; i < gameField.GetHeight(); i++)
            {
                for (int j = 0; j < gameField.GetWidth(); j++)
                {
                    interfaceField[y + i, x + j] = gameField.GetGameField()[i, j];
                }
            }
        }
        private void PrintText(int x, int y, string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                interfaceField[y, x + i] = str[i];
            }
        }
        
        private void PrintNextFigure(int x, int y, int indexOfFigure)
        {
            switch (indexOfFigure)
            {
                case -1:
                    PrintText(x, y + 0, ".....");
                    PrintText(x, y + 1, ".....");
                    PrintText(x, y + 2, ".....");
                    PrintText(x, y + 3, ".....");
                    break;
                case 0:
                    PrintText(x, y+0, "..#..");
                    PrintText(x, y+1, "..#..");
                    PrintText(x, y+2, "..#..");
                    PrintText(x, y+3, "..#..");
                    break;
                case 1:
                    PrintText(x, y+0, ".....");
                    PrintText(x, y+1, ".###.");
                    PrintText(x, y+2, ".###.");
                    PrintText(x, y+3, ".....");
                    break;
                case 2:
                    PrintText(x, y+0, ".....");
                    PrintText(x, y+1, ".##..");
                    PrintText(x, y+2, "..##.");
                    PrintText(x, y+3, ".....");
                    break;
                case 3:
                    PrintText(x, y+0, ".....");
                    PrintText(x, y+1, "..##.");
                    PrintText(x, y+2, ".##..");
                    PrintText(x, y+3, ".....");
                    break;
                case 4:
                    PrintText(x, y+0, ".....");
                    PrintText(x, y+1, "..#..");
                    PrintText(x, y+2, ".###.");
                    PrintText(x, y+3, ".....");
                    break;
                case 5:
                    PrintText(x, y+0, "..#..");
                    PrintText(x, y+1, "..#..");
                    PrintText(x, y+2, "..##.");
                    PrintText(x, y+3, ".....");
                    break;
                case 6:
                    PrintText(x, y+0, "..#..");
                    PrintText(x, y+1, "..#..");
                    PrintText(x, y+2, ".##..");
                    PrintText(x, y+3, ".....");
                    break;
            }
            
        }

        public void Print()
        {
            for (int i = 0; i < InterfaceHeight; i++)
            {
                for (int j = 0; j < InterfaceWigth; j++)
                {
                    Console.Write(interfaceField[i, j]);
                }
                Console.WriteLine();
            }       
        }
    }
}
