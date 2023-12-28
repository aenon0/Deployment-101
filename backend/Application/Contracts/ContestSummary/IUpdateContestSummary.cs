using Application.DTO.ContestSummary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.ContestSummary
{
    public interface IUpdateContestSummary
    {
        public Task<UpdateContestSummaryDto> syncContestSummary(int gymId);
    }
}
