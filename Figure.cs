using System;

namespace Tetris_game
{
    struct Position
    {
        public int x;
        public int y;
        public static Position operator +(Position pos1, Position pos2)
        {
            return new Position { x = pos1.x + pos2.x, y = pos1.y + pos2.y };
        }
    }

    internal class Figure
    {
        private Position[,] figurePool =
        {
            {
                new Position { x = 0, y = -2 }, // |
                new Position { x = 0, y = -1 },
                new Position { x = 0, y = 0 },
                new Position { x = 0, y = 1 }
            },
            {
                new Position { x = 0, y = 0 }, // ■
                new Position { x = 0, y = 1 },
                new Position { x = 1, y = 1 },
                new Position { x = 1, y = 0 }
            },
            {
                new Position { x = -1, y = -1 }, // Z
                new Position { x = 0, y = -1 },
                new Position { x = 0, y = 0 },
                new Position { x = 1, y = 0 }
            },
            {
                new Position { x = 1, y = -1 }, // S
                new Position { x = 0, y = -1 },
                new Position { x = 0, y = 0 },
                new Position { x = -1, y = 0 }
            },
            {
                new Position { x = 0, y = -1 }, // T
                new Position { x = 1, y = 0 },
                new Position { x = -1, y = 0 },
                new Position { x = 0, y = 0 }
            },
            {
                new Position { x = 0, y = -1 }, // L
                new Position { x = 0, y = 0 },
                new Position { x = 0, y = 1 },
                new Position { x = 1, y = 1 }
            },
            {
                new Position { x = 0, y = -1 }, // J
                new Position { x = 0, y = 0 },
                new Position { x = 0, y = 1 },
                new Position { x = -1, y = 1 }
            }
        };
        private Position[] body = new Position[4];

        public Position position = new Position();
        private bool isCollised = false;
        public Figure(int startPositionX, int startPositionY, int indexOfFigure) {            
            for (int i = 0; i < 4; i++)            
                body[i] = figurePool[indexOfFigure, i];
                

            position.x = startPositionX;
            position.y = startPositionY;
        }

        public void Update(GameField gameField, string key, int frame, int indexOfFigure) {
            if (isCollised) { return; }

            switch (key)
            {
                case "D":
                    if(!CheckShiftCollision(gameField, 1, 0))
                        position.x++;
                    break;
                case "A":
                    if (!CheckShiftCollision(gameField, -1, 0))
                        position.x--;
                    break;
                case "S":
                    if (!CheckShiftCollision(gameField, 0, 1))
                        position.y++;
                    else
                        isCollised = true;
                        return; 
                case "R":
                    if (!CheckRotateCollision(gameField) && indexOfFigure != 1)
                        body = Rotate();
                    break;
                default:
                    break;
            }
            //Gravity
            if (frame % 4 == 0)
            {
                if (CheckShiftCollision(gameField, 0, 1))
                {
                    isCollised = true;
                    return;
                }
                position.y++;
            }
        }
        private bool CheckShiftCollision(GameField gameField, int dx, int dy)
        {
            for (int i = 0; i < body.Length; i++)
            {
                if (body[i].y + position.y + dy == gameField.GetHeight() ||
                    body[i].x + position.x + dx > gameField.GetWidth()-1 ||
                    body[i].x + position.x + dx < 0)
                {
                    return true;
                }
                if (gameField.GetGameField()[body[i].y + position.y + dy, body[i].x + position.x] == Constans.BlockChar ||
                    gameField.GetGameField()[body[i].y + position.y, body[i].x + position.x + dx] == Constans.BlockChar)
                { 
                    return true;
                }
            }
            return false;
        }
        private bool CheckRotateCollision(GameField gameField)
        {
            Position[] rotateBody = Rotate();
            for (int i = 0; i < body.Length; i++)
            {
                if (rotateBody[i].x + position.y == gameField.GetHeight() ||
                    rotateBody[i].x + position.x> gameField.GetWidth() - 1 ||
                    rotateBody[i].x + position.x< 0)
                {
                    return true;
                }
                if (gameField.GetGameField()[body[i].y + position.y, rotateBody[i].x + position.x] == Constans.BlockChar ||
                    gameField.GetGameField()[body[i].y + position.y, rotateBody[i].x + position.x] == Constans.BlockChar)
                {
                    return true;
                }
            }
            return false;
        }
        private Position[] Rotate()
        {
            Position[] rotateBody = new Position[4];
            for (int i = 0; i < body.Length; i++)
            {
                rotateBody[i].y = body[i].x;
                rotateBody[i].x = -body[i].y;
            }

            return rotateBody;
        }

        public bool GetCollesed() => isCollised;
        public Position[] GetFigure()
        {
            Position[] bodyToCoordintes = new Position[4];

            for (int i = 0; i<body.Length; i++)            
                bodyToCoordintes[i] = body[i] + position;
            
            return bodyToCoordintes;
        }

    }
}
