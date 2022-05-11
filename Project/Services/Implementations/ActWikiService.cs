using Features.ActWiki;
using Services.Contracts;
using Data;
using System.Collections.Generic;
using System.Net.Http;
using System;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class ActWikiService : IActWikiService
    {
        private ActWikiDao _ActWikiDao;

        public ActWikiService()
        {
            SqlDataAccess db = new SqlDataAccess();
            _ActWikiDao = new ActWikiDao(db);

        }

        public bool StoreAct(ActWiki act)
        {
            return _ActWikiDao.AsyncStoreAct(act).Result;
        }

    }
}
