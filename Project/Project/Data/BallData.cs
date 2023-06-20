using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Data
{
    internal class BallData : BallInterface
    {
        private Task task;
        private bool move = true;
        private int diameter;
        private Stopwatch stopWatch;
        private int mass;

        public BallData(float x, float y, int m, Vector2 vel, int diam, int id)
        {
            stopWatch = new Stopwatch();
            Id = id;
            position = new Vector2(x, y);
            velocity = vel;
            diameter = diam;
            mass = m;
            task = Task.Run(Move);
        }

        public event EventHandler? BallChanged;

        

        // Position
        
        private Vector2 position;

        public Vector2 Position
        {
            get => position;

            set
            {
                position = value;
            }
        }

        // Velocity

        private Vector2 velocity;

        public Vector2 Velocity
        {
            get => velocity;
            set
            {

                velocity = value;

            }
        }

        // Diameter

        public int Diameter
        {
            get => diameter;
        }

        // Mass
        public int Mass
        {
            get => mass;
            private set { mass = value; }
        }

        // Id

        public int Id { get; }

       

        // Poruszanie sie kulki

        private async void Move()
        {
            float time;

            while (move)
            {
                stopWatch.Restart();
                stopWatch.Start();
                time = (2 / velocity.Length());
                Update(time);

                stopWatch.Stop();
                await Task.Delay(time - stopWatch.ElapsedMilliseconds < 0 ? 0 : (int)(time - stopWatch.ElapsedMilliseconds));
            }

        }

        // Odswiezanie pozycji kulki

        private void Update(float time)
        {
            Position += velocity * time;
            BallChanged?.Invoke(this, EventArgs.Empty);
        }

        public void Dispose()
        {
            move = false;
            task.Wait();
            task.Dispose();
        }

    }

}