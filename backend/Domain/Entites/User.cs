using System;
namespace Domain.Entites
{
	public class User
	{
        public int Id { set; get; }
        public string Fullname { get; set; }
        public int GenGroupId { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string CodeforcesHandle { get; set; }
        public string Email { get; set; }
        

        public GenGroup GenGroup { get; set; }
        public Role Role { get; set; }

    }
}

