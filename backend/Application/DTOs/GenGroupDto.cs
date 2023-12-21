using System;
using Application.DTOs.Common;
using Domain.Entites;

namespace Application.DTOs.ContestDtos
{
	public class GenGroupDto : BaseDto
	{
        public string GroupName { get; set; }
        public int GenerationId { get; set; }

        public GenerationDto GenerationDto { get; set; }
    }
}

