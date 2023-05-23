using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using Data;
using Microsoft.VisualBasic;

namespace Logic
{
    public class BallService : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private readonly BallData _ball;
        //private static BoardData _board;

        public BallService(BallData ball)
        {
            _ball = ball;
        }

        /*public static void SetBoardData(BoardData board)
        {
            _board = board;
        }*/

        public float X => _ball.Position.X;
        public float Y => _ball.Position.Y;
        public float Radius => _ball.Radius;
        public float Mass => _ball.Mass;

        public Vector2 Velocity
        {
            get => _ball.Velocity;
            set
            {
                _ball.Velocity = value;
                RaisePropertyChanged(nameof(Velocity));
            }
        }

        public ObservableCollection<BallService> Balls { get; } = new ObservableCollection<BallService>();

        public bool CollidesWith(BallService other)
        {
            Vector2 distance = new Vector2(X, Y) - new Vector2(other.X, other.Y);
            float sumRadii = Radius + other.Radius;
            return distance.LengthSquared() <= sumRadii * sumRadii;
        }

        public void HandleCollision(BallService other)
        {
            Vector2 collisionNormal = Vector2.Normalize(new Vector2(other.X, other.Y) - new Vector2(X, Y));
            Vector2 relativeVelocity = other.Velocity - Velocity;
            float impulseMagnitude = 2 * Mass * other.Mass * Vector2.Dot(relativeVelocity, collisionNormal) / (Mass + other.Mass);

            other.Velocity -= impulseMagnitude / other.Mass * collisionNormal;
            Velocity += impulseMagnitude / Mass * collisionNormal;
        }

        public void UpdatePosition()
        {
            _ball.UpdatePosition();

            RaisePropertyChanged(nameof(X), nameof(Y));

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
        }


    }


}