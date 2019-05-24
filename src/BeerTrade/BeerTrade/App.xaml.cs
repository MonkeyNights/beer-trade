using System.Threading.Tasks;
using BeerTrade.Interfaces;
using BeerTrade.Services;
using BeerTrade.ViewModels;
using BeerTrade.Views;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Xamarin.Forms;

namespace BeerTrade
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }

        public App(IPlatformInitializer platformInitializer) : base(platformInitializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await InitializeNavigation();
        }

        private Task InitializeNavigation()
            => NavigationService.NavigateAsync("MainPage");

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<FeedPage, FeedPageViewModel>();
            containerRegistry.RegisterForNavigation<BeersPage, BeersPageViewModel>();
            containerRegistry.RegisterForNavigation<TradesPage, TradesPageViewModel>();
            containerRegistry.RegisterForNavigation<ProfilePage, ProfilePageViewModel>();
            containerRegistry.RegisterSingleton<IApi, ApiServiceFake>();
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
