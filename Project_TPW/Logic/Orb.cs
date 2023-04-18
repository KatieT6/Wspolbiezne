using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Orb : INotifyPropertyChanged
    {
        private bool moved = false;
        private bool active;

        private readonly Ball ball;
        private double velocityX;
        private double velocityY;

        private double positionX;
        private double positionY;

        private double radius;

        public Orb(bool active, Ball ball, double velocityX, double velocityY,  bool moved)
        {
            this.active = active;
            ball.PropertyChanged += RaisedPropertyChanged;
            this.ball = ball;
            VelocityX = velocityX;
            VelocityY = velocityY;
            positionX = ball.PositionX;
            positionY = ball.PositionY;

            radius = ball.Radius;
            Moved = moved;
        }

        public double Radius { get => radius; }
        public bool Active { get => active; }

        public double PositionX
        {
            get => positionX;
            set
            {
                positionX = value;
                OnPropertyChanged();
            }
        }

        public double PositionY
        {
            get => positionY;
            set
            {
                positionY = value;
                OnPropertyChanged();
            }
        }

        public double VelocityX
        {
            get => velocityX;
            set => velocityX = value;
        }

        public double VelocityY
        {
            get => velocityY;
            set => velocityY = value;
        }

        public bool Moved
        {
            get => moved;
            set => moved = value;
        }


        public void update()
        {
            ball.updateBall(velocityX, velocityY);
        }

        public void start()
        {
            active = true;
        }

        public void stop()
        {
            active = false;
        }

        private void RaisedPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Ball b = (Ball)sender;
            switch (e.PropertyName)
            {
                case "PositionX":
                    PositionX = b.PositionX;
                    break;
                case "PositionY":
                    PositionY = b.PositionY;
                    break;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
