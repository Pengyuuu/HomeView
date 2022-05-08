using System.Collections.Generic;
using System.Threading.Tasks;

namespace Managers.Contracts
{
    public interface IUADManager
    {
        Task<List<int>> GetLogInCountAsync();
        Task<List<int>> GetNewsCountAsync();
        Task<List<int>> GetRegistrationCountAsync();
        Task<List<int>> GetReviewCountAsync();
        Task<List<int>> GetTopMostVisitedViewAsync();
        Task<List<int>> GetTopViewDurationAsync();
    }
}