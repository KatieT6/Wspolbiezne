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

        public event PropertyChangedEventHandler? PropertyChanged;

        public BallModel(double xvalue, double yvalue)
        {
            x = xvalue;
            y = yvalue;
            //MoveTimer = new Timer(Move, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(100));
        }

        public double Xaxis 
        {
            get { return x; }
            private set
            {
                x = value;
                //OnPropertyChanged("X");
            }
        }

        public double Yaxis
        {
            get { return y; }
            private set
            {
                y = value;
                //OnPropertyChanged("X");
            }
        }

        public double Radious
        {
            get { return radius; }
            private set
            {
                radius = value;
                //OnPropertyChanged("X");
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
