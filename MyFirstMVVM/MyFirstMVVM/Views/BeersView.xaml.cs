using MyFirstMVVM.ViewModels;
using Xamarin.Forms;

namespace MyFirstMVVM.Views
{
    public partial class BeersView : ContentPage
    {
        public BeersView()
        {
            InitializeComponent();
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var viewModel = ((BeersViewModel)BindingContext);
            viewModel.SearchBeer.Execute(((SearchBar)sender).Text);
        }
    }
}
