using Application.Contracts.ContestSummary;
using Application.Contracts.Identity;
using Application.DTO.ContestCreation;
using Application.DTO.ContestSummary;
using Application.DTO.Identity;
using Application.Features.ContestCreation.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repositories;

namespace WebApi.Controllers.IdentityController;

[Route("api/[controller]")]
[ApiController]
public class ContestController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUpdateContestSummary _updateContestSummary;
    
    public ContestController(IMediator mediator,IUpdateContestSummary updateContestSummary)
    {
        _mediator = mediator;
        _updateContestSummary = updateContestSummary;
    }

    [HttpPost("CreateContest")]
    public async Task<ActionResult<ContestCreationResponse>> CreateContest([FromBody] CreateContestCommand contest)
    {
        var res = await _mediator.Send(contest);
        return Ok(res);
    }


    [HttpGet("GetProblem")]
    public async Task<ActionResult<ProblemDto>> GetProblem([FromBody] GetProblemRequest problem)
    {
        var res = await _mediator.Send(problem);
        return Ok(res);
    }


    [HttpPost("UpdateContestSummary")]
    public async Task<ActionResult<UpdateContestSummaryDto>> UpdateContestSummary(int Id)
    {
        var res = await _updateContestSummary.syncContestSummary(Id);
        return Ok(res);
    }

}

