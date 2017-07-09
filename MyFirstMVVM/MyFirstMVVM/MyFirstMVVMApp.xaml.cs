using MyFirstMVVM.Views;
using Xamarin.Forms;

namespace MyFirstMVVM
{
    public partial class MyFirstMVVMApp : Application
    {
        public MyFirstMVVMApp()
        {
            MainPage = new NavigationPage(new FirstView());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
