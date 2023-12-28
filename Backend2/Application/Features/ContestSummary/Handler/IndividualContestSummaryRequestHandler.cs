using Application.Contracts.ContestSummary;
using Application.DTO.ContestSummary;
using Application.Features.ContestSummary.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ContestSummary.Handler
{
    public class IndividualContestSummaryRequestHandler : IRequestHandler<IndividualContestSummaryRequest, List<ContestPerformanceDto>>
    {
        IContestSummaryRepository _contestSummaryRepository;
        public IndividualContestSummaryRequestHandler(IContestSummaryRepository contestSummaryRepository)
        { 
            _contestSummaryRepository = contestSummaryRepository;
        }
        public async Task<List<ContestPerformanceDto>> Handle(IndividualContestSummaryRequest request, CancellationToken cancellationToken)
        {
            var res = await _contestSummaryRepository.GetIndividualContestSummary(request.CodeforcesHandle);
            return res;
        }
        
    }
}
