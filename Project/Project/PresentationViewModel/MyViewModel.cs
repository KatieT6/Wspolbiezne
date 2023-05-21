using Data;
using Logic;
using PresentationModel;
using System.Collections;
using System.ComponentModel;
using System.Windows.Input;

namespace PresentationViewModel
{
    public class MyViewModel : ViewModelBase
    {

        private readonly ModelAbstractAPI modelAPI;
        private int _amountOfBalls;
        private IList _balls;
        private readonly int _width;
        private readonly int _height;


        public int AmountOfBalls { 
            get => _amountOfBalls;
            set 
            {
                _amountOfBalls = value;
                RaisePropertyChanged("AmountOfBalls");
            } 
        }

        public IList BallsList
        {
            get => _balls;
            set
            {
                _balls = value;
                RaisePropertyChanged("BallsList");
            }
        }

        public MyViewModel() : this(ModelAbstractAPI.CreateModelAPI()) { }
        public MyViewModel(ModelAbstractAPI modelAbstractAPI)
        {
            modelAPI = modelAbstractAPI;
            _height = modelAPI.Height;
            _width = modelAPI.Width;
            ClickButton = new RelayCommand(OnClickButton);
            ExitClick = new RelayCommand(OnExitClick);

        }

        public ICommand ClickButton { get; set; }
        public ICommand ExitClick { get; set; }

        public int Width => _width;

        public int Height => _height;

        private void OnClickButton()
        {
            BallsList = modelAPI.CreateBalls(_amountOfBalls);
            modelAPI.CallSimulation();
        }

        private void OnExitClick()
        {
            modelAPI.StopSimulation();
        }

    }
}