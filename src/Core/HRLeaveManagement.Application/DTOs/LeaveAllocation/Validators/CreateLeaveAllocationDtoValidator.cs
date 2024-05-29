﻿using FluentValidation;
using HRLeaveManagement.Application.Persistence.Contracts;

namespace HRLeaveManagement.Application.DTOs.LeaveAllocation.Validator;

public class CreateLeaveAllocationDtoValidator : AbstractValidator<CreateLeaveAllocationDto>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    

    public CreateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
        Include(new ILeaveAllocationDtoValidator(_leaveTypeRepository));
    }
}
