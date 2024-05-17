using HRLeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HRLeaveManagement.Application.Feature.LeaveRequests.Requests.Commands;

public class UpdateLeaveRequestCommand : IRequest<Unit>
{
    public int Id { get; set; }
    
    public UpdateLeaveRequestDto leaveRequestDto { get; set; }  

    public ChangeLeaveRequestApprovalDto changeLeaveRequestApprovalDto { get; set; }

}
