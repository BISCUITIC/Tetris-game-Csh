using System;

namespace Tetris_game
{
    internal class GameField
    {
        private const int FieldWidth = 15;
        private const int FieldHeight = 20;

        private char[,] gameField = new char[FieldHeight, FieldWidth];

        public GameField() {
            for (int i = 0; i < FieldHeight; i++)
            {
                for (int j = 0; j < FieldWidth; j++)
                {                    
                    gameField[i, j] = Constans.BGChar;
                }
            }
        }

        public void Update(Figure figure,string key, ref int gameScore)
        {
            DrawFigure(figure);            
            FieldLogic(ref gameScore);
        }

        private void DrawFigure(Figure figure)
        {
            for (int i = 0; i < FieldHeight; i++)
            {
                for (int j = 0; j < FieldWidth; j++)
                {
                    if (gameField[i, j] == Constans.ActiveBlockChar) gameField[i, j] = Constans.BGChar;
                }
            }

            if (figure.GetCollesed())
            {
                for (int i = 0; i < figure.GetFigure().Length; i++)
                {
                    gameField[figure.GetFigure()[i].y, figure.GetFigure()[i].x] = Constans.BlockChar;
                }
                return;
            }
            
            for (int i = 0;i < figure.GetFigure().Length; i++)
            {
                gameField[figure.GetFigure()[i].y, figure.GetFigure()[i].x] = Constans.ActiveBlockChar; 
            }
        }

        private void FieldLogic(ref int gameScore)
        {
            int countOfEmptyRows = 0;
            for (int i = FieldHeight - 1; i >= 0; i--)
            {
                if (RowIsFull(i))
                {
                    ClearRow(i);
                    countOfEmptyRows++;
                }
                else
                {
                    LineShift(i, countOfEmptyRows);
                }
            }
            gameScore += (countOfEmptyRows * countOfEmptyRows) * 100;
        }
        private bool RowIsFull(int i)
        {
            int counter = 0;
            for (int j = 0; j < FieldWidth; j++)
            {
                if (gameField[i, j] == Constans.BlockChar) counter++;
            }
            if (counter == FieldWidth) return true;
            else return false;
        }
        private void ClearRow(int i)
        {            
            for (int j = 0; j < FieldWidth; j++)
            {
                gameField[i, j] = Constans.BGChar;
            }
        }
        private void LineShift(int i, int delta)
        {
            if (delta == 0) return;
            for (int j = 0; j < FieldWidth; j++)
            {
                gameField[i + delta, j] = gameField[i, j];
                gameField[i, j] = Constans.BGChar;
            }
        }
        
        public char[,] GetGameField()
        {
            return gameField;
        }
        public int GetHeight() => FieldHeight;
        public int GetWidth() => FieldWidth;
    }
}
