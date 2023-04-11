using System;
using System.ComponentModel;

namespace PresentationModel
{
    public interface InterfaceBall : INotifyPropertyChanged
    {
        double Xaxis { get; }
        double Yaxis { get; }
        double Radious { get; }
    }
}
