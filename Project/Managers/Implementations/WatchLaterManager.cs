using Managers.Contracts;
using Services.Contracts;
using Services.Implementations;
using Features.WatchLater;
using System.Collections.Generic;

namespace Managers.Implementations
{
    public class WatchLaterManager : IWatchLaterManager
    {
        private IWatchLaterService _watchLaterService;

        public WatchLaterManager()
        {
            _watchLaterService = new WatchLaterService();
        }

        public bool AddToWatchLater(string email, string title, string year)
        {
            var isDuplicate = GetList(email);

            if (isDuplicate.Count > 0)
            {
                foreach (var item in isDuplicate)
                {
                    if (item.Title == title && item.Year == year)
                    {
                        return false;
                    } 
                }
            }

            WatchLaterTitle targetTitle = new WatchLaterTitle
            {
                Title = title,
                Year = year,
                Email = email
            };

            return _watchLaterService.AddToWatchLater(targetTitle);
        }

        public bool RemoveFromList(string email, string title, string year)
        {
            WatchLaterTitle targetTitle = new WatchLaterTitle
            {
                Title = title,
                Year = year,
                Email = email,
            };

            return _watchLaterService.RemoveFromList(targetTitle);
        }


        public List<WatchLaterTitle> GetList(string userEmail)
        {
            return _watchLaterService.GetList(userEmail);
        }
    }
}
