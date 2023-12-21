using Application.Models;
using Application.Responses;
using MediatR;

namespace Application.Features.Auths.CQRS.Commands;

public class RegisterCommand : IRequest<BaseResponse<RegistrationResponse>>
{
    public RegistrationRequest  RegistrationRequest { get; set; }
}
