using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Fruit
    {
        public ConsoleColor Color { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }

        public Fruit(ConsoleColor color, int price, string name)
        {
            Color = color;
            Price = price;
            Name = name;
        }
    }
}
