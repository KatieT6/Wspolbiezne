using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class AbstractLogicAPI
    {
        private readonly AbstractDataAPI dataAPI;


        public AbstractLogicAPI(AbstractDataAPI dataAPI = null)
        {
            this.dataAPI = dataAPI ?? AbstractDataAPI.createDataAPI();
        }

        public static AbstractLogicAPI createLogicAPI(AbstractDataAPI dataAPI = null)
        {
            return new LogicAPI(dataAPI);
        }

        public abstract List<Orb> GetBalls();

        public abstract void createBall();
        public abstract void createBalls(int count);

        public abstract void start();
        public abstract void stop();

        private class LogicAPI : AbstractLogicAPI
        {
            private readonly Random random = new Random();
            private bool Running = false;
            private List<Orb> balls = new List<Orb>();

            private double width;
            private double height;
            public LogicAPI(AbstractDataAPI abstractDataAPI = null)
                : base(abstractDataAPI)
            {
                width = dataAPI.Board.Width;
                height = dataAPI.Board.Height;
            }


            public AbstractLogicAPI AbstractDataApi { get; }

            public override void createBall()
            {
                throw new NotImplementedException();
            }

            public override void createBalls(int count)
            {
                throw new NotImplementedException();
            }

            public override List<Orb> GetBalls()
            {
                throw new NotImplementedException();
            }

            public override void start()
            {
                throw new NotImplementedException();
            }

            public override void stop()
            {
                throw new NotImplementedException();
            }
        }

    }
}
