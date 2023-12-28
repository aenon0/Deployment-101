using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public List<ApplicationUser> GroupMembers { get; set; }
    }
}
