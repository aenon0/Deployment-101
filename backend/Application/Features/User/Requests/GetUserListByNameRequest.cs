using System;
using Application.DTOs;
using MediatR;

namespace Application.Features.User.Requests
{
    public class GetUserListByNameRequest : IRequest<List<UserDto>>
    {
        public string Name { get; set; }
    }
}

