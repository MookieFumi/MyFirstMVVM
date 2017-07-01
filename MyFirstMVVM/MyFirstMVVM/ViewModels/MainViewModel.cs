using System.Windows.Input;
using MyFirstMVVM.ViewModels.Base;

namespace MyFirstMVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string _message;
        private DelegateCommand _helloCommand;
        private int _clicCounter;

        public MainViewModel()
        {
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

        public ICommand AddOneToCounter
        {
            get { return _helloCommand = _helloCommand ?? new DelegateCommand(AddOneToCounterExecute, () => { return true; }); }
        }

        private void AddOneToCounterExecute()
        {
            _clicCounter++;
            RaisePropertyChanged(nameof(Result));
        }
    }
}
