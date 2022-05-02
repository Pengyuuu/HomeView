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

        public IEnumerable<ActWiki> GetAct ( ActWiki act)
        {
            return _ActWikiService.GetAct(act);
        }
        
        public bool StoreAct( int actID, string actName, string actBirth, int actGender, string actBio)
        {
            return _ActWikiService.StoreAct(actID, actName, actBirth, actGender, actBio);
        }
    }
}
