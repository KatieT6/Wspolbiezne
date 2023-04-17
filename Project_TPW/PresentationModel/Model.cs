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
        private readonly AbstractLogicAPI logicAPI;
        private IDisposable subscriber;

        public event EventHandler<ChanedEventBallArgs> BallChanged;

        public Model()
        {
            eventObservable = Observable.FromEventPattern<ChanedEventBallArgs>(this, "Ball has changed");
        }

        

        public override void CreateScene(int quantity, int radious)
        {
            throw new NotImplementedException();
        }

        public override void Enable()
        {
            throw new NotImplementedException();
        }

        public override IDisposable Subscribe(IObserver<InterfaceBall> observer)
        {
            throw new NotImplementedException();
        }

        public override void Dispose()
        {
            foreach (ModelBall item in Balls2Dispose)
                item.Dispose()        }
    }
}
