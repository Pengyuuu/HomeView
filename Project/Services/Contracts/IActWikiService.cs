using Features.ActWiki;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IActWikiService
    {
        IEnumerable<ActWiki> GetAct(ActWiki actor);
        bool StoreAct(int actID, string actName, string actBirth, int actGender, string actBio);
    }
}
