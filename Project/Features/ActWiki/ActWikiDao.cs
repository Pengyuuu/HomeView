using System.Collections.Generic;
using System.Threading.Tasks;
using Data;

namespace Features.ActWiki
{
    public class ActWikiDao
    {
        private readonly SqlDataAccess _db;
        
        public ActWikiDao( SqlDataAccess db)
        {
            _db = db;
        }

        public async Task<bool> AsyncGetActorInfo ( ActWiki actor )
        {
            var searchActor = new
            {
                actName = actor.actName,
                actBirth = actor.actBirth,
                actGender = actor.actGender,

            };
            try
            {
                await _db.SaveData("dbo.SearchActor", searchActor);
                return true;
            }
            catch 
            {
                return false;
            }
        
        }
    }
}
