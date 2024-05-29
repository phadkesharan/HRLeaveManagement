using HRLeaveManagement.Application.DTOs.LeaveRequest;
using HRLeaveManagement.Application.Feature.LeaveRequests.Requests.Commands;
using HRLeaveManagement.Application.Feature.LeaveRequests.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRLeaveManagement.Api;

[Route("api/[controller]")]
[ApiController]
public class LeaveRequestController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveRequestController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<LeaveRequestDto>>> Get()
    {
        var leaveRequestLists = await _mediator.Send(new GetLeaveRequestListRequest());

        return Ok(leaveRequestLists);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveRequestDto>> Get(int id)
    {
        var leaveRequestDetails = await _mediator.Send(new GetLeaveRequestDetailRequest() { Id = id });

        return Ok(leaveRequestDetails);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateLeaveRequestDto leaveRequestDto)
    {
        var leaveTypeId = await _mediator.Send(new CreateLeaveRequestCommand() { leaveRequestDto = leaveRequestDto });

        return CreatedAtAction(nameof(Get), new { Id = leaveTypeId }, leaveRequestDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveRequestDto leaveRequestDto)
    {
        await _mediator.Send(new UpdateLeaveRequestCommand() { Id = id, leaveRequestDto = leaveRequestDto });

        return NoContent();
    }

    [HttpPut("changeApprovalStatus/{id}")]
    public async Task<ActionResult> ChangeApproval(int id, [FromBody] ChangeLeaveRequestApprovalDto leaveRequestApprovalDto)
    {
        await _mediator.Send(new UpdateLeaveRequestCommand() { Id = leaveRequestApprovalDto.Id, changeLeaveRequestApprovalDto = leaveRequestApprovalDto });

        return NoContent();
    }

    // [HttpDelete]
    // public async Task<ActionResult> Delete(int id)
    // {
    //     await _mediator.Send(new DeleteLeaveRequestCommnad() { Id = id });

    //     return NoContent();
    // } 


}
