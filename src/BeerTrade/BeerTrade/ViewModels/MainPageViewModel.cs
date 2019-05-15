using Prism.Navigation;

namespace BeerTrade.ViewModels
{
    public sealed class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
        }
    }
}
