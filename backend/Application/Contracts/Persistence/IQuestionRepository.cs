using System;
using Domain.Entites;
namespace Application.Contracts.Persistence
{
    public class IQuestionRepository : IGenericRepository<Question>
    {
        public Task<Question> Add(Question entity)
        {
            throw new NotImplementedException();
        }

        public Task<Question> Delete(Question entity)
        {
            throw new NotImplementedException();
        }

        public Task<Question> Get(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Question> Get(string url)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Question>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Question> Update(Question entity)
        {
            throw new NotImplementedException();
        }
    }
}

