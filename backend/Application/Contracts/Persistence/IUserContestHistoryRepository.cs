using System;
using Domain.Entites;
namespace Application.Contracts.Persistence
{
    public class IUserContestHistoryRepository: IGenericRepository<UserContestHistory>
    {
        public Task<UserContestHistory> Add(UserContestHistory entity)
        {
            throw new NotImplementedException();
        }

        public Task<UserContestHistory> Delete(UserContestHistory entity)
        {
            throw new NotImplementedException();
        }

        public Task<UserContestHistory> Get(int id)
        {
            throw new NotImplementedException();
        }
        public Task<List<UserContestHistory>> GetIndividualHistory(int userId)
        {
            throw new NotImplementedException();
        }
        public Task<List<UserContestHistory>> GetOverallStanding(int contestId)
        {
            throw new NotImplementedException();
        }
        public Task<IReadOnlyList<UserContestHistory>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserContestHistory> Update(UserContestHistory entity)
        {
            throw new NotImplementedException();
        }
    }
}

