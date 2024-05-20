using HRLeaveManagement.Application.Persistence.Contracts;
using HRLeaveManagement.Domain;
using HRLeaveManagement.Persistence.Repositories;

namespace HRLeaveManagement.Persistence.Repositories;

public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
{
    private readonly LeaveManagementDbContext _dbContext;

    public LeaveTypeRepository(LeaveManagementDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
