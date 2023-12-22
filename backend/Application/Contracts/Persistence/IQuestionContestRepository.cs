using System;
using Domain.Entites;

namespace Application.Contracts.Persistence
{
    public interface IQuestionContestRepository : IGenericRepository<QuestionContest>
    {
        public Task<QuestionContest> Add(QuestionContest entity)
        {
            throw new NotImplementedException();
        }

        public Task<QuestionContest> Delete(QuestionContest entity)
        {
            throw new NotImplementedException();
        }

        public Task<QuestionContest> Get(int id)
        {
            throw new NotImplementedException();
        }
        public Task<List<Question>> GetQuestionsByContestId(int contestId)
        {
            throw new NotImplementedException();
        }
        public Task<IReadOnlyList<QuestionContest>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<QuestionContest> Update(QuestionContest entity)
        {
            throw new NotImplementedException();
        }
    }
}

