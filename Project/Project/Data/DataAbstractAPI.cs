
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

        public abstract Ball GetBallData(Vector2 position, Vector2 velocity, float radious, float mass);
        public abstract Board GetBoardData();

    }
    public class DataLayer : DataAbstractAPI
    {

        private Board board;


        public DataLayer()
        {
            
        }

        public override Ball GetBallData(Vector2 position, Vector2 velocity, float radious, float mass)
        {
            return new Ball(position, velocity, radious, mass);
        }

        public override Board GetBoardData()
        {
            return new Board();
        }
    }
}