using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeerTrade.Models;

namespace BeerTrade.Interfaces
{
    public interface IApi
    {
        Task<IList<FeedItem>> GetFeed();
    }
}
