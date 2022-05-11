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

        public bool StoreAct(int id, string name, string birthday, int gender, string biography)
        {
            ActWiki newAct = new ActWiki(id, name, birthday, gender, biography);

            return _ActWikiService.StoreAct(newAct);


        }
    }
}
