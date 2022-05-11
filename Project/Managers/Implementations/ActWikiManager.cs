using Services.Contracts;
using Services.Implementations;
using Managers.Contracts;
using Features.ActWiki;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Managers.Implementations
{
    public class ActWikiManager : IActWikiManager
    {
        private readonly IActWikiService _ActWikiService;
        
        public ActWikiManager()
        {
            _ActWikiService = new ActWikiService(); 
        }

        public bool StoreAct(int id, string name, string birth, int gender, string bio, string profile_path)
        {
            ActWiki newAct = new ActWiki(id, name, birth, gender, bio, profile_path);

            return _ActWikiService.StoreAct(newAct);


        }
    }
}
