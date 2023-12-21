using System;
using Application.DTOs.Common;
using Application.DTOs.ContestDtos;

namespace Application.DTOs
{
	public class UserDto : BaseDto
	{
        public string Fullname { get; set; }
        public int GenGroupId { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string CodeforcesHandle { get; set; }
        public string Email { get; set; }

        public GenGroupDto GenGroup { get; set; }
        public RoleDto Role { get; set; }
    }
}

