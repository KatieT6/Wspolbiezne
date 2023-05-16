using Data;
using System.Collections.ObjectModel;
using System.Numerics;

namespace Logic
{
    public abstract class LogicAbstractAPI
    {
        public static LogicAbstractAPI CreateLogicAPI(DataAbstractAPI dataAPI = default(DataAbstractAPI))
        {
            return new LogicAPI(dataAPI);
        }


        public abstract int Width { get; }
        public abstract int Height { get; }
        public abstract ObservableCollection<Ball> Balls { get; }
        public abstract void RunSimulation();
        public abstract void StopSimulation();
        public abstract void GenerateBalls(int _amount);
        public abstract ObservableCollection<Ball> getBalls();
    }



    public class LogicAPI : LogicAbstractAPI
    {
        private List<Task> _tasks = new List<Task>();
        private CancellationToken _cancelToken;
        private readonly DataAbstractAPI DataLayer;
        private bool isCancelled = false;

        public LogicAPI(DataAbstractAPI dataAPI)
        {
            this.DataLayer = dataAPI ?? DataAbstractAPI.CreateDataAPI();
        }
        public CancellationToken CancellationToken => _cancelToken;

        public override int Width => throw new NotImplementedException();

        public override int Height => throw new NotImplementedException();

        public override ObservableCollection<Ball> Balls => throw new NotImplementedException();

        public override ObservableCollection<Ball> getBalls()
        {
            return DataLayer.getBalls();
        }

        public override void RunSimulation()
        {
            isCancelled = false;
            if (DataLayer.getBalls().Count == 0)
            {
                throw new ArgumentNullException("Nie ma kuleczek :(");
            }
            foreach (var ball in DataLayer.getBalls())
            {
                Task task = new Task(async () =>
                {

                    while (!isCancelled)
                    {
                        await ball.ChangePosition();
                        lock (DataLayer)
                        {
                            BallsHandler.Collide(ball, DataLayer.getBalls());
                        }
                    }
                });
                task.Start();
                _tasks.Add(task);
            }
        }

        public override void StopSimulation()
        {
            isCancelled = true;
            DataLayer.getBalls().Clear();

            _tasks.Clear();
        }

        public override void GenerateBalls(int _amount)
        {
            DataLayer.generateBalls(_amount);
        }
    }
}
