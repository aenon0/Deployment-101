using System.Net;
using Application.Contracts.Infrastructure;
using Application.Features.Comments.CQRS.Commands;
using Application.Features.Comments.CQRS.Queries;
using Application.Features.Comments.DTOS;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CommentController : BaseApiController
{
    public CommentController(IMediator mediator,IUserAccessor userAccessor) : base(mediator,userAccessor)
    {
    }

    
    [HttpGet]
    public async Task<IActionResult> GetAllComments(){
        var result = await _mediator.Send(new GetCommentListQuery {});
        var status = result.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound;
        return getResponse<BaseResponse<List<CommentDto>>>(status, result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingleComment(int id){
        var result = await _mediator.Send(new GetCommentQuery {Id = id});
        var status = result.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound;
        return getResponse<BaseResponse<CommentDto>>(status,result);
    }

    [HttpPost]
    public async Task<IActionResult> AddComment([FromBody] CreateCommentDto commentDto){
        var result  =  await _mediator.Send(new CreateCommentCommand{CommentDto = commentDto});
        var status = result.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
        return getResponse<BaseResponse<int>>(status,result);
    }

    [HttpPut("editComment/{id}")]
    public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentDto commentDto){
        var result = await _mediator.Send(new UpdateCommentCommand {CommentDto = commentDto});
        var status = result.Success ? HttpStatusCode.NoContent : HttpStatusCode.BadRequest;
        return getResponse<BaseResponse<Unit>>(status,result);
    }

    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> DeleteComment(int id){
        var result = await _mediator.Send(new DeleteCommentCommand{Id = id});
        var status = result.Success ? HttpStatusCode.NoContent : HttpStatusCode.BadRequest;
        return getResponse<BaseResponse<Unit>>(status,result);
    }

}
