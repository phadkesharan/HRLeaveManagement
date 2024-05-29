using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveRequest.Validators;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Feature.LeaveRequests.Requests.Commands;
using HRLeaveManagement.Application.Infrastructure.Contracts;
using HRLeaveManagement.Application.Models;
using HRLeaveManagement.Application.Persistence.Contracts;
using HRLeaveManagement.Application.Responses;
using HRLeaveManagement.Domain;
using MediatR;

namespace HRLeaveManagement.Application.Feature.LeaveRequests.Handlers.Commands;

public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    private readonly IMapper _mapper;
    private readonly IEmailSender _emailSender;

    public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper, IEmailSender emailSender)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
        _emailSender = emailSender;
    }

    // Sending Appropriate Response
    public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        BaseCommandResponse response = new();

        CreateLeaveRequestDtoValidator validator = new(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request.leaveRequestDto, cancellationToken);

        if(validationResult.IsValid == false)
        {
            /// Throwing Exception 
            // throw new ValidationException(validationResult);

            /// Alternative : sending appropriate error response
            response.Success = false;
            response.Message = $"{nameof(CreateLeaveRequestCommand)} Failed";
            response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
        } 

        var leaveRequest = _mapper.Map<LeaveRequest>(request.leaveRequestDto);
        leaveRequest = await _leaveRequestRepository.Add(leaveRequest);

        response.Success = true;
        response.Message = $"{nameof(CreateLeaveRequestCommand)} Successfull";
        response.Id = leaveRequest.Id;

        var email = new Email
        {
            To = "dummyTo@gmail.com",
            Subject = "Request for leave",
            Body = $"Leave request from {request.leaveRequestDto.StartDate} to {request.leaveRequestDto.EndDate} has been send successfully!",
        };

        try
        {
            var emailSendResponse = await _emailSender.SendEmail(email);
        }
        catch (Exception)
        {
            //Handle Failed Email
        }


        return response;
    }
}
