using HRLeaveManagement.Application.DTOs.LeaveRequest;
using HRLeaveManagement.Application.Responses;
using MediatR;

namespace HRLeaveManagement.Application.Feature.LeaveRequests.Requests.Commands;

public class CreateLeaveRequestCommand : IRequest<BaseCommandResponse>
{
    public CreateLeaveRequestDto leaveRequestDto { get; set; }
}
