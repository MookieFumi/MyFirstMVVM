using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using MyFirstMVVM.Models;
using MyFirstMVVM.ViewModels.Base;
using Xamarin.Forms;

namespace MyFirstMVVM.ViewModels
{
    public class BeersViewModel : ViewModelBase
    {
        ObservableCollection<Beer> _beers;

        public ObservableCollection<Beer> Beers
        {
            get { return _beers; }
            set
            {
                _beers = value;
                RaisePropertyChanged(nameof(Beers));
            }
        }

        public BeersViewModel()
        {
            Beers = GetBeers();
        }

        public ICommand SearchBeer => new Command(o =>
         {
             var filter = o as string;
             if (string.IsNullOrWhiteSpace(filter))
             {
                 Beers = GetBeers();
             }
             else if (filter.Length >= 3)
             {
                 Beers = GetBeers(filter);
             }
         });

        public ObservableCollection<Beer> GetBeers(string filter = "")
        {
            IEnumerable<Beer> beers;
            if (string.IsNullOrEmpty(filter))
            {
                beers = GetDataFromService();
            }
            else
            {
                beers = GetDataFromService().Where(p => p.Name.Contains(filter));
            }
            return new ObservableCollection<Beer>(beers);
        }

        private IEnumerable<Beer> GetDataFromService()
        {
            return new List<Beer>()
            {
                new Beer("Ale", "501 Golden Ale"),
                new Beer("Ale", "All or nothing hopfenweisse"),
                new Beer("Ale", "Barnstormer watermelon"),
                new Beer("Malt","Mad Jack"),
                new Beer("Malt","Boxer Watermelon"),
                new Beer("Malt","Margaritaville Classic"),
                new Beer("Lager","Apline Lager"),
                new Beer("Lager","Amsteradm Pale Rider")
            };
        }
    }
}
