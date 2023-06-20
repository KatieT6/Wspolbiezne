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
        /*private IList _balls;*/
        private readonly int _width;
        private readonly int _height;
        public ObservableCollection<BallModel> BallsCollection { get; }


        public int AmountOfBalls { 
            get => _amountOfBalls;
            set 
            {
                _amountOfBalls = value;
                RaisePropertyChanged("AmountOfBalls");
            } 
        }

        /*public IList BallsList
        {
            get => _balls;
            set
            {
                _balls = value;
                RaisePropertyChanged("BallsList");
            }
        }*/

        public MyViewModel() : this(ModelAbstractAPI.CreateModelAPI()) { }
        public MyViewModel(ModelAbstractAPI modelAbstractAPI)
        {
            modelAPI = ModelAbstractAPI.CreateModelAPI();
            _height = modelAPI.Height;
            _width = modelAPI.Width;
            ClickButton = new RelayCommand(OnClickButton);
            ExitClick = new RelayCommand(OnExitClick);
            BallsCollection = modelAPI.Balls;
        }

        public ICommand ClickButton { get; set; }
        public ICommand ExitClick { get; set; }

        public int Width => _width;

        public int Height => _height;

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