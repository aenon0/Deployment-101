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

        public async Task<List<GroupContestSummaryDto>> GetGroupContestSummary(string groupName)
        {

            var group = await _contestCentralDbContext.Groups.FirstOrDefaultAsync(p => p.Name == groupName);
            var result = await _contestCentralDbContext.GroupContests
                .Where(gc => gc.Group.GroupId == group.GroupId) 
                .ToListAsync();
            var groupContestSummary = new List<GroupContestSummaryDto>();
            foreach (var groupContest in result)
            {
                groupContestSummary.Add(new GroupContestSummaryDto
                {
                    ContestId = groupContest.ContestId,
                    GroupName = group.Name,
                    AverageSolves = groupContest.AverageSolves
                }); ;
            }   
            
            return groupContestSummary;
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

        public async Task<List<OverallContestSummaryDto>> GetOverallContestSummary()
        {
            var contests = await _contestCentralDbContext.Contests.ToListAsync();
            var overallContestSummary = new List<OverallContestSummaryDto>();
            foreach(var contest in contests)
            {
                overallContestSummary.Add(new OverallContestSummaryDto { ContestId = contest.ContestId,AverageSolves = contest.AverageSolves });
            }

            return overallContestSummary;
        }
    }
}
