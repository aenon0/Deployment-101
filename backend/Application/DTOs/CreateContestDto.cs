using System;
namespace Application.DTOs
{
	public class CreateContestDto
	{
        public string Name { get; set; }
        public string URL { get; set; }
        public DateTime DateTimeStarted { get; set; } 
        public int Duration { get; set; }
        public int GenerationId { get; set; }//gotta cancel this later
        public int UserId { get; set; }//gotta cancel this later

    }
}

