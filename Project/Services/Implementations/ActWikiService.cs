using Features.ActWiki;
using Services.Contracts;
using Data;
using System.Collections.Generic;

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
        
        public bool GetAct(string name)
        {

            //fetchActor =
            return false;
        }
    }

}
