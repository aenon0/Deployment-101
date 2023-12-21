using System;
using Domain.Entites;
using System.ComponentModel.DataAnnotations;
using Application.DTOs.Common;

namespace Application.DTOs
{
	public class QuestionDto : BaseDto
	{
        public string URL { get; set; }
    }
}

