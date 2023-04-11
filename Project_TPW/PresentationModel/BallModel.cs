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

        private Random random;

        public event PropertyChangedEventHandler? PropertyChanged;

        public BallModel(double xvalue, double yvalue)
        {
            x = xvalue;
            y = yvalue;
            //MoveTimer = new Timer(Move, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(100));
        }

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

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
