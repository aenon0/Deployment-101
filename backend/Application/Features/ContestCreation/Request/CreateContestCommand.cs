using Application.DTO.ContestCreation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ContestCreation.Request
{
    public class CreateContestCommand : IRequest<ContestCreationResponse>
    {
        public int ContestId { get; set; }
        public List<ProblemDto> ProblemSet { get; set; }
    }
}
