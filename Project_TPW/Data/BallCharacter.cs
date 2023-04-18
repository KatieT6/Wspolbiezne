using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class BallCharacter
    {
        private readonly string T;
        private readonly Ball ball;
        private int id;

        public string Time { get => T; }
        public int Id { get => id; }
        public double X { get => ball.X; }
        public double Y { get => ball.Y; }

        public BallCharacter(int id, Ball newB)
        {
            this.id = id;
            T = DateTime.Now.ToString();
            ball = newB;
            
            
        }
    }
}
