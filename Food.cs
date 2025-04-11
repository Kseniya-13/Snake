namespace Snake
{
    internal class Food
    {
        public Point Position { get; set; } = new Point();
        public Fruit fruit { get; set; }

        Dictionary<int, Fruit> FruitDictionary = new Dictionary<int, Fruit>()
        {
            {0, new Fruit(ConsoleColor.Red, 1, "Клубника")},
            {1, new Fruit (ConsoleColor.Yellow, 2, "Банан")},
            {2, new Fruit (ConsoleColor.Blue, 3, "Капуста")},
            {3, new Fruit (ConsoleColor.Magenta, 4, "Баклажан")},
            {4, new Fruit (ConsoleColor.Cyan, 5, "Виноград")},
            {5, new Fruit (ConsoleColor.White, 6, "Кабачок")}
        };

        public Food()
        {
            Position = new Point();
        }

        public void Create()
        {
            Random rnd = new Random();
            Position.X = rnd.Next(Field.Width);
            Position.Y = rnd.Next(Field.Height);
            fruit = FruitDictionary.GetValueOrDefault(rnd.Next(FruitDictionary.Count), new Fruit(ConsoleColor.Red, 1, "Клубника"));
        }

        public void Print()
        {
            Field.PrintCell(Position, fruit.Color);
        }
    }
}
