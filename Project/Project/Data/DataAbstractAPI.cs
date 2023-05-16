
using System.Collections.ObjectModel;

namespace Data
{
    public abstract class DataAbstractAPI
    {
        public static DataAbstractAPI CreateDataAPI(float radious, float mass, float v)
        {
            return new DataLayer(radious, mass, v);
        }

<<<<<<< HEAD
=======

>>>>>>> 1837e2eabe93ff200666d200c17dfabddec8b8d1
        public abstract void generateBalls(int _amount);
        public abstract ObservableCollection<Ball> getBalls();

    }
    public class DataLayer : DataAbstractAPI
    {
        private float _ballradious;
        private float _ballmass;
        private float _v;
        private Board board;


        public DataLayer(float radious, float mass, float v)
        {

            this._ballradious = radious;
            this._ballmass = mass;
            this._v = v;
            board = new Board();
        }

        public override void generateBalls(int _amount)
        {
            board.GenerateBalls(_amount, _ballradious, _ballmass, _v);
        }

        public override ObservableCollection<Ball> getBalls()
        {
            return board.Balls;
        }
    }
}