using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Infrastructure
{
    public interface ICodeforcesService
    {
        Task<HttpResponseMessage> GetHealthCheck();
        Task<HttpResponseMessage> GetContestProblems(int contestId);
        Task<HttpResponseMessage> GetContestSubmissions(int contestId);
        Task<HttpResponseMessage> GetContestStandings(int contestId);
    }
}
