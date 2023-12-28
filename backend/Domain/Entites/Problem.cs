using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Problem
    {
        public int ProblemId { get; set; }
        public string ProblemName { get; set; }
        public string ProblemUrl { get; set; }
        public int ContestId { get; set; }
        public Contest Contest { get; set; }
    }
}
