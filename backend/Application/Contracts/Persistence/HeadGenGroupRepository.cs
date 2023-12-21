using System;
using Domain.Entites;

namespace Application.Contracts.Persistence
{
    public class HeadGenGroupRepository : IGenericRepository<HeadGenGroup>
    {
        public Task<HeadGenGroup> Add(HeadGenGroup entity)
        {
            throw new NotImplementedException();
        }

        public Task<HeadGenGroup> Delete(HeadGenGroup entity)
        {
            throw new NotImplementedException();
        }

        public Task<HeadGenGroup> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<HeadGenGroup>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<HeadGenGroup> Update(HeadGenGroup entity)
        {
            throw new NotImplementedException();
        }
    }
}

