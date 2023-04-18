using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    internal class Ball : INotifyPropertyChanged
    {
        private double x;
        private double y;
        private readonly double r;
        private double m = 4;

        public event PropertyChangedEventHandler? PropertyChanged;
        public Ball(double x, double y, double r, double m)
        {
            this.x = x;
            this.y = y;
            this.r = r;
            this.m = m;
        }
        public double Mass { get => m; }
        public double Radius { get => r; }

        public double X
        {
            get => x;
            set
            {
                x = value;
                RaisePropertyChanged();
            }
        }

        public double Y
        {
            get => y;
            set
            {
                y = value;
                RaisePropertyChanged();
            }
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void update(double newX, double newY)
        {
            X += newX;
            Y += newY;
        }
    }
}
