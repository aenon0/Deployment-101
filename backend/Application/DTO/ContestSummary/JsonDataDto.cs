using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.ContestSummary
{
    public class JsonDataDto
    { 
        public int solved { get; set; }
        public int? rank { get; set; }
        public string handle { get; set; }
        public int penality { get; set; }

    }
}
