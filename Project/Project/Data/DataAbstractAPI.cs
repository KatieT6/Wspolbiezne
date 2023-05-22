
using System.Collections.ObjectModel;
using System.Numerics;

namespace Data
{
    public abstract class DataAbstractAPI
    {
        public static DataAbstractAPI CreateDataAPI()
        {
            return new DataLayer();
        }

        public virtual Ball GetBallData(Vector2 position, Vector2 velocity, float radius, float weight)
        {
            return new Ball(position, velocity, radius, weight);
        }

        public virtual Board GetBoardData(int width, int height)
        {
            return new Board(width, height);
        }
    }
    public class DataLayer : DataAbstractAPI
    {




        public DataLayer()
        {
            
        }

       /* public override Ball GetBallData(Vector2 position, Vector2 velocity, float radious, float mass)
        {
            return new Ball(position, velocity, radious, mass);
        }

        public override Board GetBoardData(int width, int height)
        {
            return new Board(width, height);
        }*/
    }
}