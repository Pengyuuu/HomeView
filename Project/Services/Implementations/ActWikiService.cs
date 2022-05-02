using Features.ActWiki;
using Services.Contracts;
using Data;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class ActWikiService : IActWikiService
    {
        private ActWikiDao _ActWikiDao;
        private const string APIKEY = "process.env.REACT_APP_TMDB_API_KEY";
        private WebClient TMDB = new WebClient();

        public ActWikiService()
        {
            SqlDataAccess db = new SqlDataAccess();
            _ActWikiDao = new ActWikiDao(db);
            var tmdbAPI = string.Format("https://api.themoviedb.org/3/search/" +
                "person?api_key=<<api_key>>" + "&language=en-US&page=1&include_adult=false", APIKEY);
        }

        public IEnumerable<ActWiki> GetAct(ActWiki act)
        {
            return _ActWikiDao.AsyncGetAct(act).Result;
        }

        public bool StoreAct (int actID, string actName, string actBirth, int actGender, string actBio )
        {
            var isStored = _ActWikiDao.AsyncStoreAct(actID, actName, actBirth, actGender, actBio).Result;
            if (isStored == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

}
