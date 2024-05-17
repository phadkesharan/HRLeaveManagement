using FluentValidation;

namespace HRLeaveManagement.Application;

public class ILeaveTypeDtoValidator : AbstractValidator<ILeaveTypeDto>
{
    public ILeaveTypeDtoValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} cannot be Empty")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} cannot be exceed 50 characters");

        RuleFor(p => p.DefaultDays)
            .NotEmpty().WithMessage("{PropertyName} cannot be Empty")
            .GreaterThan(0).WithMessage("{PropertyName} should be atleast 1")
            .LessThan(100).WithMessage("{PropertyName} should be less than 100");

    }
}
