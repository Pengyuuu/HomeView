using Features.ActWiki;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IActWikiService
    {
        Task<ActWiki> AsyncGetAct(ActWiki actor);
    }
}
