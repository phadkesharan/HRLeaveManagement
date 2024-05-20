using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveRequest.Validators;
using HRLeaveManagement.Application.Feature.LeaveRequests.Requests.Commands;
using HRLeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HRLeaveManagement.Application.Feature.LeaveRequests.Handlers.Commands;

public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;

    public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper) 
    {
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;   
    }

    public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        UpdateLeaveRequestDtoValidator validator = new(_leaveRequestRepository);
        var validationResult = await validator.ValidateAsync(request.leaveRequestDto, cancellationToken);

        if(validationResult.IsValid == false)
        {
            throw new Exception();
        }

        var leaveRequest = await _leaveRequestRepository.Get(request.Id);

        if(request.leaveRequestDto != null)
        {
            _mapper.Map(request.leaveRequestDto, leaveRequest);
            await _leaveRequestRepository.Update(leaveRequest);
        }

        else if(request.changeLeaveRequestApprovalDto != null)
        {
            await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest, request.changeLeaveRequestApprovalDto.Approved);
        }


        return Unit.Value;
    }
}
