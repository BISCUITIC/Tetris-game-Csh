using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Tetris_game
{
    
    
    internal class Game
    {
        public bool over;
        private int frame = 0;
        private int lastSpawnFrame = 0;
        private int gameScrore = 0;
        private int bestScrore = 0;

        private GameField _gameField = new GameField();
        private Keyboard _keyboard = new Keyboard();
        private Interface _interface = new Interface();

        private Position startPosition = new Position { x = 7, y = 2 };
        private Figure _figure;

        private int indexOfCurrentFigure = 0, indexOfNextFigure = 0;
        public Game(int bestScore)
        {
            Console.Title = "Tetris";
            Console.OutputEncoding = Encoding.Unicode;

            this.over = false;
            this.bestScrore = bestScore;

            indexOfCurrentFigure = SelectRandomFigure();
            indexOfNextFigure = SelectRandomFigure();
            _figure = new Figure(startPosition.x, startPosition.y, indexOfCurrentFigure);
        }

        public void Update()
        {
            frame++;

            _keyboard.Update();
            _figure.Update(_gameField, _keyboard.GetLastKey().ToString(), frame, indexOfCurrentFigure);
            _gameField.Update(_figure, _keyboard.GetLastKey(), ref gameScrore);
            
            _interface.Update(_gameField, indexOfNextFigure, over, gameScrore, bestScrore);
            _interface.Print();

            if (_keyboard.GetLastKey() == "Escape")
            {
                over = true;
                GameOver();
            }

            if (_figure.GetCollesed())
            {
                CheckForGameOver();

                indexOfCurrentFigure = indexOfNextFigure;
                indexOfNextFigure = SelectRandomFigure();

                _figure = new Figure(startPosition.x, startPosition.y, indexOfCurrentFigure);

                lastSpawnFrame = frame;
            }
        }

        private void GameOver()
        {
            _interface.Update(_gameField, -1, over, gameScrore, bestScrore);
            _interface.Print();
        }

        private void CheckForGameOver()
        {
            if (lastSpawnFrame + 4 >= frame)
            {
                over = true;
                GameOver();
            }
        }

        private int SelectRandomFigure()
        {
            Random random = new Random();
            return random.Next(0, 7);            
        }

        public int GetScore() => gameScrore;
    }
}
