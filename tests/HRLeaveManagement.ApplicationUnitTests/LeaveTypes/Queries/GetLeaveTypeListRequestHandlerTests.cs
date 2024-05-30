using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveType;
using HRLeaveManagement.Application.Feature.LeaveTypes.Handlers.Queries;
using HRLeaveManagement.Application.Feature.LeaveTypes.Requests.Queries;
using HRLeaveManagement.Application.Persistence.Contracts;
using HRLeaveManagement.Application.Profiles;
using Moq;
using Shouldly;

namespace HRLeaveManagement.ApplicationUnitTests;

public class GetLeaveTypeListRequestHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<ILeaveTypeRepository> _leaveTypeMockRepo;

    public GetLeaveTypeListRequestHandlerTests()
    {
        _leaveTypeMockRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();

        var mappingConfig = new MapperConfiguration(c => c.AddProfile<MappingProfile>());
        _mapper = mappingConfig.CreateMapper();

    }

    [Fact]
    public async Task GetLeaveTypeListRequestHandler_should_return_list_of_leavetypeDto()
    {
        var handler = new GetLeaveTypeListRequestHandler(_leaveTypeMockRepo.Object, _mapper);

        var result = await handler.Handle(new GetLeaveTypeListRequest(), CancellationToken.None);

        result.ShouldBeOfType<List<LeaveTypeDto>>();
        result.ShouldNotBeNull();
        result.Count.ShouldBe(2);
    }
}
