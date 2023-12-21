using System;
using Application.DTOs;
using MediatR;

namespace Application.Features.User.Requests
{
    public class GetUserRequest : IRequest<UserDto>
    {
        public int Id { get; set; }
    }
}

