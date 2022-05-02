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

        public async Task<IEnumerable<ActWiki>> AsyncGetAct ( ActWiki act )
        {
            var searchAct = new

            {
                actID = act.ActID,
              
            };

            return await _db.LoadData<ActWiki,dynamic>("dbo.GetAct", searchAct);
        }

        public async Task<int>AsyncStoreAct(int actID, string actName, string actBirth, int actGender, string actBio)
        {
            var act = new
            {
                actID = actID,
                actName = actName,
                actBirth = actBirth,
                actGender = actGender,
                actBio = actBio
            };
            return await _db.SaveData("dbo.ActWiki_StoreAct", act);
        }
    }
}
