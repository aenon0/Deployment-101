using Application.Contracts.ContestSummary;
using Application.DTO.ContestSummary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.ContestSummary
{
    public class ContestSummaryRepository : IContestSummaryRepository
    {
        ContestCentralDbContext _contestCentralDbContext;
        public ContestSummaryRepository(ContestCentralDbContext contestCentralDbContext)
        {
            _contestCentralDbContext = contestCentralDbContext;
        }

        public async Task<List<ContestPerformanceDto>> GetGroupContestSummary(string groupName)
        {
            var result = await _contestCentralDbContext.UserContests
           .Include(uc => uc.User)
           .Where(uc => uc.User.Group.Name == groupName)
           .GroupBy(uc => uc.ContestId)
           .Select(group => new ContestPerformanceDto
           {
               ContestId = group.Key,
               usersPerformance = group.Select(uc => new UserPerformanceDto
               {
                   CodeforcesHandle = uc.User.CodeforcesHandle,
                   Solves = uc.Solves,
                   Penality = uc.Penality
               }).ToList()
               })
               .ToListAsync();

                Console.WriteLine(result);
                return result;
        }

        public async Task<List<ContestPerformanceDto>> GetIndividualContestSummary(string codeForcesHandle)
        {
            var result = await _contestCentralDbContext.UserContests
           .Include(uc => uc.User)
           .Where(uc => uc.User.CodeforcesHandle == codeForcesHandle)
           .GroupBy(uc => uc.ContestId)
           .Select(group => new ContestPerformanceDto
           {
               ContestId = group.Key,
               usersPerformance = group.Select(uc => new UserPerformanceDto
               {
                   CodeforcesHandle = uc.User.CodeforcesHandle,
                   Solves = uc.Solves,
                   Penality = uc.Penality
               }).ToList()
           })
               .ToListAsync();

            Console.WriteLine(result);
            return result;
        }

        public async Task<List<ContestPerformanceDto>> GetOverallContestSummary()
        {
            var result = await _contestCentralDbContext.UserContests
            .Include(uc => uc.User)  // Ensure User navigation property is loaded
            .GroupBy(uc => uc.ContestId)
            .Select(group => new ContestPerformanceDto
            {
                ContestId = group.Key,
                usersPerformance = group.Select(uc => new UserPerformanceDto
                {
                    CodeforcesHandle = uc.User.CodeforcesHandle, 
                    Solves = uc.Solves,
                    Penality = uc.Penality
                }).ToList()
            })
            .ToListAsync();

            Console.WriteLine(result);
            return result;
        }
    }
}
