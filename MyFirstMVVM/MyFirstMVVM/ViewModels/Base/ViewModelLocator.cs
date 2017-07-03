using Microsoft.Practices.Unity;
using MyFirstMVVM.Services;

namespace MyFirstMVVM.ViewModels.Base
{
    public static class ViewModelLocator
    {
        readonly static IUnityContainer _container;

        static ViewModelLocator()
        {
            _container = new UnityContainer();

            // Register ViewModels
            _container.RegisterType<MainViewModel>();
            _container.RegisterType<BeersViewModel>();
            _container.RegisterType<BreweriesViewModel>();

            //Register Services
            _container.RegisterType<INavigationService, NavigationService>();
            _container.RegisterType<IBreweriesService, BreweriesService>();
        }

        public static MainViewModel MainViewModel => _container.Resolve<MainViewModel>();
        public static BeersViewModel BeersViewModel => _container.Resolve<BeersViewModel>();
        public static BreweriesViewModel BreweriesViewModel => _container.Resolve<BreweriesViewModel>();
    }
}
