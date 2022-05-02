using Features.ActWiki;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Managers.Contracts
{
    public interface IActWikiManager
    {
        IEnumerable<ActWiki> GetAct(ActWiki act);
        bool StoreAct(int actID, string actName, string actBirth, int actGender, string actBio);
    }
}
