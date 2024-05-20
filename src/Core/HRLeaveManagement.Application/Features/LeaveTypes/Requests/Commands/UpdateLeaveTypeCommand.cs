using HRLeaveManagement.Application.DTOs.LeaveType;
using MediatR;

namespace HRLeaveManagement.Application.Feature.LeaveTypes.Requests.Commands;

public class UpdateLeaveTypeCommand : IRequest<Unit>
{
    public UpdateLeaveTypeDto leaveTypeDto { get; set; }
}
