using Application.Contracts.Identity;
using Application.Exceptions;
using Application.Features.Auths.CQRS.Commands;
using Application.Models;
using Application.Responses;
using MediatR;

namespace Application.Features.Auths.CQRS.Handlers;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, BaseResponse<RegistrationResponse>>
{
    private readonly IAuthService _authService;

    public RegisterCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<BaseResponse<RegistrationResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<RegistrationResponse>();
        var regResponse = await _authService.Register(request.RegistrationRequest);
        if (regResponse is RegistrationResponse)
        {
            response.Message = "User successfully registered";
            response.Value = regResponse;
            return response;
        }
        Console.WriteLine("Surafel Getahun");
        throw new InternalServerErrorException("System failed to register the user");
    }
}

