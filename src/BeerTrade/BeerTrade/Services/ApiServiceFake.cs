using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeerTrade.Interfaces;
using BeerTrade.Models;

namespace BeerTrade.Services
{
    public class ApiServiceFake : IApi
    {
        public async Task<IList<FeedItem>> GetFeed()
        {
            var feed = new List<FeedItem>();

            feed.Add(new FeedItem
            {
                BeerPhoto = "https://cdn-b.william-reed.com/var/wrbm_gb_hospitality/storage/images/publications/hospitality/bighospitality.co.uk/article/2018/04/26/beer-quiz-25-questions-to-test-your-knowledge/2807204-1-eng-GB/Beer-quiz-25-questions-to-test-your-knowledge_wrbm_large.jpg",
                AvatarPhoto = "https://avatars3.githubusercontent.com/u/519642?v=4&s=460", 
                Nickname = "ionixjunior", 
                Location = "Joinville, SC, Brazil"
            });

            feed.Add(new FeedItem
            {
                BeerPhoto = "https://cdn-b.william-reed.com/var/wrbm_gb_hospitality/storage/images/publications/hospitality/bighospitality.co.uk/article/2018/04/26/beer-quiz-25-questions-to-test-your-knowledge/2807204-1-eng-GB/Beer-quiz-25-questions-to-test-your-knowledge_wrbm_large.jpg",
                AvatarPhoto = "https://avatars3.githubusercontent.com/u/519642?v=4&s=460",
                Nickname = "ionixjunior",
                Location = "Joinville, SC, Brazil"
            });

            feed.Add(new FeedItem
            {
                BeerPhoto = "https://cdn-b.william-reed.com/var/wrbm_gb_hospitality/storage/images/publications/hospitality/bighospitality.co.uk/article/2018/04/26/beer-quiz-25-questions-to-test-your-knowledge/2807204-1-eng-GB/Beer-quiz-25-questions-to-test-your-knowledge_wrbm_large.jpg",
                AvatarPhoto = "https://avatars3.githubusercontent.com/u/519642?v=4&s=460",
                Nickname = "ionixjunior",
                Location = "Joinville, SC, Brazil"
            });

            return await Task.FromResult(feed);
        }
    }
}
