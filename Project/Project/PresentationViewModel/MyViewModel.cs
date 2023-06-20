using Data;
using Logic;
using PesentationModel;
using PresentationModel;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace PresentationViewModel
{
    public class MyViewModel : ViewModelBase
    {

        private readonly ModelAbstractAPI modelAPI;
        private int _amountOfBalls;
        private readonly int _boardWidth = 750;
        private readonly int _boardHeight = 400;
        public ObservableCollection<BallModel> BallsCollection { get; }


        public int AmountOfBalls { 
            get => _amountOfBalls;
            set 
            {
                _amountOfBalls = value;
                RaisePropertyChanged("AmountOfBalls");
            } 
        }


        public MyViewModel()
        {
            modelAPI = ModelAbstractAPI.CreateModelAPI(_boardWidth, _boardHeight);
            ClickButton = new RelayCommand(OnClickButton);
            ExitClick = new RelayCommand(OnExitClick);
            BallsCollection = modelAPI.Balls;
        }

        public ICommand ClickButton { get; set; }
        public ICommand ExitClick { get; set; }

        public int BoardWidth => _boardWidth;

        public int BoardHeight => _boardHeight;

        private void OnClickButton()
        {
            modelAPI.AddBalls(AmountOfBalls);
        }

        private void OnExitClick()
        {
            modelAPI.StopSimulation();
            BallsCollection.Clear();
        }

    }
}