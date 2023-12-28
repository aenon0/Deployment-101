using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Contest
    {
        public int ContestId { get; set; }
        public List<Problem> Problem { get; set; }
        public ICollection<UserContest> UserContests { get; set; }
    }
}
