using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Data
{
    public class Ball : INotifyPropertyChanged
    {
        private Vector2 _position;
        private int _radius;
        private Vector2 _velocity;
        private float _speed;
        private float _radious;
        private float _mass;


        public Ball(float speed, float radious, float mass)
        {
            _radious = radious;
            _mass = mass;
            _speed = speed;
        }

        public Ball(Vector2 position, int radius)
        {
            _position = position;
            _radius = radius;
        }


        public Vector2 Position
        {
            get => _position;
            set => _position = value;
        }

        public Vector2 Velocity
        {
            get => _velocity;
            set => _velocity = value;

        }

        public float Speed
        {
            get => _speed; set => _speed = value;
        }

        public float Radious
        {
            get => _radious;
            set => _radious = value;
        }

        public float Mass
        {
            get => _mass;
            set => _mass = value;
        }

        public float X
        {
            get { return _position.X; }
            set => _position.X = value;
        }
        public float Y
        {
            get { return _position.Y; }
            set => _position.Y = value;
        }

        public int Radius 
        {
            get { return _radius; }
            set { _radius = value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private readonly object _lockObj = new object();

        public async Task ChangePosition()//ma być prywatny i ma być definiowany wątek dla każej bili
        {
            Position += new Vector2(_velocity.X * _speed, _velocity.Y * _speed);
            if (_position.X + 5 <= 0)
            {
                _velocity = new Vector2(-_velocity.X, _velocity.Y);
                X += 4 * _velocity.X * _speed;
            }
            if (_position.X >= Board._boardWidth - _radius)
            {
                _velocity = new Vector2(-Velocity.X, Velocity.Y);
                X += 4 * _velocity.X * _speed;
            }
            if (_position.Y + 5 <= 0)
            {
                _velocity = new Vector2(Velocity.X, -Velocity.Y);
                Y += 4 * _velocity.Y * _speed;
            }
            if (_position.Y >= Board._boardHeight - _radius)
            {
                _velocity = new Vector2(Velocity.X, -Velocity.Y);
                Y += 4 * _velocity.Y * _speed;
            }

            lock (_lockObj)
            {
                RaisePropertyChanged(nameof(X));
                RaisePropertyChanged(nameof(Y));
            }

            await Task.Delay(4);
        }
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }//wywolujemy wszystkie metody ktore zostały do tej zmiennej podstawione;
             //parametry zgodne z tym;
             //
        }

    }
   
}