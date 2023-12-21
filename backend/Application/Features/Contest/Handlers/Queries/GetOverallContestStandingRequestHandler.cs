using System;
using Application.Contracts.Persistence;
using Application.DTOs;
using AutoMapper;
using MediatR;

namespace Application.Features.Contest.Handlers.Queries
{
    public class GetOverallContestStandingRequestHandler : IRequestHandler<GetOverallContestStandingRequest, List<UserContestHistoryDto>>
    {
        private readonly IUserContestHistoryRepository _userContestHistoryRepository;
        private readonly IMapper _mapper;


        public GetOverallContestStandingRequestHandler(IUserContestHistoryRepository userContestHistoryRepository, IMapper mapper)
        {
            _userContestHistoryRepository = userContestHistoryRepository;
            _mapper = mapper;
        }

        public async Task<List<UserContestHistoryDto>> Handle(GetOverallContestStandingRequest request, CancellationToken cancellationToken)
        {
            var userContestHistory = await _userContestHistoryRepository.GetOverallStanding(request.ContestId);
            return _mapper.Map<List<UserContestHistoryDto>>(userContestHistory);
        }
    }
}

