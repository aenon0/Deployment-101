using System;
using Application.DTOs;
using MediatR;

namespace Application.Features.Contest.Requests
{
	public class CreateContestRequest : IRequest<ContestDto>
	{
		public CreateContestDto CreateContestDto;
	}
}

