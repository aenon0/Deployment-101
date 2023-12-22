using Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ContestManagementDbContext _contestManagementDbContext;

    public GenericRepository(ContestManagementDbContext contestManagementDbContext)
    {
        _contestManagementDbContext = contestManagementDbContext;
    }
    public async Task<int> Add(T entity)
    {
        await _contestManagementDbContext.Set<T>().AddAsync(entity);
        return await _contestManagementDbContext.SaveChangesAsync();
    }

    public async Task<int> Delete(T entity)
    {
        _contestManagementDbContext.Set<T>().Remove(entity);
        return await _contestManagementDbContext.SaveChangesAsync();
    }

    public async Task<bool> Exists(int id)
    {
        var entity =  await _contestManagementDbContext.Set<T>().FindAsync(id);
        return entity != null;
    }

    public async Task<T?> Get(int id)
    {
        return await _contestManagementDbContext.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> GetAll()
    {
        return await _contestManagementDbContext.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<int> Update(T entity)
    {
        _contestManagementDbContext.Entry(entity).State = EntityState.Modified;
        return await _contestManagementDbContext.SaveChangesAsync();
    }
}

