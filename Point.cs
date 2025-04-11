namespace Snake
{
    internal class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Point other)
            {
                return X == other.X && Y == other.Y;
            }

            return false;
        }
    }
}
