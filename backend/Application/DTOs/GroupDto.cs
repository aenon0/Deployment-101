using System;
using Domain.Entites;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
	public class GroupDto
	{
        public string GroupName { get; set; }
        public int UserId { get; set; }

        UserDto UserDto { get; set; }
    }
}

