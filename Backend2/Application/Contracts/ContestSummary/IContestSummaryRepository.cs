using Application.DTO.ContestCreation;
using Application.DTO.ContestSummary;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.ContestSummary
{
    public interface IContestSummaryRepository
    {
        public Task<List<ContestPerformanceDto>> GetOverallContestSummary();
        public Task<List<ContestPerformanceDto>> GetGroupContestSummary(string groupName);
        public Task<List<ContestPerformanceDto>> GetIndividualContestSummary(string codeForcesHandle);
    }
}
