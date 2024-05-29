using FluentValidation;
using HRLeaveManagement.Application.DTOs.LeaveRequest;

namespace HRLeaveManagement.Application;

public class ChangeLeaveRequestApprovalDtoValidator : AbstractValidator<ChangeLeaveRequestApprovalDto>
{
    public ChangeLeaveRequestApprovalDtoValidator()
    {
        RuleFor(p => p.Approved)
            .NotNull();
    }
}
