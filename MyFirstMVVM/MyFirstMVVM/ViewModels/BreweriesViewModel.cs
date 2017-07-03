using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MyFirstMVVM.Infrastructure;
using MyFirstMVVM.Models;
using MyFirstMVVM.Services;
using MyFirstMVVM.ViewModels.Base;

namespace MyFirstMVVM.ViewModels
{
    public class BreweriesViewModel : ViewModelBase
    {
        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                RaisePropertyChanged(nameof(IsBusy));
            }
        }
        private int CurrentPage;
        public int NumberOfPages;
        private IBreweriesService _breweriesService;

        public BreweriesViewModel(IBreweriesService breweriesService)
        {
            _breweriesService = breweriesService;
            Task.Run(async () => await GetBreweriesAsync(2017, 1));
        }

        private ObservableRangeCollection<BreweryDTO> _breweries;
        public ObservableRangeCollection<BreweryDTO> Breweries
        {
            get { return _breweries; }
            set
            {
                _breweries = value;
                RaisePropertyChanged(nameof(Breweries));
            }
        }

        public async Task GetBreweriesAsync(int established = 2017, int page = 1)
        {
            if (Breweries == null)
            {
                Breweries = new ObservableRangeCollection<BreweryDTO>();
            }

            IsBusy = true;

            var result = await _breweriesService.GetBreweriesAsync(established, page);
            result.Data.SetDefaultImageIfNotExists();

            Breweries.AddRange(result.Data);

            CurrentPage = result.CurrentPage;
            NumberOfPages = result.NumberOfPages;
            IsBusy = false;
        }

        private ICommand _refreshCommand;

        public ICommand RefreshCommand
        {
            get { return _refreshCommand = _refreshCommand ?? new DelegateCommand<BreweryDTO>(RefreshCommandCanExecute, RefreshCommandExecute); }
        }

        public bool RefreshCommandCanExecute(BreweryDTO brewery)
        {
            return CurrentPage != NumberOfPages && !IsBusy && Breweries.Count != 0 && Breweries.Last().Id == brewery.Id;
        }

        public void RefreshCommandExecute(BreweryDTO brewery)
        {
            Debug.WriteLine("RefreshCommandExecute");
            Task.Run(async () => await GetBreweriesAsync(2017, CurrentPage + 1));
        }
    }
}
