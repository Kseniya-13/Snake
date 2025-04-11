using System.Security.Cryptography.X509Certificates;

namespace Snake
{
    internal class Program
    {
        public const int _fieldHight = 10;
        public const int _fieldWidth = 10;

        public static bool _isGameRunning = true;
        public static TypeFieldPoints[,] _field = new TypeFieldPoints[_fieldHight - 1, _fieldWidth - 1];
        public static Snake _snake = new Snake(TypeOfDerections.Right, _fieldWidth / 2, _fieldHight / 2);
        static void Main(string[] args)
        {
            _field[_snake.Body[0].X, _snake.Body[0].Y] = TypeFieldPoints.Snake;
            _snake.Body.Add(_snake.Body[0]);

            Food food = new Food(_fieldHight, _fieldWidth);
            food.Create(_fieldWidth, _fieldHight);
            
            if(_snake.Body[0] != food.Position)
            {
                _field[food.Position.X, food.Position.Y] = TypeFieldPoints.Food;
            }

            PrintField();

            do
            {
                _field[_snake.Body[0].X, _snake.Body[0].Y] = TypeFieldPoints.Empty;
                _snake.Move();
                _isGameRunning = CheckCollision();
                if(!_isGameRunning)
                {
                    Console.WriteLine();
                    Console.WriteLine("Вы проиграли :(");
                    Thread.Sleep(1000);
                    Environment.Exit(0);
                }

                _field[_snake.Body[0].X, _snake.Body[0].Y] = TypeFieldPoints.Snake;

                PrintField();
                Thread.Sleep(1000);
            } while (_isGameRunning);
        } 

        public static void PrintField()
        {
            Console.Clear();

            for (int i = 0; i < _fieldWidth; i ++)
            {
                Console.Write(" - ");
            }

            Console.WriteLine();

            for(int i = 0; i < _fieldHight; i++)
            {
                Console.Write("|");
                for (int j = 0; j  < _fieldWidth; j++)
                {
                    switch(_field[j, i])
                    {
                        case TypeFieldPoints.Empty:
                            Console.Write("  ");
                            break;

                        case TypeFieldPoints.Food:
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.Write(" ");
                           
                            break;

                        case TypeFieldPoints.Snake:
                            Console.Write(" ");
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write(" ");
                            break;

                        default:
                            Environment.Exit(0);
                            break;
                    }

                    Console.ResetColor();
                    Console.Write(" ");
                }
                Console.WriteLine("|");
            }

            for (int i = 0; i < _fieldWidth; i++)
            {
                Console.Write(" - ");
            }
        }

        public static bool CheckCollision()
        {
            if (_snake.Body[0].X < 0 || _snake.Body[0].Y < 0 || _snake.Body[0].X >= _fieldWidth || _snake.Body[0].Y >= _fieldHight)
            {
                return false;
            }

            if (_snake.Body[0] == _snake.Body.Last())
            {
                return false;
            }

            return true;
        }

        public enum TypeFieldPoints
        {
            Empty = 0,
            Food = 1,
            Snake = 2
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