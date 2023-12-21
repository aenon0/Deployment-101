using System;
using Application.DTOs.Common;
using Application.DTOs.ContestDtos;
using Domain.Entites;


namespace Application.DTOs
{
	public class UserContestHistoryDto : BaseDto
	{
        public int UserId { get; set; }
        public int ContestId { get; set; }
        public int Rank { get; set; }
        public int QuestionsDone { get; set; }

        public UserDto UserDto { get; set; }
        public ContestDto ContestDto { get; set; }

    }
}

