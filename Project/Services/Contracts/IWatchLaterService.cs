using System.Collections.Generic;
using Features.WatchLater;

namespace Services.Contracts
{
    public interface IWatchLaterService
    {
        bool AddToWatchLater(WatchLaterTitle selectedTitle);

        bool RemoveFromList(WatchLaterTitle selectedTitle);

        IEnumerable<WatchLaterTitle> GetList(string userEmail);
    }
}
