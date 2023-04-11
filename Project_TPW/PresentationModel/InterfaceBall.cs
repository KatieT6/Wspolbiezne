using System;
using System.ComponentModel;

namespace PresentationModel
{
    public interface InterfaceBall : INotifyPropertyChanged
    {
        double X { get; }
        double Y { get; }
        double Radius { get; }
    }
}
