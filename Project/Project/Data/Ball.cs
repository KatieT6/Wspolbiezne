using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Data
{
    public class Ball
    {
        private Vector2 _position;
        private float _radius;
        private Vector2 _velocity;
        private float _speed = 1500;
        private float _radious;
        private float _mass;


        public Ball(Vector2 position, Vector2 velocity, float radious, float mass)
        {
            _position = position;
            _radious = radious;
            _mass = mass;
            _velocity = velocity;
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
            get => _speed; 
            set => _speed = value;
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


    }
   
}