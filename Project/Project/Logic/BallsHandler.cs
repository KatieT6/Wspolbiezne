using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using Data;
using Microsoft.VisualBasic;

namespace Logic
{
    public class BallService
    {

        public static Ball CheckCollision(Ball ball, IEnumerable<Ball> ballsList)
        {
            foreach (Ball ballTwo in ballsList)
            {
                if (ReferenceEquals(ball, ballTwo))
                {
                    continue;
                }

                if (IsBallsCollides(ball, ballTwo))
                {
                    return ballTwo;
                }
            }

            return null;
        }

        private static bool IsBallsCollides(Ball ballOne, Ball ballTwo)
        {


            Vector2 centerOne = ballOne.Position + (Vector2.One * ballOne.Radious / 2) + ballOne.Valocity * (16 / 1000f);
            Vector2 centerTwo = ballTwo.Position + (Vector2.One * ballTwo.Radious / 2) + ballTwo.Valocity * (16 / 1000f);

            float distance = Vector2.Distance(centerOne, centerTwo);
            float radiusSum = (ballOne.Radious + ballTwo.Radious) / 2f;

            return distance <= radiusSum;


        }

        private static void HandleColide(Ball ballOne, Ball ballTwo)
        {


            Vector2 ballOneVelocity = ballOne.Velocity;
            Vector2 ballTwoVelocity = ballTwo.Velocity;
            Vector2 collisionNormal = Vector2.Normalize(ballTwo.Position - ballOne.Position);

            float ballOneInitialVelocityAlongNormal = Vector2.Dot(ballOneVelocity, collisionNormal);
            float ballTwoInitialVelocityAlongNormal = Vector2.Dot(ballTwoVelocity, collisionNormal);

            float ballOneInitialVelocityAlongTangent = Vector2.Dot(ballOneVelocity, GetPerpendicularVector(collisionNormal));
            float ballTwoInitialVelocityAlongTangent = Vector2.Dot(ballTwoVelocity, GetPerpendicularVector(collisionNormal));

            float ballOneFinalVelocityAlongNormal = (ballOneInitialVelocityAlongNormal * (ballOne.Mass - ballTwo.Mass) + 2 * ballTwo.Mass * ballTwoInitialVelocityAlongNormal) / (ballOne.Mass + ballTwo.Mass);
            float ballTwoFinalVelocityAlongNormal = (ballTwoInitialVelocityAlongNormal * (ballTwo.Mass - ballOne.Mass) + 2 * ballOne.Mass * ballOneInitialVelocityAlongNormal) / (ballOne.Mass + ballTwo.Mass);

            Vector2 ballOneFinalVelocity = ballOneFinalVelocityAlongNormal * collisionNormal + ballOneInitialVelocityAlongTangent * GetPerpendicularVector(collisionNormal);
            Vector2 ballTwoFinalVelocity = ballTwoFinalVelocityAlongNormal * collisionNormal + ballTwoInitialVelocityAlongTangent * GetPerpendicularVector(collisionNormal);

            ballOne.Velocity = ballOneFinalVelocity;
            ballTwo.Velocity = ballTwoFinalVelocity;

        }

        private static Vector2 GetPerpendicularVector(Vector2 vector)
        {
            return new Vector2(-vector.Y, vector.X);
        }

        public static void Collide(Ball ball, ObservableCollection<Ball> balls)
        {
            Ball colided = CheckCollision(ball, balls);
            if (colided != null)
            {
                HandleColide(colided, ball);
            }
            if (colided != null)
            {
                ball.Position += new Vector2(2 * ball.Velocity.X * ball.Speed, 2 * ball.Velocity.Y * ball.Speed);
            }


        }
    }


}