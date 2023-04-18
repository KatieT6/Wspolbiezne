using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace PresentationModel
{
    internal class Model : AbstractModelAPI
    {

        private readonly IObservable<EventPattern<ChanedEventBallArgs>> eventObservable = null;
        private  AbstractLogicAPI logicAPI;
        private IDisposable subscriber;
        private List<IDisposable> Balls2Dispose = new List<IDisposable>();

        public event EventHandler<ChanedEventBallArgs> BallChanged;

        public Model(AbstractLogicAPI logicAPI)
        {
            this.logicAPI = logicAPI ?? AbstractLogicAPI.createLogicAPI();
            eventObservable = Observable.FromEventPattern<ChanedEventBallArgs>(this, "Ball has changed");
            Subscribe(logicAPI)
        }

        

        public override void CreateScene(int quantity, int radious)
        {
            throw new NotImplementedException();
        }

        public override void Start()
        {
            logicAPI.start();
           
        }

        public override IDisposable Subscribe(IObserver<InterfaceBall> observer)
        {
            return eventObservable.Subscribe(x => observer.OnNext(x.EventArgs.Ball), ex => observer.OnError(ex), () => observer.OnCompleted());
        }

        public override void Dispose()
        {
            foreach (BallModel item in Balls2Dispose)
                item.Dispose();
                    }
    }
}
