using System;
using Application.DTOs.Common;
using Domain.Entites;

namespace Application.DTOs
{
	public class QuestionContestDto : BaseDto
	{
        public int QuestionId { get; set; }
        public int ContestId { get; set; }
        public string Name { get; set; }

        public QuestionDto Question { get; set; }
        public ContestDto Contest { get; set; }
    }
}

