using Application.Contracts.Persistence;

namespace Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{

    private readonly  ContestManagementDbContext _context;
 
    public UnitOfWork(ContestManagementDbContext context)
    {
        _context = context;
     }

    private ICommentRepository? _CommentRepository;


    public ICommentRepository CommentRepository  {
        get {
            if(_CommentRepository == null)
                _CommentRepository = new CommentRepository(_context);
            return _CommentRepository;
        }
    }
  

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }


	public async Task<int> Save()
	{
		return await _context.SaveChangesAsync();
	}
}

