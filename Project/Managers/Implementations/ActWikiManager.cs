using System.Collections.Generic;
using System.Linq;
using Services.Contracts;
using Services.Implementations;
using Managers.Contracts;
using Features.ActWiki;

namespace Managers.Implementations
{
    public class ActWikiManager : IActWikiManager
    {
        private readonly IActWikiService _ActWikiService;
        
        public ActWikiManager()
        {
            _ActWikiService = new ActWikiService(); 
        }

        public ActWiki GetActor (string name)
        {
            ActWiki actor = new ActWiki();
            actor.actName = name;
            return actor;
        }
    }
}
