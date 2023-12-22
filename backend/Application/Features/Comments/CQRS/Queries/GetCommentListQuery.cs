using Application.Features.Comments.DTOS;
using Application.Responses;
using MediatR;

namespace Application.Features.Comments.CQRS.Queries;

public class GetCommentListQuery : IRequest<BaseResponse<List<CommentDto>>>
{
}

 
