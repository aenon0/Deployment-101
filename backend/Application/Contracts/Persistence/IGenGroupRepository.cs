using System;
using Domain.Entites;
namespace Application.Contracts.Persistence
{
    public class IGenGroupRepository : IGenericRepository<GenGroup>
    {
        public Task<GenGroup> Add(GenGroup entity)
        {
            throw new NotImplementedException();
        }

        public Task<GenGroup> Delete(GenGroup entity)
        {
            throw new NotImplementedException();
        }

        public Task<GenGroup> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<GenGroup>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<GenGroup> Update(GenGroup entity)
        {
            throw new NotImplementedException();
        }
    }
}

