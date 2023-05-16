using Data;
using Logic;
using PesentationModel;
using System.Collections;
using System.ComponentModel;
using System.Windows.Input;

namespace PresentationViewModel
{
    public class MyViewModel : INotifyPropertyChanged
    {

        private readonly ModelAbstractAPI modelAPI;
        private int _amountOfBalls;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public IList<Ball> _Balls { get; set; }
        Random random = new Random();

        public IList<Ball> Balls
        {
            get => _Balls;
            set
            {
                _Balls = value;
            }
        }


        public MyViewModel()
        {
            //trzeba zmienić konstruktor LogicAPI (chyba)
            modelAPI = ModelAbstractAPI.CreateModelAPI(LogicAbstractAPI.CreateLogicAPI(15, 3, 900));
            _Balls = getBalls();
            ClickButton = new RelayCommand(ClickHandler);
            ExitClick = new RelayCommand(ExitClickHandler);

        }

        public ICommand ClickButton { get; set; }
        public ICommand ExitClick { get; set; }
        
        private void ClickHandler()
        {
            modelAPI.CreateBalls(_amountOfBalls);

            if (modelAPI.GetBalls().Count == 0)
            {
                throw new NullReferenceException("Brak kuleczek :(");
            }


            modelAPI.CallSimulation();
        }

        private void ExitClickHandler()
        {
            modelAPI.StopSimulation();
        }


        public IList<Ball> getBalls()
        {

            return modelAPI.GetBalls();
        }


    }
}