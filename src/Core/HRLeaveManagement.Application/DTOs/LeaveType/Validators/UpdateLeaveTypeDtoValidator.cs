using FluentValidation;
using HRLeaveManagement.Application.DTOs.LeaveRequest;
using HRLeaveManagement.Application.DTOs.LeaveType;

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
