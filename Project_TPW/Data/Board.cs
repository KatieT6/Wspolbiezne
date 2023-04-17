using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Board
    {
        private readonly double width;
        private readonly double height;

        public double Width { get => width; }

        public double Height { get => height; }

        private List<Ball> balls;
        public List<Ball> Balls { get => balls; }


        public Board(double sizeX, double sizeY)
        {
            this.width = sizeX;
            this.height = sizeY;
            balls = new List<Ball>();
        }

        public void addBall(Ball b)
        {
            balls.Add(b);
        }
    }
}
