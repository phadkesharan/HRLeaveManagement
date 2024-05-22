using HRLeaveManagement.Application.DTOs.LeaveType;
using HRLeaveManagement.Application.Feature.LeaveTypes.Requests.Commands;
using HRLeaveManagement.Application.Feature.LeaveTypes.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRLeaveManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<LeaveTypeDto>>> Get()
    {
        var leaveTypeList = await _mediator.Send(new GetLeaveTypeListRequest());

        return Ok(leaveTypeList);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveTypeDto>> Get(int id)
    {
        var leaveTypeDetail = await _mediator.Send(new GetLeaveTypeDetailRequest() { Id = id });

        return Ok(leaveTypeDetail);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateLeaveTypeDto leaveTypeDto)
    {
        var leaveTypeId = await _mediator.Send(new CreateLeaveTypeCommand() { leaveTypeDto = leaveTypeDto });

        return CreatedAtAction(nameof(Get), new { Id = leaveTypeId }, leaveTypeDto);
    }

}
