using Application.Features.Comments.DTOS;
using Application.Responses;
using MediatR;

namespace Application.Features.Comments.CQRS.Commands;

public class UpdateCommentCommand  : IRequest<BaseResponse<Unit>>
{
    public UpdateCommentDto? CommentDto { get; set; }
}