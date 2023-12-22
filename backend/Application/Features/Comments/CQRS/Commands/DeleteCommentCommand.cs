using Application.Responses;
using MediatR;

namespace Application.Features.Comments.CQRS.Commands;

public class DeleteCommentCommand : IRequest<BaseResponse<Unit>>
{
    public int Id { get; set; }
}
