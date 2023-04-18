using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Logic;


namespace PresentationModel
{
    public class Model
    {
        private readonly AbstractLogicAPI logicAPI;
        private ObservableCollection<BallAdapter> observableBallCollection = new ObservableCollection<BallAdapter>();
        public ObservableCollection<BallAdapter> ObservableBallCollection
        {
            get => observableBallCollection;
            set => observableBallCollection = value;
        }

        public Model(AbstractLogicAPI logicAPI = null)
        {
            this.logicAPI = logicAPI ?? AbstractLogicAPI.createLogicAPI();
        }

        public void start()
        {
            logicAPI.start();
            foreach (BallWrapper b in logicAPI.GetBalls())
            {
                ObservableBallCollection.Add(new BallAdapter(b));
            }
        }

        public void createBalls(int numberOfBalls)
        {
            logicAPI.createBalls(numberOfBalls);
        }

        public void stop()
        {
            logicAPI.stop();
        }

        public void addBall()
        {
            logicAPI.createBall();
            observableBallCollection.Add(new BallAdapter(logicAPI.GetBalls()[logicAPI.GetBalls().Count - 1]));
        }

        public void removeBall()
        {
            //logicAPI.deleteBall();
            observableBallCollection.RemoveAt(observableBallCollection.Count - 1);
        }
    }
}
