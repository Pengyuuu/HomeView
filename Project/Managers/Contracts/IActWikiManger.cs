using Features.ActWiki;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Managers.Contracts
{
    public interface IActWikiManager
    {
        bool StoreAct(int id, string name, string birth, int gender, string bio, string profile_path);
    }
}
