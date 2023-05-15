using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Logic
{
    public class Ball : INotifyPropertyChanged
    {
        private Vector2 _position;
        private int _radius;
        private Vector2 _velocity;
        private const int _speed = 1500;


        public Ball() { }

        public Ball(Vector2 ballPosition, int radius)
        {
            _position = ballPosition;
            _radius = radius;
        }
        public Vector2 Position
        {
            get => _position;
            set => _position = value;
        }

        public Vector2 Velocity { get; set; }// seter tylko potrzebny 


        public float X
        {
            get => _position.X;
        }
        public float Y
        {
            get => _position.Y;
        }

        public int Radius //to ma być w board 
        {
            get { return _radius; }
            set { _radius = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ChangePosition()//ma być prywatny i ma być definiowany wątek dla każej bili
        {
            Position += new Vector2(Velocity.X * _speed, Velocity.Y * _speed);
            if (Position.X < 0 || Position.X > Board._boardWidth - 25)
            {
                Velocity *= -Vector2.UnitX;
            }

            if (Position.Y < 0 || Position.Y > Board._boardHeight - 25)
            {
                Velocity *= -Vector2.UnitY;
            }

            //mamy informować o zmianach X i Y razem, NIE OSOBNO - zmienić na wektor zeby razem były przekazywane

            RaisePropertyChanged(nameof(X)); //są elementen porogramowania współbieżnego
            RaisePropertyChanged(nameof(Y)); //zabezpieczyć sekcją krytyczną
            //metody ktore wywołuje jedna piłka sa asynchronicznie wywoływane
            //przy zdeżeniach się przyda - sekcja krytyczna - board 
            //kolejnośc wywolan metod poszczególnych kulek nie da się przewidziać

            //jak będą wypisywane błędy to implementacja z prezentationModel nie jest odpowiednia 
        }
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));//wywolujemy wszystkie metody ktore zostały do tej zmiennej podstawione;
                                            //parametry zgodne z tym;
                                            //
        }

    }
   
}