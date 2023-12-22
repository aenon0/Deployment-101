namespace Application.Contracts.Persistence;

public interface IUnitOfWork : IDisposable
{
    ICommentRepository CommentRepository{get;}
    Task<int> Save();   
}