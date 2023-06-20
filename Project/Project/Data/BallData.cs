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

            private set
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

        /*public static int _boardWidth = 750;
        public static int _boardHeight = 400;*/
        /*private Vector2 _position;
        private Vector2 _velocity;
        private float _speed = 1500;
        private float _radius;
        private float _mass;
        private bool _move = true;


        public BallData(Vector2 position, Vector2 velocity, float radious, float mass)
        {
            _position = position;
            _radius = radious;
            _mass = mass;
            _velocity = velocity;
        }


        public Vector2 Position
        {
            get => _position;
            set
            {
                _position = value;
                RaisePropertyChanged();
            }
        }

        public Vector2 Velocity
        {
            get => _velocity;
            set => _velocity = value;

        }

        public float Speed
        {
            get => _speed; 
            set => _speed = value;
        }

        public float Radius
        {
            get => _radius;
            set => _radius = value;
        }

        public float Mass
        {
            get => _mass;
            set => _mass = value;
        }

        public float X
        {
            get { return _position.X; }
            private set => _position.X = value;

        }
        public float Y
        {
            get { return _position.Y; }
            private set => _position.Y = value;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private readonly object _lockObj = new object();

        private void ChangePosition()
        {
            Position += new Vector2(_velocity.X * _speed, _velocity.Y * _speed);
            if (_position.X - 5 <= 0 && + _velocity.X < 0)
            {
                _velocity = new Vector2(-Velocity.X, Velocity.Y);
                X += 4 * _velocity.X * _speed;
            }
            if (_position.X  >= DataAbstractAPI.BoardWidth - _radius*2 && _velocity.X > 0)
            {
                _velocity = new Vector2(-Velocity.X, Velocity.Y);
                X += 4 * _velocity.X * _speed;
            }
            if (_position.Y - 5 <= 0 && _velocity.Y < 0)
            {
                _velocity = new Vector2(Velocity.X, -Velocity.Y);
                Y += 4 * _velocity.Y * _speed;
            }
            if (_position.Y >= DataAbstractAPI.BoardHeight - _radius*2 && _velocity.Y > 0)
            {
                _velocity = new Vector2(Velocity.X, -Velocity.Y);
                Y += 4 * _velocity.Y * _speed;
            }


                RaisePropertyChanged(nameof(Position));


        }

        
        
        public void UpdatePosition()
        {
            ChangePosition();
        }


        protected virtual void RaisePropertyChanged(params string[] propertyNames)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                foreach (string propertyName in propertyNames)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        } */
    }

}