using FluentValidation;
using HRLeaveManagement.Application.Persistence.Contracts;

namespace HRLeaveManagement.Application.DTOs.LeaveRequest.Validators;

public class UpdateLeaveRequestDtoValidator : AbstractValidator<UpdateLeaveRequestDto>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public UpdateLeaveRequestDtoValidator(ILeaveRequestRepository leaveRequestRepository)
    {
        _leaveRequestRepository = leaveRequestRepository;
        Include(new ILeaveRequestDtoValidator(leaveRequestRepository));

        RuleFor(p => p.Id).NotNull();
    }
}
