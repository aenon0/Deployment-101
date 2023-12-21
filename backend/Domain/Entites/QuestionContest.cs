using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entites
{
	public class QuestionContest 
	{
		public int Id { get; set; }
		public int QuestionId { get; set; }
		public int ContestId { get; set; }
		public string Name { get; set; }

		public Question Question { get; set; }
		public Contest Contest { get; set; }
	}
}

