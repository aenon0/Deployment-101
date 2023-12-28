using Application.Contracts.Identity;
using Application.DTO.ContestCreation;
using Application.DTO.Identity;
using Application.Features.ContestCreation.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.IdentityController;

[Route("api/[controller]")]
[ApiController]
public class ContestController : ControllerBase
{
    private readonly IMediator _mediator;
    public ContestController(IMediator mediator)
    {
        _mediator = mediator;
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

}

