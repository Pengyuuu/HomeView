using Features.ActWiki;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace Managers.Contracts
{
    public interface IActWikiManager
    {
        Task<ActWiki> AsyncGetAct(ActWiki act);      
    }
}
