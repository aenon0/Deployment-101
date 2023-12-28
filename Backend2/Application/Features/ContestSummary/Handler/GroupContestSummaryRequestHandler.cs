using Application.Contracts.ContestSummary;
using Application.DTO.ContestSummary;
using Application.Features.ContestSummary.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ContestSummary.Handler
{
    internal class GroupContestSummaryRequestHandler : IRequestHandler<GroupContestSummaryRequest, List<ContestPerformanceDto>>
    {
        IContestSummaryRepository _contestSummaryRepository;
        public GroupContestSummaryRequestHandler(IContestSummaryRepository contestSummaryRepository)
        { 
            _contestSummaryRepository = contestSummaryRepository;
        }
        public async Task<List<ContestPerformanceDto>> Handle(GroupContestSummaryRequest request, CancellationToken cancellationToken)
        {
            var res = await _contestSummaryRepository.GetGroupContestSummary(request.GroupName);
            return res;
        }
    }
}
