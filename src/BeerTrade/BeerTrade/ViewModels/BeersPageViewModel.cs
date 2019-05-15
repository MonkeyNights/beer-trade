using Prism.Navigation;

namespace BeerTrade.ViewModels
{
    public sealed class BeersPageViewModel : BaseViewModel
    {
        public BeersPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
        }
    }
}