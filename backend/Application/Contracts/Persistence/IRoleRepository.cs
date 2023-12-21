using System;
using Domain.Entites;

namespace Application.Contracts.Persistence
{
    public class IRoleRepository : IGenericRepository<Role>
    {
        public Task<Role> Add(Role entity)
        {
            throw new NotImplementedException();
        }

        public Task<Role> Delete(Role entity)
        {
            throw new NotImplementedException();
        }

        public Task<Role> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Role>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Role> Update(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}

