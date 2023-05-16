using System.Collections.ObjectModel;
using System.Numerics;

namespace Data
{
    internal class Board 
    {
        public static int _boardWidth = 750;
        public static int _boardHeight = 400;
        //private CancellationToken _cancelToken;
       /* private List<Task> _tasks = new List<Task>();
        private List<Thread> _threads = new List<Thread>();*/
        public ObservableCollection<Ball> _balls = new();

        public Board()
        {
           
        }

        public int BoardHeight
        {
            get => _boardHeight;
        }
        public int BoardWidth
        {
            get => _boardWidth;
        }
        public ObservableCollection<Ball> Balls
        {
            get => _balls;
        }
        public void GenerateBalls(int amount, float radious, float mass, float v)
        {
            Random random = new Random();
            for (int i = 0; i < amount; i++)
            {
                float rnd = random.Next(7, 30);
                Ball ball = new(v, rnd, (float)(rnd * 0.3))
                {
                    Position = new System.Numerics.Vector2(random.Next(0, (int)(BoardWidth - rnd)), random.Next(0, (int)(BoardHeight - rnd))),
                    Velocity = new System.Numerics.Vector2((float)0.003, (float)0.003)
                };
                _balls.Add(ball);
            }

        }
    }
}
