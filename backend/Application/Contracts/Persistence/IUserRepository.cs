using System;
using Domain.Entites;

namespace Application.Contracts.Persistence
{
    public class IUserRepository : IGenericRepository<User>
    {
        public Task<User> Add(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(int id)
        {
            throw new NotImplementedException();
        }
        public Task<List<User>> GetUsersByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(User entity)
        {
            throw new NotImplementedException();
        }

        internal Task GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}

