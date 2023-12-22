using Application.Features.Comments.DTOS;
using Application.Responses;
using MediatR;


namespace Application.Features.Comments.CQRS.Commands;

public class CreateCommentCommand : IRequest<BaseResponse<int>>
{
     public CreateCommentDto? CommentDto { get; set; }

}
