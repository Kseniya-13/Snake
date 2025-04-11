using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Snake.Program;

namespace Snake
{
    internal class Snake
    {
        public List<Point> Body { get; set; }
        public TypeOfDerections Direction { get; set; }

        public Snake(TypeOfDerections direction, int x, int y)
        {
            Direction = direction;
            Body = new List<Point>
            {
                new Point(x, y)
            };
        }

        public void Move()
        {
            Body.Insert(0, GetNextPosition());

            Body.RemoveAt(Body.Count - 1);
        }

        public void Eat()
        {
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

        public bool CheckCollision()
        {
            if (Body[0].X < 0 || Body[0].Y < 0 || Body[0].X >= _fieldWidth || Body[0].Y >= _fieldHight)
            {
                return true;
            }

            for (int i = 1; i < Body.Count; i++)
            {
                if (_snake.Body[0].Equals(Body[0]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
