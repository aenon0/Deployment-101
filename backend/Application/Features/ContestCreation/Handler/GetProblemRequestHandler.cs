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

    public class GetProblemRequestHandler : IRequestHandler<GetProblemRequest, ProblemDto>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IContestRepository _contestRepository;
        public GetProblemRequestHandler(IMapper mapper, IMediator mediator, IContestRepository contestRepository)
        {

            _mapper = mapper;
            _mediator = mediator;
            _contestRepository = contestRepository;
        }
        public async Task<ProblemDto> Handle(GetProblemRequest request, CancellationToken cancellationToken)
        {
            var res = await _contestRepository.GetProblem(request.ProblemUrl);
            if (res == null)
            {
                throw new Exception("Problem Not Found");
                
            }
            var problemDto = _mapper.Map<ProblemDto>(res);

            return problemDto;
        }
    }
}
