using Features.ActWiki;
using Services.Contracts;
using Data;
using System.Collections.Generic;
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

        public async Task<ActWiki>AsyncGetAct(ActWiki act)
        {
            var found = await _ActWikiDao.AsyncGetAct(act);
 

        }
    }

}
