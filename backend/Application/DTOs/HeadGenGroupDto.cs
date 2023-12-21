using System;
using Application.DTOs.Common;
using Application.DTOs.ContestDtos;

namespace Application.DTOs
{
	public class HeadGenGroupDto : BaseDto
	{
        public int UserId { get; set; }
        public int GenGroupId { get; set; }

        HeadGenGroupDto HeadGenGroup { get; set; }
    }
}

