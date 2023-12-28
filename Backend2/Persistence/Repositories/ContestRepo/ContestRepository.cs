using Application.Contracts.ContestCreation;
using Application.DTO.ContestCreation;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.ContestRepo
{
    public class ContestRepository : IContestRepository
    {

        ContestCentralDbContext _contestCentralDbContext;
        public ContestRepository(ContestCentralDbContext contestCentralDbContext)
        {
            _contestCentralDbContext = contestCentralDbContext;
        }
        public async Task<ContestCreationResponse> CreateContest(Contest contest)
        {
            await _contestCentralDbContext.AddAsync(contest);
            await _contestCentralDbContext.SaveChangesAsync();

            return new ContestCreationResponse { ContestId = contest.ContestId };
        }

        public async Task<Problem> GetProblem(string url)
        {
            var problem = await _contestCentralDbContext.Problems
    .FirstOrDefaultAsync(p => p.ProblemUrl == url);
            return problem;
        }
    }
}
