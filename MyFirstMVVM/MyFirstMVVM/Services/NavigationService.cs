using System;
using System.Collections.Generic;
using MyFirstMVVM.ViewModels;
using MyFirstMVVM.Views;
using Xamarin.Forms;

namespace MyFirstMVVM.Services
{
    public class NavigationService : INavigationService
    {
        private IDictionary<Type, Type> viewModelRouting = new Dictionary<Type, Type>()
        {
            {
                typeof(MainViewModel),
                typeof(MainView)
            },
            {
                typeof(BeersViewModel),
                typeof(BeersView)
            },
            {
                typeof(BreweriesViewModel),
                typeof(BreweriesView)
            }
        };

        public void NavigateTo<TViewModel>()
        {
            Type pageType = viewModelRouting[typeof(TViewModel)];
            var page = Activator.CreateInstance(pageType) as Page;
            Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public void NavigateBack()
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }

        public void NavigateBackToFirst()
        {
            Application.Current.MainPage.Navigation.PopToRootAsync();
        }
    }
}

