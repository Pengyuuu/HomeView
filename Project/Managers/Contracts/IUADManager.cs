using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.UAD;

namespace Managers.Contracts
{
    public interface IUADManager
    {
        Task<List<KeyValuePair<DateTime, int>>> GetLogInCountAsync();
        Task<List<KeyValuePair<DateTime, int>>> GetNewsCountAsync();
        Task<List<KeyValuePair<DateTime, int>>> GetRegistrationCountAsync();
        Task<List<KeyValuePair<DateTime, int>>> GetReviewCountAsync();
        Task<List<int>> GetTopMostVisitedViewAsync();
        Task<List<int>> GetTopViewDurationAsync();
        Task<UADResponse> GetAllCountsAsync();

    }
}