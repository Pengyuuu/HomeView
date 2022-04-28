using Features.ActWiki;
using System.Collections.Generic;

namespace Managers.Contracts
{
    public interface IActWikiManager
    {
        ActWiki GetActor(string name);
       
    }
}
