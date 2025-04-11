namespace Snake
{
    internal class Program
    {
        public static bool _isGameRunning = true;
        public static Snake _snake { get; set; }
        public static Food _food { get; set; }

        static void Main(string[] args)
        {
            Field.PrintBackGround();
            _snake = new Snake(TypeOfDerections.Right, Field.Width / 2, Field.Height / 2);
            _food = new Food();

            do
            {
                _food.Create();
            } while (_food.Position.X == _snake.Body[0].X && _food.Position.Y == _snake.Body[0].Y);

            _food.Print();

            do
            {
                Thread.Sleep(500);
                HandleInput();
                Update();
            } while (_isGameRunning);

            Console.WriteLine();
            Console.WriteLine("Вы проиграли :(");
            Thread.Sleep(1000);
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

            if (CheckCollision(nextPoint))
            {
                _isGameRunning = false;
                return;
            }

            if (nextPoint.Equals(_food.Position))
            {
                _snake.Eat(_food.fruit.Price);

                do
                {
                    _food.Create();
                } while (_snake.Body.Contains(_food.Position));

                _food.Print();
            }
            else
            {
                _snake.Move();
            }

            string spaces = new string(' ', 50);
            Console.WriteLine(spaces);
            Console.WriteLine(spaces);
            Console.ResetColor();
            Console.CursorTop = Console.CursorTop - 2;

            Console.WriteLine($"Количество баллов: {_snake.Counter}.");
            Console.WriteLine($"Текущий фрукт: {_food.fruit.Name}.");
        }

        public static bool CheckCollision(Point head)
        {
            if (head.X < 0 || head.X >= Field.Width || head.Y < 0 || head.Y >= Field.Height)
            {
                return true;
            }

            return _snake.Body.Contains(head);
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