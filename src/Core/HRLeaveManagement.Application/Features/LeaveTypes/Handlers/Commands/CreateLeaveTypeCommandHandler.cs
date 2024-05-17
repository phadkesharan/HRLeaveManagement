using AutoMapper;
using HRLeaveManagement.Application.Feature.LeaveTypes.Requests.Commands;
using HRLeaveManagement.Application.Persistence.Contracts;
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

    public Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
