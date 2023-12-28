using Application.DTO.ContestCreation;
using Application.Features.ContestCreation.Request;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.ContestCreation
{
    public interface IContestRepository
    {
        public Task<ContestCreationResponse> CreateContest(Contest contest);
        public Task<Problem> GetProblem(string url);

    }
}
