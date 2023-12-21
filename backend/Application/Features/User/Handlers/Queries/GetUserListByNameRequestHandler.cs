// using System;
// using Domain.Entites;
// using Application.Contracts.Persistence;
// using Application.DTOs;
// using Application.Features.User.Requests;
// using AutoMapper;
// using MediatR;

// namespace Application.Features.User.Handlers.Queries
// {
//     public class GetUserListRequestByNameHandler : IRequestHandler<GetUserListByNameRequest, List<UserDto>>
//     {
//         private readonly IUserRepository _userRepository;
//         private readonly IMapper _mapper;

//         public GetUserListRequestByNameHandler(IUserRepository userRepository, IMapper mapper)
//         {
//             _userRepository = userRepository;
//             _mapper = mapper;
//         }

//         public async Task<List<UserDto>> Handle(GetUserListByNameRequest request, CancellationToken cancellationToken)
//         {
//             var users = await _userRepository.GetUsersByName(request.Name);
//             return _mapper.Map<List<UserDto>>(users);
//         }
//     }
// }

