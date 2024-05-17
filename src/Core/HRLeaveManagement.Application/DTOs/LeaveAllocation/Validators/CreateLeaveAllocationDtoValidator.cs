using System.Data;
using FluentValidation;

namespace HRLeaveManagement.Application.DTOs.LeaveAllocation.Validator;

public class CreateLeaveAllocationDtoValidator : AbstractValidator<CreateLeaveAllocationDto>
{
    public CreateLeaveAllocationDtoValidator()
    {
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
            .NotNull().WithMessage("{PropertyName} cannot be Null");

    }
}
