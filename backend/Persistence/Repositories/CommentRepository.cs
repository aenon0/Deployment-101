using Application.Contracts.Persistence;
using Domain.Entites;

namespace Persistence.Repositories;

public class CommentRepository : GenericRepository<Comment>,ICommentRepository
{
    private readonly ContestManagementDbContext _contestManagementDbContext;
    public CommentRepository(ContestManagementDbContext contestManagementDbContext) : base(contestManagementDbContext)
    {
        _contestManagementDbContext = contestManagementDbContext;
    }
}
