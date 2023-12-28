using Application.Contracts.ContestCreation;
using Application.DTO.ContestCreation;
using Application.Features.ContestCreation.Request;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ContestCreation.Handler
{
    public class CreateContestCommandHandler : IRequestHandler<CreateContestCommand, ContestCreationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IContestRepository _contestRepository;

        public CreateContestCommandHandler( IMapper mapper, IMediator mediator,IContestRepository contestRepository)
        {

            _mapper = mapper;
            _mediator = mediator;
            _contestRepository = contestRepository;
        }
        public async Task<ContestCreationResponse> Handle(CreateContestCommand request, CancellationToken cancellationToken)
        {
            var newProblemSet = _mapper.Map<List<Problem>>(request.ProblemSet);
            var contest = new Contest { ContestId = request.ContestId, Problem = newProblemSet };
            var res = await _contestRepository.CreateContest(contest);
            return res;

        }
    }
}
