using Services.Contracts;
using Services.Implementations;
using Managers.Contracts;
using Features.ActWiki;
using System.Threading.Tasks;

namespace Managers.Implementations
{
    public class ActWikiManager : IActWikiManager
    {
        private readonly IActWikiService _ActWikiService;
        
        public ActWikiManager()
        {
            _ActWikiService = new ActWikiService(); 
        }

        public async Task<ActWiki> AsyncGetAct ( ActWiki act)
        {
            if (act == null)
            {
                return await _ActWikiService.AsyncGetAct(act);
            }
            return null;

        }
        
    }
}
