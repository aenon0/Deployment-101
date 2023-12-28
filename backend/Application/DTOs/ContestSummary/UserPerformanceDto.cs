using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.ContestSummary
{
    public class UserPerformanceDto
    {
        public string CodeforcesHandle { get; set; }
        public int Solves {  get; set; }
        public int Penality { get; set; }
    }
}
