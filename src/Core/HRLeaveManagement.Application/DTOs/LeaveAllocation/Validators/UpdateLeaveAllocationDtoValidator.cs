using FluentValidation;
using HRLeaveManagement.Application.DTOs.LeaveAllocation;
using HRLeaveManagement.Application.Persistence.Contracts;

namespace HRLeaveManagement.Application;

public class UpdateLeaveAllocationDtoValidator : AbstractValidator<UpdateLeaveAllocationDto>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;

    public UpdateLeaveAllocationDtoValidator(ILeaveAllocationRepository leaveAllocationRepository)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        Include(new ILeaveAllocationDtoValidator(_leaveAllocationRepository));

        RuleFor(p => p.Id).NotNull();
    }
}
