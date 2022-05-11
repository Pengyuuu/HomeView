using Features.ActWiki;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IActWikiService
    {
        bool StoreAct(ActWiki act);
    }
}
