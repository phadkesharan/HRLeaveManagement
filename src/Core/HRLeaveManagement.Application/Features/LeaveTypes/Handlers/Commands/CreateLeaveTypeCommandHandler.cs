using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveType.Validators;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Feature.LeaveTypes.Requests.Commands;
using HRLeaveManagement.Application.Persistence.Contracts;
using HRLeaveManagement.Domain;
using MediatR;

namespace HRLeaveManagement.Application.Feature.LeaveTypes.Handlers.Commands;


public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;
    
    public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
        _leaveTypeRepository =  leaveTypeRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        CreateLeaveTypeDtoValidator validator = new();
        var validationResult = await validator.ValidateAsync(request.leaveTypeDto, cancellationToken);

        if(validationResult.IsValid == false)
        {
            throw new ValidationException(validationResult);
        }

        var leaveType = _mapper.Map<LeaveType>(request.leaveTypeDto);
        leaveType = await _leaveTypeRepository.Add(leaveType);

        return leaveType.Id;
    }
}
