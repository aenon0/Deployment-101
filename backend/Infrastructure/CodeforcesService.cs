using System;
using Application.Contracts.Infrastructure;
using Domain.Entites;

namespace Infrastructure
{
    public class CodeforcesService : ICodeforcesService
    {
        private readonly HttpClient _httpClient;
        public CodeforcesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://codeforces-contest-service-lylswf275a-lm.a.run.app/");
        }

        public async Task<HttpResponseMessage> GetHealthCheck()
        {
            var endpoint = "health-check";
            var result = await _httpClient.GetAsync(endpoint);
            return result;
        }
        public async Task<HttpResponseMessage> GetContestProblems(int contestId)
        {
            var endpoint = $"contest/{contestId}/problems";
            var result = await _httpClient.GetAsync(endpoint);
            return result;
        }

        public async Task<HttpResponseMessage> GetContestStandings(int contestId)
        {
            var endpoint = $"contest/{contestId}/standings";
            var result = await _httpClient.GetAsync(endpoint);
            return result;
        }

        public async Task<HttpResponseMessage> GetContestSubmissions(int contestId)
        {
            var endpoint = $"contest/{contestId}/submissions";
            var result = await _httpClient.GetAsync(endpoint);
            return result;
        }
    }
}

