using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingBalloons
{
    public class Circle
    {
        private int size;
        private Point position;
        private Point direction;

        public Circle(int size, Point position, Point direction)
        {
            this.Size = size;
            this.Position = position;
            this.Direction = direction;
        }

        public int Size { get => size; private set => size = value; }
        public Point Position { get => position; private set => position = value; }
        public Point Direction { get => direction; private set => direction = value; }

        internal void Move()
        {
            this.position = new Point(this.position.X + this.direction.X,
                                      this.position.Y + this.direction.Y );
        }
    }
}
