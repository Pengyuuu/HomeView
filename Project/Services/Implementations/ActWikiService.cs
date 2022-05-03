using Features.ActWiki;
using Services.Contracts;
using Data;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;

namespace Services.Implementations
{
    public class ActWikiService : IActWikiService
    {
        private ActWikiDao _ActWikiDao;
        private static readonly HttpClient HttpClient;
        private string API_KEY = "82da0caf88a6e84985e9fe3d753d6f43";

        public ActWikiService()
        {
            SqlDataAccess db = new SqlDataAccess();
            _ActWikiDao = new ActWikiDao(db);
            
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
