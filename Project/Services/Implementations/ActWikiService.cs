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
<<<<<<< HEAD
            fetchActor = ActWikiDao.AsyncGetActorInfo(name);
=======

            //fetchActor =
            return false;
>>>>>>> d18130b0c61d4e0e5a5d163320b662c5954d0918
        }
    }

}
