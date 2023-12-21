using System;
using Application.Contracts.Persistence;
using Application.DTOs;
using Application.Features.User.Requests;
using AutoMapper;
using MediatR;

namespace Application.Features.User.Handlers.Queries
{
    public class GetIndividualContestHistoryRequestHandler : IRequestHandler<GetIndividualContestHistoryRequest, List<UserContestHistoryDto>>
    {
        private readonly IUserContestHistoryRepository _userContestHistoryRepository;
        private readonly IMapper _mapper;
        public GetIndividualContestHistoryRequestHandler(IUserContestHistoryRepository userContestHistoryRepository, IMapper mapper)
        {
            _userContestHistoryRepository = userContestHistoryRepository;
            _mapper = mapper;
        }

        public async Task<List<UserContestHistoryDto>> Handle(GetIndividualContestHistoryRequest request, CancellationToken cancellationToken)
        {
            var userContestHistory = await _userContestHistoryRepository.GetIndividualHistory(request.UserId);
            return _mapper.Map<List<UserContestHistoryDto>>(userContestHistory);
        }
    }
}

