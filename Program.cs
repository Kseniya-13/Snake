using System.Security.Cryptography.X509Certificates;

namespace Snake
{
    internal class Program
    {
        public const int _fieldHight = 10;
        public const int _fieldWidth = 10;

        public static bool _isGameRunning = false;
        public static Snake _snake = new Snake(TypeOfDerections.Right, _fieldWidth / 2, _fieldHight / 2);
        public static Food _food = new Food(_fieldHight, _fieldWidth);
        static void Main(string[] args)
        {
            do
            {
                _food.Create(_fieldWidth, _fieldHight);

            } while (_food.Position.X == _snake.Body[0].X && _food.Position.Y == _snake.Body[0].Y);

            do
            {
                PrintField(_fieldHight, _fieldWidth);
                Thread.Sleep(1000);

                HandleInput();

                _snake.Move();
                Update();

                if (!_isGameRunning)
                {
                    Console.WriteLine();
                    Console.WriteLine("Вы проиграли :(");
                    Thread.Sleep(1000);
                }
            } while (_isGameRunning);
        }

        private static void PrintField(int hight, int width)
        {
            Console.Clear();

            for (int i = 0; i < _fieldWidth; i++)
            {
                Console.Write(" - ");
            }

            Console.WriteLine();

            for (int y = 0; y < hight; y++)
            {
                Console.Write("|");

                for (int x = 0; x < width; x++)
                {
                    if (y == _snake.Body[0].Y && x == _snake.Body[0].X)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                    }
                    else if (_snake.Body.Exists(p => p.X == x && p.Y == y))
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                    }
                    else if (_food.Position.X == x && _food.Position.Y == y)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                    }
                    else
                    {
                        Console.ResetColor();
                    }

                    Console.Write("  ");
                    Console.ResetColor();
                    Console.Write(" ");
                }

                Console.Write("|");

                Console.ResetColor();
                Console.WriteLine();
            }

            for (int i = 0; i < _fieldWidth; i++)
            {
                Console.Write(" - ");
            }
        }

        private static void HandleInput()
        {
            if (!Console.KeyAvailable) return;

            var key = Console.ReadKey().Key;

            if (key == ConsoleKey.UpArrow && _snake.Direction != TypeOfDerections.Down)
            {
                _snake.Direction = TypeOfDerections.Up;
            }
            else if (key == ConsoleKey.DownArrow && _snake.Direction != TypeOfDerections.Up)
            {
                _snake.Direction = TypeOfDerections.Down;
            }
            else if (key == ConsoleKey.LeftArrow && _snake.Direction != TypeOfDerections.Right)
            {
                _snake.Direction = TypeOfDerections.Left;
            }
            else if (key == ConsoleKey.RightArrow && _snake.Direction != TypeOfDerections.Left)
            {
                _snake.Direction = TypeOfDerections.Right;
            }
        }

        public static void Update()
        {
            Point nextPoint = _snake.GetNextPosition();

            if (nextPoint.Equals(_food.Position))
            {
                _snake.Eat();

                do
                {
                    _food = new Food(_fieldWidth, _fieldHight);
                } while (_snake.Body.Contains(_food.Position));
            }
            else
            {
                _snake.Move();
            }

            if (_snake.CheckCollision())
            {
                _isGameRunning = false;
            }
        }


        public enum TypeOfDerections
        {
            Down = 0,
            Up = 1,
            Left = 2,
            Right = 3
        }
    }
}