using HRLeaveManagement.Application.Persistence.Contracts;
using FluentValidation;

namespace HRLeaveManagement.Application;

public class ILeaveAllocationDtoValidator : AbstractValidator<ILeaveAllocationDto>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;

    public ILeaveAllocationDtoValidator(ILeaveAllocationRepository leaveAllocationRepository)
    {
        _leaveAllocationRepository = leaveAllocationRepository;

        RuleFor(p => p.NumberOfDays)
            .NotNull().WithMessage("{PropertyName} cannot be Null")
            .NotEmpty().WithMessage("{PropertyName} cannot be Empty")
            .GreaterThan(0).WithMessage("{PropertyName} should be atleast 1")
            .LessThan(100).WithMessage("{PropertyName} should be less than 100");

        RuleFor(p =>p.Period)
            .NotNull().WithMessage("{PropertyName} cannot be Null")
            .NotEmpty().WithMessage("{PropertyName} cannot be Empty")
            .GreaterThan(0).WithMessage("{PropertyName} should be atleast 1")
            .LessThan(100).WithMessage("{PropertyName} should be less than 100");

        RuleFor(p =>p.LeaveTypeId)
            .NotNull().WithMessage("{PropertyName} cannot be Null")
            .GreaterThan(0)
            .MustAsync(async (id, token) => {
                var leaveAllocationExists = await _leaveAllocationRepository.Exists(id);
                return !leaveAllocationExists;                
            });

    }
}
