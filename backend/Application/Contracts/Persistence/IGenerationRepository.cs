using System;
using Domain.Entites;
namespace Application.Contracts.Persistence
{
    public class IGenerationRepository : IGenericRepository<Generation>
    {
        public Task<Generation> Add(Generation entity)
        {
            throw new NotImplementedException();
        }

        public Task<Generation> Delete(Generation entity)
        {
            throw new NotImplementedException();
        }

        public Task<Generation> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Generation>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Generation> Update(Generation entity)
        {
            throw new NotImplementedException();
        }
    }
}

