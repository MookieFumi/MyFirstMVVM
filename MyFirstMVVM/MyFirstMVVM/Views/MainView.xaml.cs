using Xamarin.Forms;

namespace MyFirstMVVM.Views
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();

            BindingContext = App.Locator.MainViewModel;
        }
    }
}
