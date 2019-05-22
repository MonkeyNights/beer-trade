using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using BeerTrade.Interfaces;
using BeerTrade.Models;
using Prism;
using Prism.Navigation;

namespace BeerTrade.ViewModels
{
    public class FeedPageViewModel : BaseViewModel, IActiveAware
    {
        private readonly IApi _api;

        public ObservableCollection<FeedItem> Items { get; private set; }

        public FeedPageViewModel(
            INavigationService navigationService, 
            IApi api)
            : base(navigationService)
        {
            _api = api;
            Items = new ObservableCollection<FeedItem>();
        }

        public event EventHandler IsActiveChanged;

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { SetProperty(ref _isActive, value, RaiseIsActiveChanged); }
        }

        protected virtual async void RaiseIsActiveChanged()
        {
            IsActiveChanged?.Invoke(this, EventArgs.Empty);

            await GetFeed();
        }

        private async Task GetFeed()
        {
            try
            {
                var feed = await _api.GetFeed();

                Items.Clear();

                foreach (var item in feed)
                    Items.Add(item);
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }
        }
    }
}