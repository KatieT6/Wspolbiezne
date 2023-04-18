﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class BallCharacter
    {
        private readonly string currentTimeStamp;
        private readonly Ball ball;
        private int id;

        public string Timestamp { get => currentTimeStamp; }
        public int Id { get => id; }
        public double X { get => ball.X; }
        public double Y { get => ball.Y; }

        public BallCharacter(int id, Ball b)
        {
            ball = b;
            currentTimeStamp = DateTime.Now.ToString();
            this.id = id;
        }
    }
}
