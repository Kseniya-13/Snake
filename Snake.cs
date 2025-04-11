using static Snake.Program;

namespace Snake
{
    internal class Snake
    {
        public List<Point> Body { get; set; }
        public int Counter { get; set; } = 0;
        public TypeOfDerections Direction { get; set; }
        private const ConsoleColor headColor = ConsoleColor.DarkGreen;
        private const ConsoleColor bodyColor = ConsoleColor.Green;
        public int Speed { get; set; }

        public Snake(TypeOfDerections direction, int x, int y)
        {
            Direction = direction;

            Speed = 1;

            Point head = new Point(x, y);

            Body = new List<Point>
            {
                head
            };

            Field.PrintCell(head, headColor);
        }

        public void Move()
        {
            Point head = GetNextPosition();
            Field.PrintCell(head, headColor);
            Field.PrintCell(Body[0], bodyColor);
            Field.ClearCell(Body[Body.Count - 1]);

            Body.Insert(0, head);
            Body.RemoveAt(Body.Count - 1);
        }

        public void Eat(int foodPrice)
        {
            Speed++;
            Point head = GetNextPosition();
            Counter += foodPrice;
            Field.PrintCell(head, headColor);
            Field.PrintCell(Body[0], bodyColor);

            Body.Insert(0, GetNextPosition());
        }

        public Point GetNextPosition()
        {
            switch (Direction)
            {
                case TypeOfDerections.Up:
                    return new Point(Body[0].X, Body[0].Y - 1);

                case TypeOfDerections.Down:
                    return new Point(Body[0].X, Body[0].Y + 1);

                case TypeOfDerections.Left:
                    return new Point(Body[0].X - 1, Body[0].Y);

                case TypeOfDerections.Right:
                    return new Point(Body[0].X + 1, Body[0].Y);

                default:
                    return new Point(Body[0].X, Body[0].Y);
            }
        }
    }
}
