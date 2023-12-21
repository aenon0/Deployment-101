using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entites
{
	public class UserContestHistory 
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int ContestId { get; set; }
		public int Rank { get; set; }
		public int QuestionsDone { get; set; }

		public User User { get; set; }
		public Contest Contest { get; set; }

	}
}

