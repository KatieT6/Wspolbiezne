using System.Runtime.CompilerServices;

namespace Data
{
    public abstract class AbstractDataAPI
    {

        private readonly Board board;

        public Board Board { get => board; }


        public static AbstractDataAPI createDataAPI()
        {
            return new DataAPI();
        }

        public AbstractDataAPI(double width = 480.0, double height = 300.0)
        {
            board = new Board(width, height);
        }

        public abstract Ball createBall();

        internal class DataAPI : AbstractDataAPI
        {
            private readonly Random random = new Random();
            public DataAPI(double width = 480.0, double height = 300.0)
                : base(width, height) { }

            public override Ball createBall()
            {
                double r = 15.0;
                double x = r + random.NextDouble() * (board.Width - 2 * r);
                double y = r + random.NextDouble() * (board.Height - 2 * r);
                bool f = true;

                do
                {
                    f = true;

                    foreach (Ball b1 in board.Balls)
                    {
                        double dx = x - b1.PositionX;
                        double dy = y - b1.PositionY;
                        double distance = Math.Sqrt(dx * dx + dy * dy);
                        if (distance <= (r + b1.Radius))
                        {
                            f = false;
                            x = r + random.NextDouble() * (board.Width - 2 * r);
                            y = r + random.NextDouble() * (board.Height - 2 * r);
                            break;
                        }
                    }
                } while (!f);

                Ball b = new Ball(x, y, r);
                board.addBall(b);
                return b;
            }
        }
    }
}