using FluentValidation;
using HRLeaveManagement.Application.DTOs.LeaveType;

namespace HRLeaveManagement.Application;

public class UpdateLeaveTypeDtoValidator : AbstractValidator<LeaveTypeDto>
{
    public UpdateLeaveTypeDtoValidator()
    {
        Include(new ILeaveTypeDtoValidator());

        RuleFor(p => p.Id)
            .NotNull();
    }
}
