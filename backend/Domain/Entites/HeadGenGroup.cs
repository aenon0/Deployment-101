using System;
namespace Domain.Entites
{
	public class HeadGenGroup
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int GenGroupId { get; set; }

		public User User { get; set; }
		public GenGroup GenGroup { get; set; }
	}
}

