
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

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======

>>>>>>> 1837e2eabe93ff200666d200c17dfabddec8b8d1
        public abstract void generateBalls(int _amount);
        public abstract ObservableCollection<Ball> getBalls();

=======
        public virtual Ball GetBallData(Vector2 position, Vector2 velocity, float radius, float weight)
        {
            return new Ball(position, velocity, radius, weight);
        }

=======
        public virtual Ball GetBallData(Vector2 position, Vector2 velocity, float radius, float weight)
        {
            return new Ball(position, velocity, radius, weight);
        }

>>>>>>> 0b804d85db8e0efae133ece25bf13c7571717499
        public virtual Board GetBoardData(int width, int height)
        {
            return new Board(width, height);
        }
<<<<<<< HEAD
>>>>>>> 6d106460ff17b0e47a0b485241eb1c4a056a0cc2
=======
>>>>>>> 0b804d85db8e0efae133ece25bf13c7571717499
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