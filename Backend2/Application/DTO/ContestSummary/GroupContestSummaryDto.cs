using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.ContestSummary
{
    public class GroupContestSummaryDto
    {
        public int? ContestId { get; set; } 
        public string? GroupName { get; set; }
        public int? AverageSolves { get; set; }
    }
}
