using Application.Contracts.Identity;
using Application.Exceptions;
using Application.Features.Auths.CQRS.Commands;
using Application.Models;
using Application.Responses;
using MediatR;

namespace Application.Features.Auths.CQRS.Handlers;

public class LogInCommandHandler : IRequestHandler<LogInCommand, BaseResponse<AuthResponse>>
{
    private readonly IAuthService _authService;

    public LogInCommandHandler(IAuthService authService)
    {
        _authService = authService;   
    }
    
    public async Task<BaseResponse<AuthResponse>> Handle(LogInCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<AuthResponse>();

        var auth = await _authService.LogIn(request.AuthRequest);
        
        if (auth is AuthResponse){
            response.Message  = "User successfully logged In";
            response.Value = auth;
            return response;
        }

        throw new InternalServerErrorException("Unable to login");
    }
}

