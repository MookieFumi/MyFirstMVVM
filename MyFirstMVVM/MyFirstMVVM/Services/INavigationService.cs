namespace MyFirstMVVM.Services
{
    public interface INavigationService
    {
        void NavigateTo<TViewModel>();
        void NavigateBack();
        void NavigateBackToFirst();
    }
}

