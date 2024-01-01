using Application.Contracts.ContestCreation;
using Application.Contracts.ContestSummary;
using Application.DTO.ContestSummary;
using Application.Features.ContestSummary.Request;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ContestSummary.Handler
{
    public class OverallContestSummaryHandler : IRequestHandler<OverallContestSummaryRequest, List<OverallContestSummaryDto>>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IContestSummaryRepository _contestSummaryRepository;

        public OverallContestSummaryHandler(IMapper mapper, IMediator mediator, IContestSummaryRepository contestSummaryRepository)
        {

            _mapper = mapper;

            _mediator = mediator;
            _contestSummaryRepository = contestSummaryRepository;
        }
        public async  Task<List<OverallContestSummaryDto>> Handle(OverallContestSummaryRequest request, CancellationToken cancellationToken)
        {
            var res = await _contestSummaryRepository.GetOverallContestSummary();
            return res;
        }
    }
}
