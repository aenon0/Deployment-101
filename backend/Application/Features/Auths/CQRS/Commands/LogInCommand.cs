using Application.Models;
using Application.Responses;
using MediatR;

namespace Application.Features.Auths.CQRS.Commands;

public class LogInCommand :  IRequest<BaseResponse<AuthResponse>>
{
    public AuthRequest AuthRequest { get; set; }
}
