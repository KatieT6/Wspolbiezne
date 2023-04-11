using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class Orb : INotifyPropertyChanged
    {
        private double x;
        private double y;
        private double radius;
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
