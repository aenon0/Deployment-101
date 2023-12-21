using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entites
{
	public class GenGroup
	{
		public int Id { get; set; }
		public string GroupName { get; set; }
		public int GenerationId { get; set; }

		public Generation Generation { get; set; }
	}
}

