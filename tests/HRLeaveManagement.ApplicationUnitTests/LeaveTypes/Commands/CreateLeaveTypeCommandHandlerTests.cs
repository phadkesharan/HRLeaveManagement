using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveType;
using HRLeaveManagement.Application.Feature.LeaveTypes.Handlers.Commands;
using HRLeaveManagement.Application.Feature.LeaveTypes.Requests.Commands;
using HRLeaveManagement.Application.Persistence.Contracts;
using HRLeaveManagement.Application.Profiles;
using Moq;
using Shouldly;

namespace HRLeaveManagement.ApplicationUnitTests;

public class CreateLeaveTypeCommandHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<ILeaveTypeRepository> _leaveTypeMockRepo;
    private readonly CreateLeaveTypeDto _createLeaveTypeDto;

    public CreateLeaveTypeCommandHandlerTests()
    {
        _leaveTypeMockRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();

        var mappingConfig = new MapperConfiguration(c => c.AddProfile<MappingProfile>());
        _mapper = mappingConfig.CreateMapper();

        _createLeaveTypeDto = new CreateLeaveTypeDto
        {
            DefaultDays = 1,
            Name = "Test Leave"
        };

    }

    [Fact]
    public async Task CreateLeaveTypeCommandHandler_should_create_leaveType()
    {
        var handler = new CreateLeaveTypeCommandHandler(_leaveTypeMockRepo.Object, _mapper);

        var result = await handler.Handle(new CreateLeaveTypeCommand { leaveTypeDto = _createLeaveTypeDto }, CancellationToken.None);

        result.ShouldBeOfType<int>();

        var leaveTypes = await _leaveTypeMockRepo.Object.GetAll();

        leaveTypes.Count.ShouldBe(3);
    }
}
