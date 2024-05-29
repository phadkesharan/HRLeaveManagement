using HRLeaveManagement.Application.DTOs.LeaveAllocation;
using HRLeaveManagement.Application.Feature.LeaveAllocations.Handlers.Commands;
using HRLeaveManagement.Application.Feature.LeaveAllocations.Requests.Commands;
using HRLeaveManagement.Application.Feature.LeaveAllocations.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace HRLeaveManagement.Api;

[Route("api/[controller]")]
[ApiController]
public class LeaveAllocationController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveAllocationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<LeaveAllocationDto>>> Get()
    {
        var leaveAllocationList = await _mediator.Send(new GetLeaveAllocationListRequest());

        return Ok(leaveAllocationList);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveAllocationDto>> Get(int id)
    {
        var leaveAllocationDetail = await _mediator.Send(new GetLeaveAllocationDetailRequest() { Id = id });

        return Ok(leaveAllocationDetail);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateLeaveAllocationDto leaveAllocationDto)
    {
        var leaveAllocationId = await _mediator.Send(new CreateLeaveAllocationCommand() { leaveAllocationDto = leaveAllocationDto });

        return CreatedAtAction(nameof(Get), new { Id = leaveAllocationId }, leaveAllocationDto);
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromBody] UpdateLeaveAllocationDto leaveAllocationDto)
    {
        await _mediator.Send(new UpdateLeaveAllocationCommand() { leaveAllocationDto = leaveAllocationDto });

        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteLeaveAllocationCommand() { Id = id });

        return NoContent();
    } 

}
