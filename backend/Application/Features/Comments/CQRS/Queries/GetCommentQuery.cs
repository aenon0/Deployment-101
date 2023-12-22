using Application.Features.Comments.DTOS;
using Application.Responses;
using MediatR;

namespace Application.Features.Comments.CQRS.Queries;

public class GetCommentQuery : IRequest<BaseResponse<CommentDto>>
{
    public int Id { get; set; }
}
 
