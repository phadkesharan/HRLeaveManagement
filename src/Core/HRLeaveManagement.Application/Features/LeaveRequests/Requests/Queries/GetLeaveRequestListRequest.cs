using HRLeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HRLeaveManagement.Application.Feature.LeaveRequests.Requests.Queries;

public class GetLeaveRequestListRequest : IRequest<List<LeaveRequestListDto>>
{

}
