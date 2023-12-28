using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class UserContest
    {
        public int UserContestId { get; set; }
        public string UserId { get; set; }
        public int ContestId { get; set; }
        public ApplicationUser User { get; set; }
        public Contest Contest { get; set; }
        public int Solves { get; set; }
        public int Ranking { get; set; }
        public int Penality { get; set; }
    }
}
