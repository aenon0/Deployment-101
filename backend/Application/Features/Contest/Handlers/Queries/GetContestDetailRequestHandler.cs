// using System;
// using Application.Contracts.Persistence;
// using Application.DTOs;
// using Application.Features.Contest.Requests;
// using AutoMapper;
// using MediatR;

// namespace Application.Features.Contest.Handlers
// {
//     public class GetContestDetailRequestHandler : IRequestHandler<GetContestDetailRequest, ContestDto>
//     {
//         private readonly IContestRepository _contestRepository;
//         private readonly IMapper _mapper;
//         public GetContestDetailRequestHandler(IContestRepository contestRepository, IMapper mapper)
//         {
//             _contestRepository = contestRepository;
//             _mapper = mapper;
//         }

//         public async Task<ContestDto> Handle(GetContestDetailRequest request, CancellationToken cancellationToken)
//         {
//             var contest = await _contestRepository.Get(request.Id);
//             return _mapper.Map<ContestDto>(contest);
//         }
//     }
// }

