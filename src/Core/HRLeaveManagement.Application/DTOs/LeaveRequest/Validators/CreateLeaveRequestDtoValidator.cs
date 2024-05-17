using FluentValidation;
using HRLeaveManagement.Application.Persistence.Contracts;

namespace HRLeaveManagement.Application.DTOs.LeaveRequest.Validators;

public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public CreateLeaveRequestDtoValidator(ILeaveRequestRepository leaveRequestRepository)
    {
        _leaveRequestRepository = leaveRequestRepository;
    }
}
