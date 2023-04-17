using Logic;
using System.Reactive.Linq;
using System.Reactive;
using System.CodeDom.Compiler;

namespace PresentationModel
{
    public class ChanedEventBallArgs : EventArgs
    {
        public InterfaceBall Ball { get; internal set; }
    }

    public abstract class AbstractModelAPI : IObservable<InterfaceBall>, IDisposable
    {
        public static AbstractModelAPI CreateAPI()
        {
            return new Model();
        }

        public abstract void CreateScene(int ballQuantity, int ballRadious);

        public abstract IDisposable Subscribe(IObserver<InterfaceBall> observer);
        public abstract void Enable();
        public abstract void Dispose();

        
    }
}