using System;
using Domain.Entites;
namespace Application.Contracts.Persistence
{
    public class IContestRepository : IGenericRepository<Contest>
    {
        public Task<Contest> Add(Contest entity)
        {
            throw new NotImplementedException();
        }

        public Task<Contest> Delete(Contest entity)
        {
            throw new NotImplementedException();
        }

        public Task<Contest> Get(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Contest> Get(string url)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Contest>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Contest> Update(Contest entity)
        {
            throw new NotImplementedException();
        }
    }
}

