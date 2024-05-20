using AutoMapper;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Feature.LeaveTypes.Requests.Commands;
using HRLeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HRLeaveManagement.Application;

public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        UpdateLeaveTypeDtoValidator validator = new();
        var validationResult = await validator.ValidateAsync(request.leaveTypeDto, cancellationToken);

        if(validationResult.IsValid == false)
        {
            throw new ValidationException(validationResult);
        }

        var leaveType = await _leaveTypeRepository.Get(request.leaveTypeDto.Id);
        _mapper.Map(request.leaveTypeDto, leaveType);

        await _leaveTypeRepository.Update(leaveType);
        return Unit.Value;
    }
}
