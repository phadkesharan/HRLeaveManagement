using FluentValidation;
using HRLeaveManagement.Application.Persistence.Contracts;

namespace HRLeaveManagement.Application.DTOs.LeaveRequest.Validators;

public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;

    public CreateLeaveRequestDtoValidator(ILeaveRequestRepository leaveAllocationRepository)
    {
        _leaveRequestRepository = leaveAllocationRepository;

        RuleFor(p => p.StartDate)
            .LessThan(p => p.EndDate);

        RuleFor(p => p.EndDate)
            .GreaterThan(p => p.StartDate);

        RuleFor(p =>p.LeaveTypeId)
            .NotNull().WithMessage("{PropertyName} cannot be Null")
            .GreaterThan(0)
            .MustAsync(async (id, token) => {
                var leaveAllocationExists = await _leaveRequestRepository.Exists(id);
                return !leaveAllocationExists;                
            });

        
    }
}
