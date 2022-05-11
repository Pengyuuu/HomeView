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
        
        public async Task<bool> AsyncStoreAct(ActWiki act)
        {
            var newAct = new
            {
                actID = act.ActID,
                actName = act.ActID,
                actBirth = act.ActBirth,
                actGender = act.ActGender,
                actBio = act.ActBio,
            };

            var result = await _db.SaveData("dbo.ActWiki_StoreAct", newAct);
            if( result != 1)
            {
                return false;
            }

            return true;
        }
    }
}
