using Microsoft.Practices.Unity;

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
        }

        public static MainViewModel MainViewModel => _container.Resolve<MainViewModel>();
    }
}
