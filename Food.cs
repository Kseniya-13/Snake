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

        public Food(int hight, int width)
        {
            Position = new Point();
        }

        public void Create(int width, int hight)
        {
            Random rnd = new Random();
            Position.X = rnd.Next(width);
            Position.Y = rnd.Next(hight);
        }
    }
}
