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
        private readonly Ball _ball;
        private static Board _board;

        public BallService(Ball ball)
        {
            _ball = ball;
        }

        public static void SetBoardData(Board board)
        {
            _board = board;
        }

        public float X => _ball.Position.X;
        public float Y => _ball.Position.Y;
        public float Radious => _ball.Radious;
        public float Weight => _ball.Mass;

        public Vector2 Velocity
        {
            get => _ball.Velocity;
            set
            {
                _ball.Velocity = value;
                RaisePropertyChanged(nameof(Velocity));
            }
        }

        public bool CollidesWith(BallService other)
        {
            Vector2 distance = new Vector2(other.X, other.Y) - new Vector2(this.X, this.Y);
<<<<<<< HEAD
            float separationDistance = 2; // adjust as needed
=======
            float separationDistance = 4; // adjust as needed
>>>>>>> 0b804d85db8e0efae133ece25bf13c7571717499
            float radiiSum = (other.Radious / 2) + (this.Radious / 2) + separationDistance;

            return distance.LengthSquared() <= radiiSum * radiiSum;
        }

        public void HandleCollision(BallService other)
        {
            Vector2 collisionNormal = Vector2.Normalize(new Vector2(other.X, other.Y) - new Vector2(this.X, this.Y));
            Vector2 relativeVelocity = other.Velocity - this.Velocity;
            float impulseMagnitude = 2 * this.Weight * other.Weight * Vector2.Dot(relativeVelocity, collisionNormal) / (this.Weight + other.Weight);

            other.Velocity -= impulseMagnitude / other.Weight * collisionNormal;
            this.Velocity += impulseMagnitude / this.Weight * collisionNormal;
        }

        public void ChangePosition()
        {
            _ball.Position += new Vector2(_ball.Velocity.X * _ball.Speed, _ball.Velocity.Y * _ball.Speed);
            Vector2 normal = Vector2.Zero;

            if (_ball.Position.X < 0)
                normal = Vector2.UnitX;
            else if (_ball.Position.X > _board.Width - _ball.Radious)
                normal = -Vector2.UnitX;
            else if (_ball.Position.Y < 0)
                normal = Vector2.UnitY;
            else if (_ball.Position.Y > _board.Height - _board.Height)
                normal = -Vector2.UnitY;

            if (normal != Vector2.Zero)
                _ball.Velocity = Vector2.Reflect(_ball.Velocity, normal);

            RaisePropertyChanged(nameof(X));
            RaisePropertyChanged(nameof(Y));
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            //wywolujemy wszystkie metody ktore zostały do tej zmiennej podstawione;
            //parametry zgodne z tym;
        }

       
    }


}