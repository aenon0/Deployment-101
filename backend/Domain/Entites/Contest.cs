using System;
namespace Domain.Entites
{
	public class Contest
	{
		public int Id { get; set; }
		public string Name { get; set; }
        public string URL { get; set; }
        public DateTime DateTimeStarted { get; set; }
        public int Duration { get; set; }
		public int HeadGenGroupId { get; set; }

		public HeadGenGroup HeadGenGroup { get; set; }

	}
}

