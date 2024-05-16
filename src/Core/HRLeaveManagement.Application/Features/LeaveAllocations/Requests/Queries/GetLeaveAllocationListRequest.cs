using MediatR;

namespace HRLeaveManagement.Application.Feature.LeaveAllocations.Requests.Queries;

public class GetLeaveAllocationListRequest : IRequest<List<LeaveAllocationDto>>
{

}
