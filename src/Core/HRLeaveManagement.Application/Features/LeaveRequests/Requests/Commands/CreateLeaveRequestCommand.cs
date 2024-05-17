using HRLeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HRLeaveManagement.Application;

public class CreateLeaveRequestCommand : IRequest<int>
{
    public LeaveRequestDto leaveRequestDto { get; set; }
}
