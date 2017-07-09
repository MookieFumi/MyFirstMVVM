using System.Windows.Input;
using MyFirstMVVM.Services;
using MyFirstMVVM.ViewModels.Base;

namespace MyFirstMVVM.ViewModels
{
    public class FirstViewModel : ViewModelBase
    {
        private string _message;
        private int _clickCounter;
        readonly INavigationService _navigationService;

        public FirstViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Message = "Hi! MookieFumi. Miguel A. Martín";
        }

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                RaisePropertyChanged(nameof(Message));
            }
        }

        public string Result
        {
            get
            {
                return $"Botón pulsado {_clickCounter} veces";
            }
        }

        private ICommand _addOneToCounter;
        public ICommand AddOneToCounter
        {
            get { return _addOneToCounter = _addOneToCounter ?? new DelegateCommand(AddOneToCounterExecute, () => { return true; }); }
        }

        private void AddOneToCounterExecute()
        {
            _clickCounter++;
            RaisePropertyChanged(nameof(Result));
        }

        private ICommand _goToBeers;
        public ICommand GoToBeers
        {
            get { return _goToBeers = _goToBeers ?? new DelegateCommand(GoToBeersExecute, () => { return true; }); }
        }

        public void GoToBeersExecute()
        {
            _navigationService.NavigateTo<BeersViewModel>();
        }

        private ICommand _goToBreweries;
        public ICommand GoToBreweries
        {
            get { return _goToBreweries = _goToBreweries ?? new DelegateCommand(GoToBreweriesExecute, () => { return true; }); }
        }

        public void GoToBreweriesExecute()
        {
            _navigationService.NavigateTo<BreweriesViewModel>();
        }
    }
}
