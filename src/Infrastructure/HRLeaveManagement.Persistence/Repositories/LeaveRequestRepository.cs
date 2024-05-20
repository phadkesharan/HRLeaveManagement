using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Persistence.Contracts;
using HRLeaveManagement.Domain;
using HRLeaveManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HRLeaveManagement.Persistence;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    private readonly LeaveManagementDbContext _dbContext;
    public LeaveRequestRepository(LeaveManagementDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus)
    {
        leaveRequest.Approved = approvalStatus;
        _dbContext.Entry(leaveRequest).State = EntityState.Modified;

        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
    {
        return await _dbContext.LeaveRequests.Include(p => p.LeaveType).ToListAsync();
    }

    public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
    {
        var leaveRequest =  await _dbContext.LeaveRequests
            .Include(p => p.LeaveType)
            .FirstOrDefaultAsync(q => q.Id == id);

        return leaveRequest ?? throw new NotFoundException(nameof(LeaveRequest), id);
    }
}
