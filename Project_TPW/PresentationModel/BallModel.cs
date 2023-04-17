using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PresentationModel
{
    internal class BallModel : InterfaceBall, IDisposable
    {
        private double x;
        private double y;
        private double radius;

        private Timer MoveTimer;
        private Random Random = new Random();

        public event PropertyChangedEventHandler? PropertyChanged;


        public double X 
        {
            get { return x; }
            private set
            {
                if (x == value)
                {
                    return;
                }
                x = value;
                OnPropertyChanged();
                
            }
        }

        public double Y
        {
            get { return y; }
            private set
            {
                if (y == value)
                {
                    return;
                }
                y = value;
                OnPropertyChanged();
            }
        }

        public double Radius { get; internal set; }

        private void Move(object state)
        {
            if (state != null)
                throw new ArgumentOutOfRangeException(nameof(state));
            Y = Y + (Random.NextDouble() - 0.5) * 10;
            X = X + (Random.NextDouble() - 0.5) * 10;
        }

        public BallModel(double xvalue, double yvalue)
        {
            x = xvalue;
            y = yvalue;
            MoveTimer = new Timer(Move, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(100));
        }

        public void Dispose()
        {
            MoveTimer.Dispose();
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
