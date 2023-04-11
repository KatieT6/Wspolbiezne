namespace PresentationModel
{
    public class ChanedEventBallArgs : EventArgs
    {
        public InterfaceBall Ball { get; internal set; }
    }

    public abstract class AbstractModelAPI : IObservable<InterfaceBall>
    {
        public static AbstractModelAPI CreateAPI()
        {
            return new PresentationModel();
        }

        public abstract void CreateScene(int quantity, int radious);

        public abstract IDisposable Subscribe(IObserver<InterfaceBall> observer);
        public abstract void Start();
        public abstract void Dispose();
    }
}