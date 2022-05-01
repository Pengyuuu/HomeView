using System.Collections.Generic;
using Features.WatchLater;

namespace Managers.Contracts
{
    public interface IWatchLaterManager
    {
        bool AddToWatchLater(string email, string title, string year);

        bool RemoveFromList(string email, string title, string year);

        List<WatchLaterTitle> GetList(string userEmail);
    }
}
