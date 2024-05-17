﻿using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveAllocation.Validator;
using HRLeaveManagement.Application.Feature.LeaveAllocations.Requests.Commands;
using HRLeaveManagement.Application.Persistence.Contracts;
using HRLeaveManagement.Domain;
using MediatR;

namespace HRLeaveManagement.Application.Feature.LeaveAllocations.Handlers.Commands;

public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        CreateLeaveAllocationDtoValidator validator = new();
        var validationResult = await validator.ValidateAsync(request.leaveAllocationDto, cancellationToken);

        var leaveAllocation = _mapper.Map<LeaveAllocation>(request.leaveAllocationDto);
        leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);

        return leaveAllocation.Id;
    }
}
