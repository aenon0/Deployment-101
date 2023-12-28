using Application.DTO.ContestSummary;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ContestSummary.Request
{
    public class IndividualContestSummaryRequest : IRequest<List<ContestPerformanceDto>>
    {
        public string CodeforcesHandle { get; set; }
    }
}
