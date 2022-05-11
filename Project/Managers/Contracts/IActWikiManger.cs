using Features.ActWiki;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Managers.Contracts
{
    public interface IActWikiManager
    {
        bool StoreAct(int id, string name, string birthday, int gender, string biography);
    }
}
