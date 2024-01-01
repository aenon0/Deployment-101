using Application.Contracts.ContestSummary;
using Application.Contracts.Infrastructure;
using Application.DTO.ContestSummary;
using Domain.Entites;
using Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.ContestSummary
{
    public class UpdateContestSummary : IUpdateContestSummary
    {
        private readonly ICodeforcesService _codeForcesApi;
        private readonly ContestCentralDbContext _dbContext;
        int totalSolves = 0;
        int participants = 0;
        Dictionary<int, int> groupMemberCounts = new Dictionary<int, int>();
        Dictionary<int, int> groupSolves = new Dictionary<int, int>();
        Dictionary<int, int> averageGroupSolves = new Dictionary<int, int>();
        public UpdateContestSummary(ICodeforcesService codeForcesApi, ContestCentralDbContext dbContext)
        {
            _dbContext = dbContext;
            _codeForcesApi = codeForcesApi;
        }

        public async Task<UpdateContestSummaryDto> syncContestSummary(int gymId)
        {
            try
            {
               
                var response = await _codeForcesApi.GetContestStandings(gymId);
                string jsonContent = await response.Content.ReadAsStringAsync();
                var contest = await _dbContext.Contests.FindAsync(gymId);

                if (jsonContent == null)
                {
                    return new UpdateContestSummaryDto
                    {
                        status = false
                    };
                }
                var jsonObj = JObject.Parse(jsonContent);
                var data = jsonObj["data"];
                string jsonString = JsonConvert.SerializeObject(data);
                List<JsonDataDto> jsonObjects = JsonConvert.DeserializeObject<List<JsonDataDto>>(jsonString);

                for (int i = 0; i < jsonObjects.Count; i++)
                {
                    var jsonObject = jsonObjects[i];
                    var user = _dbContext.Users.FirstOrDefault(u => u.CodeforcesHandle == jsonObject.handle);

                    if (user != null)
                    {
                        participants += 1;
                        totalSolves += jsonObject.solved;
                        if (groupMemberCounts.ContainsKey((int)user.GroupId)){
                            groupMemberCounts[(int)user.GroupId] += 1;
                            groupSolves[(int)user.GroupId] += jsonObject.solved;

                        }
                        else
                        {
                            groupMemberCounts[(int)user.GroupId] = 1;
                            groupSolves[(int)user.GroupId] = jsonObject.solved;
                        }

                        var userContest = new UserContest
                        {
                            ContestId = gymId,
                            UserId = user.Id,
                            Contest = contest,
                            User = user,
                            Ranking = jsonObject.rank == null ? 0 : jsonObject.rank.Value,
                            Penality = jsonObject.penality,
                            Solves = jsonObject.solved
                        };
                        await _dbContext.AddAsync(userContest);
                        await _dbContext.SaveChangesAsync();

                    }

                    var averageSolve = totalSolves / participants;
                    foreach(var key in groupSolves.Keys)
                    {
                        averageGroupSolves[key] = groupSolves[key] / groupMemberCounts[key];
                    }

                    // persist on the contest table the average problem solved on the contest
                    // persist on the contesGroup table the average problem solved by the group
                    contest.AverageSolves = averageSolve;
                    var group = await _dbContext.Groups.FindAsync(user.GroupId);

                    var groupContest = new GroupContest
                    {
                        GroupId = group.GroupId,
                        ContestId = contest.ContestId,
                        Group = group,
                        Contest = contest,
                        AverageSolves = averageGroupSolves[group.GroupId]
                    };

                    await _dbContext.AddAsync(groupContest);
                    await _dbContext.SaveChangesAsync();
                }

                return new UpdateContestSummaryDto { status = true };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new UpdateContestSummaryDto { status = false };

            }



        }
    }
}
