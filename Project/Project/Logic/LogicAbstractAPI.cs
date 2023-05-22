using System.Collections.ObjectModel;
using System.Numerics;
using System.Threading;
using Data;
using Microsoft.VisualBasic;

namespace Logic
{
    public abstract class LogicAbstractAPI
    {
        public static LogicAbstractAPI CreateLogicAPI()
        {
            return new LogicAPI();
        }

        public abstract BallService CreateBall(Vector2 position, int radius);
        public abstract void CreateBalls(int count);
        public abstract void DeleteBalls();
        public abstract void RunSimulation();
        public abstract void StopSimulation();
        public abstract ObservableCollection<BallService> Balls { get; }
        public abstract Board Board { get; }
    }
    internal class LogicAPI : LogicAbstractAPI
    {
        private List<Task> _tasks = new List<Task>();
        private CancellationToken _cancelToken;
        DataAbstractAPI _dataAPI;

        public override ObservableCollection<BallService> Balls { get; } = new ObservableCollection<BallService>();
        public override Board Board { get; }




        public LogicAPI()
        {
            _dataAPI = DataAbstractAPI.CreateDataAPI();
            Board = _dataAPI.GetBoardData(750, 400);
            BallService.SetBoardData(Board);
        }



        public override void RunSimulation()
        {

            _cancelToken = CancellationToken.None;

            // Add Barrier object and set initial count to number of balls
            Barrier barrier = new Barrier(Balls.Count);

            foreach (BallService ball in Balls)
            {
                Task task = Task.Run(() =>
                {
                    // Wait for all balls to start updating before continuing
                    barrier.SignalAndWait();

                    while (true)
                    {
                        Thread.Sleep(5);

                        try
                        {
                            _cancelToken.ThrowIfCancellationRequested();
                        }
                        catch (OperationCanceledException)
                        {
                            break;
                        }

                        foreach (BallService otherBall in Balls)
                        {
                            lock (Balls)
                            {
                                if (ball == otherBall) continue;
                                if (ball.CollidesWith(otherBall))
                                {
                                    ball.HandleCollision(otherBall);
                                }
                            }
                        }

                        ball.ChangePosition();
                    }
                });

                _tasks.Add(task);
            }

        }


        public override void StopSimulation()
        {
            _cancelToken = new CancellationToken(true);

            foreach (Task task in _tasks)
            {
                task.Wait();
            }

            _tasks.Clear();
            Balls.Clear();
        }

        #region generateRandom

        public static float GenerateRandomFloatInRange(Random random, float minValue, float maxValue)
        {
            return (float)(random.NextDouble() * (maxValue - minValue) + minValue);
        }

        public static Vector2 GenerateRandomVector2InRange(Random random, float minValue1, float maxValue1,
            float minValue2, float maxValue2)
        {
            return (Vector2)(new Vector2(GenerateRandomFloatInRange(random, minValue1, maxValue1),
                GenerateRandomFloatInRange(random, minValue2, maxValue2)));
        }

        #endregion

        public override BallService CreateBall(Vector2 position, int radius)
        {
            Ball ball = _dataAPI.GetBallData(position, new Vector2((float)0.0034, (float)0.0034), radius, radius / 2);
            BallService ballLogic = new BallService(ball);
            Balls.Add(ballLogic);

            return ballLogic;
        }

        public override void CreateBalls(int count)
        {
            var rnd = new Random((int)DateTime.Now.Ticks);

            for (int i = 0; i < count; i++)
            {
                float speed = 0.0005f;
                float radius = GenerateRandomFloatInRange(rnd, 10f, 30f);
                Vector2 pos = GenerateRandomVector2InRange(rnd, 0, Board.Width - radius, 0, Board.Height - radius);
                Vector2 vel = GenerateRandomVector2InRange(rnd, -speed, speed, -speed, speed);
                Ball ballData = _dataAPI.GetBallData(pos, vel, radius, radius / 2);
                BallService ballLogic = new BallService(ballData);
                Balls.Add(ballLogic);
            }
        }

        public override void DeleteBalls()
        {
            Balls.Clear();
        }

    }
}