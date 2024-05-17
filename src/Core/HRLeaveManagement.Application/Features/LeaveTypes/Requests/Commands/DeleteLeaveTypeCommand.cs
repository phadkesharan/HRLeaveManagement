using MediatR;

namespace HRLeaveManagement.Application.Feature.LeaveTypes.Requests.Commands;

public class DeleteLeaveTypeCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
