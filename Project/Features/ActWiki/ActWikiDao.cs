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

        public async Task<int> AsyncGetAct ( ActWiki act )
        {
            var searchAct = new

            {
                ActName = act.ActName,
                ActBirth = act.ActBirth,
                ActGender = act.ActGender,
                ActBio = act.ActBio,
              
            };

            return await _db.SaveData("dbo.ActSearched", searchAct);


        }
    }
}
