using MediatR;

namespace HRLeaveManagement.Application.Feature.LeaveAllocations.Requests.Commands;

public class DeleteLeaveAllocationCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
