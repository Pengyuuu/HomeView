using Features.ActWiki;
using System.Collections.Generic;

namespace Services.Contracts
{
    public interface IActWikiService
    {
        bool GetAct(string name);
    }
}
