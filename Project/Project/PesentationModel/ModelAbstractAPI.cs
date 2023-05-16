using Data;
using Logic;
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace PesentationModel
{
    public abstract class ModelAbstractAPI
    {
        public static ModelAbstractAPI CreateModelAPI(LogicAbstractAPI logicApi = default(LogicAbstractAPI))
        {
            return new ModelAPILayer(logicApi);
        }

        public abstract void CreateBalls(int amount);
        public abstract void CallSimulation();
        public abstract void StopSimulation();
        public abstract ObservableCollection<Ball> GetBalls(); 
    }
    internal class ModelAPILayer : ModelAbstractAPI
    {
        private readonly LogicAbstractAPI logicLayer;

        //public ModelAPILayer() : this(LogicAbstractAPI.CreateLogicAPI()) { }

        public ModelAPILayer(LogicAbstractAPI logicApi)
        {
            logicLayer = logicApi ?? LogicAbstractAPI.CreateLogicAPI();
        }

        public override void CallSimulation()
        {
            logicLayer.RunSimulation();
        }

        public override void StopSimulation()
        {
            logicLayer.StopSimulation();
        }

        public override ObservableCollection<Ball> GetBalls()
        {
            return logicLayer.getBalls();
        }

        public override void CreateBalls(int amount)
        {
            logicLayer.GenerateBalls(amount);
        }


    }
}