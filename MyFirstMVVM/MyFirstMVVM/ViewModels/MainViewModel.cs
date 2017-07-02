﻿using System.Windows.Input;
using MyFirstMVVM.Services;
using MyFirstMVVM.ViewModels.Base;

namespace MyFirstMVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string _message;
        private int _clicCounter;
        readonly INavigationService _navigationService;

        public MainViewModel(INavigationService navigationService)
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
                return $"Botón pulsado {_clicCounter} veces";
            }
        }

        private ICommand _addOneToCounter;
        public ICommand AddOneToCounter
        {
            get { return _addOneToCounter = _addOneToCounter ?? new DelegateCommand(AddOneToCounterExecute, () => { return true; }); }
        }

        private void AddOneToCounterExecute()
        {
            _clicCounter++;
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
    }
}
