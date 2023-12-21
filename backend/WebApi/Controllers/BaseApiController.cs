using System.Net;
using Application.Contracts.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("QuoteBook/[controller]")]
public class BaseApiController : ControllerBase
{
    protected readonly IMediator _mediator;
    protected readonly IUserAccessor _userAccessor; 

    public BaseApiController(IMediator mediator,IUserAccessor userAccessor)
    {
        _mediator = mediator;
        _userAccessor = userAccessor;
    }

    public ActionResult getResponse<T>(HttpStatusCode status,T? payload){

        if (status == HttpStatusCode.Created){
            return Created("",payload);
        }else if(status == HttpStatusCode.BadRequest){
            return BadRequest(payload);
        }else if(status == HttpStatusCode.OK){
            return Ok(payload);
        }else if(status == HttpStatusCode.NotFound){
            return NotFound(payload);
        }else if(status == HttpStatusCode.Accepted){
            return Accepted(payload);}
        else if(status == HttpStatusCode.Unauthorized){
            return Unauthorized(payload);}
        return NoContent();
    }
}
