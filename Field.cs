namespace Snake
{
    internal class Field
    {
        public const int Width = 12;
        public const int Height = 8;
        private static ConsoleColor _backgroundColor = ConsoleColor.Black;

        public static void PrintBackGround()
        {
            Console.Write("+");
            for (int i = 0; i < Width; i++)
            {
                Console.Write(" --");
            }
            Console.Write(" +");

            Console.WriteLine();

            for (int i = 0; i < Height; i++)
            {
                Console.Write("| ");

                for (int j = 0; j < Width; j++)
                {
                    Console.BackgroundColor = _backgroundColor;
                    Console.Write("  ");
                    Console.ResetColor();
                    Console.Write(" ");
                }

                Console.Write("|");

                Console.ResetColor();
                Console.WriteLine();
            }

            Console.Write("+");
            for (int i = 0; i < Width; i++)
            {
                Console.Write(" --");
            }
            Console.Write(" +");
        }

        public static void PrintCell(Point point, ConsoleColor color)
        {
            Console.CursorLeft = point.X * 3 + 2;
            Console.CursorTop = point.Y + 1;

            Console.BackgroundColor = color;
            Console.Write("  ");
            Console.ResetColor();
            Console.Write(" ");

            Console.CursorTop = Height + 3;
            Console.CursorLeft = 0;
        }

        public static void ClearCell(Point point)
        {
            PrintCell(point, _backgroundColor);
        }
    }
}
