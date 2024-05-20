using AutoMapper;
using HRLeaveManagement.Application.Feature.LeaveAllocations.Requests.Commands;
using HRLeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HRLeaveManagement.Application.Feature.LeaveAllocations.Handlers.Commands;

public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        UpdateLeaveAllocationDtoValidator validator = new(_leaveAllocationRepository);
        var validationResult = await validator.ValidateAsync(request.leaveAllocationDto, cancellationToken);

        if(validationResult.IsValid == false)
        {
            throw new Exception();
        } 

        var leaveAllocation = await _leaveAllocationRepository.Get(request.leaveAllocationDto.Id);
        _mapper.Map(request.leaveAllocationDto, leaveAllocation);

        await _leaveAllocationRepository.Update(leaveAllocation);
        return Unit.Value;
    }
}
