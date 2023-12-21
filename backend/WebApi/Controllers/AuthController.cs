using System.Net;
using Application.Contracts.Infrastructure;
using Application.Features.Auths.CQRS.Commands;
using Application.Models;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : BaseApiController
{
    public AuthController(IMediator mediator,IUserAccessor userAccessor) : base(mediator,userAccessor)
    {
    }

    
   

    [HttpPost("register")]
    public async Task<IActionResult>  Register([FromBody] RegistrationRequest registrationRequest){
        var result  =  await _mediator.Send(new RegisterCommand {RegistrationRequest = registrationRequest});
        var status = result.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
        return getResponse<BaseResponse<RegistrationResponse>>(status,result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LogIn([FromBody] AuthRequest authRequest){
        var result = await _mediator.Send(new LogInCommand {AuthRequest = authRequest});
        var status = result.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
        return getResponse<BaseResponse<AuthResponse>>(status,result);
    }
 
}
