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
                Console.WriteLine(jsonContent);
                var contest = await _dbContext.Contests.FindAsync(gymId);
                if (jsonContent == null)
                {
                    return new UpdateContestSummaryDto
                    {
                        status = false
                    };
                }
                var jsonObj = JObject.Parse(jsonContent);
                Console.WriteLine(jsonObj);
                var data = jsonObj["data"];
                Console.WriteLine(data);
                string jsonString = JsonConvert.SerializeObject(data);
                Console.WriteLine(jsonString);
                List<JsonDataDto> jsonObjects = JsonConvert.DeserializeObject<List<JsonDataDto>>(jsonString);

                for (int i = 0; i < jsonObjects.Count; i++)
                {
                    var jsonObject = jsonObjects[i];
                    var user = _dbContext.Users.FirstOrDefault(u => u.CodeforcesHandle == jsonObject.handle);

                    if (user != null)
                    {
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
