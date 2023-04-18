using Logic;
using System.Reactive.Linq;
using System.Reactive;
using System.CodeDom.Compiler;
using Data;

namespace PresentationModel
{
    public class ChanedEventBallArgs : EventArgs
    {
        public InterfaceBall Ball { get; internal set; }
    }

    public abstract class AbstractModelAPI : IObservable<InterfaceBall>, IDisposable
    {
        private readonly AbstractDataAPI _dataAPI;
        public static AbstractLogicAPI createLogicAPI(AbstractDataAPI dataAPI = null)
        {
            return new LogicAPI(dataAPI);
        }

        public abstract void CreateScene(int ballQuantity, int ballRadious);

        public abstract IDisposable Subscribe(IObserver<InterfaceBall> observer);
        public abstract void Enable();
        public abstract void Dispose();

        
    }
}