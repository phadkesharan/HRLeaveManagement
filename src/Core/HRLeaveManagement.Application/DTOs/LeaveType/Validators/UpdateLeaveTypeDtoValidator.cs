using FluentValidation;

namespace HRLeaveManagement.Application;

public class UpdateLeaveTypeDtoValidator : AbstractValidator<UpdateLeaveTypeDto>
{
    public UpdateLeaveTypeDtoValidator()
    {
        Include(new ILeaveTypeDtoValidator());

        RuleFor(p => p.Id)
            .NotNull();
    }
}
