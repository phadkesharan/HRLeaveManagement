using HRLeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HRLeaveManagement.Application.Feature.LeaveRequests.Requests.Commands;

public class CreateLeaveRequestCommand : IRequest<int>
{
    public CreateLeaveRequestDto leaveRequestDto { get; set; }
}
