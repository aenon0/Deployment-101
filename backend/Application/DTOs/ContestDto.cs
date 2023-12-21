using System;
using Application.DTOs.Common;
using Domain.Entites;

namespace Application.DTOs
{
	public class ContestDto : BaseDto
	{
        public string Name { get; set; }
        public string URL { get; set; }
        public DateTime DateTimeStarted { get; set; }
        public int Duration { get; set; }
        public int GenerationId { get; set; }
        public int UserId { get; set; }

        public GenerationDto GenerationDto { get; set; }
        public UserDto UserDto { get; set; }
    }
}

