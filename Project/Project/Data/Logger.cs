using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class Logger : IDisposable
    {

        private Task loggerTask;
        private StreamWriter streamWriter;
        BlockingCollection<BallDataToSerialize> _queue;

        public Logger()
        {
            this.loggerTask = Task.Run(WriteToFile);
            _queue = new BlockingCollection<BallDataToSerialize>();
        }


        private void WriteToFile()
        {

        }

        public void AddBallToQueue(BallInterface ball)
        {
            if (ball == null)
            {
                return;
            }

            BallData ballToAdd = new BallData(ball.Position.X, ball.Position.Y, ball.Mass, ball.Velocity, ball.Diameter, ball.Id);
            
        }


        public void Dispose()
        {
            _queue.CompleteAdding();
            loggerTask.Wait();
            loggerTask.Dispose();
        }

        internal class BallDataToSerialize
        {
            public BallDataToSerialize(Vector2 Position, int mass, Vector2 Velocity, int diameter, int iD)
            {
                X = Position.X;
                Y = Position.Y;
                Mass = mass;
                VelyX = Velocity.X;
                VelY = Velocity.Y;
                Diameter = diameter;
                ID = iD;
                Time = DateTime.UtcNow.ToString("G");
            }   //Format "G" jest domyślnym formatem dla ToString() w przypadku typu DateTime
                //i wygeneruje ciąg znaków reprezentujący datę i czas w lokalnej strefie czasowej
                //w formacie akceptowalnym dla bieżącej kultury.
            //Natomiast DateTime.UtcNow zwraca aktualną datę i czas w strefie czasowej UTC
            //(czas uniwersalny skoordynowany), który jest niezależny od lokalnej strefy czasowej.

            public float X { get; set; }
            public float Y { get; set; }
            public int Mass { get; set; } 
            public float VelyX { get; set; }
            public float VelY { get; set; }
            public int Diameter { get; set; }
            public int ID { get; set; }
            public string Time { get; set; }
        }

    }
}
