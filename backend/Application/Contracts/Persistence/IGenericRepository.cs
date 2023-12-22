using System;
namespace Application.Contracts.Persistence
{
	public interface IGenericRepository<T> where T: class
	{
		Task<T> Get(int id);
        Task<IReadOnlyList<T>> GetAll();
		Task<int> Add(T entity);
		Task<bool> Exists(int id);
		Task<int> Update(T entity);
        Task<int> Delete(T entity);

    }
}

