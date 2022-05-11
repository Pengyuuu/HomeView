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
                id = act.id,
                name = act.name,
                birthday = act.birthday,
                gender = act.gender,
                biography = act.biography,
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
