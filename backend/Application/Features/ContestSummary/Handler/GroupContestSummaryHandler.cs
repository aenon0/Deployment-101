using Application.Contracts.ContestCreation;
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
    public class GroupContestSummaryHandler : IRequestHandler<GroupContestSummaryRequest, ContestPerformanceDto>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IContestRepository _contestRepository;

        public GroupContestSummaryHandler(IMapper mapper, IMediator mediator, IContestRepository contestRepository)
        {

            _mapper = mapper;
            _mediator = mediator;
            _contestRepository = contestRepository;
        }
        public Task<ContestPerformanceDto> Handle(GroupContestSummaryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
