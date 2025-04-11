using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Food
    {
        public Point Position { get; set; } = new Point();
        public ConsoleColor Color { get; set; }
        public int Cost {  get; set; }

        Dictionary<int, ConsoleColor> ColorsDictionary = new Dictionary<int, ConsoleColor>()
        {
            {0, ConsoleColor.Red},
            {1, ConsoleColor.Yellow},
            {2, ConsoleColor.Blue},
            {3, ConsoleColor.Magenta},
            {4, ConsoleColor.Cyan},
            {5, ConsoleColor.White},
        }

        Dictionary<ConsoleColor, int> CostByColor = new Dictionary<ConsoleColor, int>()
        {
            {ConsoleColor.Red, 1},
            {ConsoleColor.Yellow, 2},
            {ConsoleColor.Blue, 3},
            {ConsoleColor.Magenta, 4},
            {ConsoleColor.Cyan, 5},
            {ConsoleColor.White, 6}
        }

        public Food(int hight, int width)
        {
            Position = new Point();
        }

        public void Create(int width, int hight)
        {
            Random rnd = new Random();
            Position.X = rnd.Next(width);
            Position.Y = rnd.Next(hight);
            Color = ColorsDictionary.GetValueOrDefault(rnd.Next(ColorsDictionary.Count), ConsoleColor.Red);
            Cost = CostByColor.GetValueOrDefault(rnd.Next(CostByColor.Count), 1);
        }
    }
}
