using System;
using Application.DTOs;
using MediatR;

namespace Application.Features.Contest.Handlers.Queries
{
    public class GetOverallContestStandingRequest : IRequest<List<UserContestHistoryDto>>
    {
        public int ContestId { get; set; }
    }
}

