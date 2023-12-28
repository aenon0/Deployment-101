using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.ContestSummary
{
    public class ContestPerformanceDto
    {
          public int ContestId { get; set; }
        public List<UserPerformanceDto> usersPerformance { get; set; }
    }
}
