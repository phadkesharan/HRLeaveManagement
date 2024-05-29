using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveRequest.Validators;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Feature.LeaveRequests.Requests.Commands;
using HRLeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HRLeaveManagement.Application.Feature.LeaveRequests.Handlers.Commands;

public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    private readonly IMapper _mapper;

    public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper) 
    {
        _leaveRequestRepository = leaveRequestRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;   
    }

    public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        UpdateLeaveRequestDtoValidator validator = new(_leaveTypeRepository);
        ChangeLeaveRequestApprovalDtoValidator leaveApprovalValidator = new();

        var leaveRequest = await _leaveRequestRepository.Get(request.Id);

        if(request.leaveRequestDto != null)
        {
            var validationResult = await validator.ValidateAsync(request.leaveRequestDto, cancellationToken);

            if(validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }

            _mapper.Map(request.leaveRequestDto, leaveRequest);
            await _leaveRequestRepository.Update(leaveRequest);
        }

        else if(request.changeLeaveRequestApprovalDto != null)
        {
            var validationResult = await leaveApprovalValidator.ValidateAsync(request.changeLeaveRequestApprovalDto);

            if(validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }

            await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest, request.changeLeaveRequestApprovalDto.Approved);
        }


        return Unit.Value;
    }
}
