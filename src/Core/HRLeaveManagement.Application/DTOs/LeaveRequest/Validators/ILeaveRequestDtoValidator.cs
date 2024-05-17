using FluentValidation;
using HRLeaveManagement.Application.Persistence.Contracts;

namespace HRLeaveManagement.Application.DTOs.LeaveRequest.Validators;  

public class ILeaveRequestDtoValidator : AbstractValidator<ILeaveRequestDto>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public ILeaveRequestDtoValidator(ILeaveRequestRepository leaveRequestRepository)
    {
        _leaveRequestRepository = leaveRequestRepository;

        RuleFor(p => p.StartDate)
            .LessThan(p => p.EndDate);

        RuleFor(p => p.EndDate)
            .GreaterThan(p => p.StartDate);

        RuleFor(p =>p.LeaveTypeId)
            .NotNull().WithMessage("{PropertyName} cannot be Null")
            .GreaterThan(0)
            .MustAsync(async (id, token) => {
                var leaveRequestExists = await _leaveRequestRepository.Exists(id);
                return !leaveRequestExists;                
            });
    }
}
