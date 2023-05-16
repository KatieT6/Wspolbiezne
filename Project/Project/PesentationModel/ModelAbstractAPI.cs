using System;
using System.Collections.ObjectModel;
using Data;
using Logic;

namespace Presentation.Model
{
    public abstract class ModelAbstractApi
    {


        public static ModelApi CreateModelApi(DataAbstractAPI data)
        {
            return new ModelApi(data);
        }
        public abstract void CreateBall(int amount);
        public abstract void TaskRun();
        public abstract void TaskStop();
        public abstract ObservableCollection<Ball> GetBalls();


    }
    public class ModelApi : ModelAbstractApi
    {

        private DataAbstractAPI _data;
        private LogicAbstractApi logicApi;
        public ModelApi(DataAbstractAPI data)
        {
            _data = data;
            logicApi = LogicAbstractApi.CreateLogicAPI(_data);
        }


        public override void CreateBall(int amount)
        {
            _data.generateBalls(amount);
        }

        public override ObservableCollection<Ball> GetBalls()
        {
            return _data.getBalls();
        }

        public override void TaskRun()
        {
            if (_data.getBalls().Count == 0)
            {
                throw new NullReferenceException("brak pilek w model");
            }
            logicApi.TaskRun();
        }

        public override void TaskStop()
        {
            logicApi.TaskStop();
        }

    }
}