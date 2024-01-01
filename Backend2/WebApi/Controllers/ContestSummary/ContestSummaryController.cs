using Application.Contracts.ContestSummary;
using Application.Contracts.Identity;
using Application.DTO.ContestCreation;
using Application.DTO.ContestSummary;
using Application.DTO.Identity;
using Application.Features.ContestCreation.Request;
using Application.Features.ContestSummary.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repositories;

namespace WebApi.Controllers.IdentityController;

[Route("api/[controller]")]
[ApiController]
public class ContestSummaryController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUpdateContestSummary _updateContestSummary;

    public ContestSummaryController(IMediator mediator, IUpdateContestSummary updateContestSummary)
    {
        _mediator = mediator;
        _updateContestSummary = updateContestSummary;
    }

    [HttpGet("GetOverallContestSummary")]
    public async Task<ActionResult<List<OverallContestSummaryDto>>> GetOverallContestSummary()
    {
        var res = await _mediator.Send(new OverallContestSummaryRequest());
        return Ok(res);
    }


    [HttpGet("GetGroupContestSummary")]
    public async Task<ActionResult<List<GroupContestSummaryDto>>> GetGroupContestSummary(string groupName)
    {
        var res = await _mediator.Send(new GroupContestSummaryRequest
        {
            GroupName = groupName
        }) ;
        return Ok(res);
    }


    [HttpGet("GetIndividualContestSummary")]
    public async Task<ActionResult<List<ContestPerformanceDto>>> GetIndividualContestSummary(string codeForcesHandle)
    {
        var res = await _mediator.Send(new IndividualContestSummaryRequest
        {
            CodeforcesHandle = codeForcesHandle
        });
        return Ok(res);
    }

}

