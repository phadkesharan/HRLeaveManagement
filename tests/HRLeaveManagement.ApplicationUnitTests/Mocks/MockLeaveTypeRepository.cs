using HRLeaveManagement.Application.Persistence.Contracts;
using HRLeaveManagement.Domain;
using Moq;

namespace HRLeaveManagement.ApplicationUnitTests;

public static class MockLeaveTypeRepository
{
    public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
    {
        var leaveTypes = new List<LeaveType>
        {
            new LeaveType 
            { 
                Id = 1,
                DefaultDays = 1,
                Name = "Test Casual"
            },

            new LeaveType
            {
                Id = 2,
                DefaultDays = 1,
                Name = "Test Paid"
            }
        };

        var mockRepo = new Mock<ILeaveTypeRepository>();

        mockRepo.Setup(r => r.GetAll()).ReturnsAsync(leaveTypes.AsReadOnly());

        mockRepo.Setup(r => r.Get(It.IsAny<int>()))
            .ReturnsAsync((int id) => leaveTypes.FirstOrDefault(t => t.Id == id));  

        mockRepo.Setup(r => r.Exists(It.IsAny<int>()))
            .ReturnsAsync((int id) => leaveTypes.Any(t => t.Id == id));

        mockRepo.Setup(r => r.Add(It.IsAny<LeaveType>())).ReturnsAsync((LeaveType leaveType) => 
        {
            leaveTypes.Add(leaveType);
            return leaveType;
        });

        
        mockRepo.Setup(r => r.Update(It.IsAny<LeaveType>()))
            .Returns((LeaveType leaveType) => 
            {
                var index = leaveTypes.IndexOf(leaveType);

                if(index != -1)
                {
                    leaveTypes[index] = leaveType;
                }

                return Task.CompletedTask;
            });

        mockRepo.Setup(r => r.Delete(It.IsAny<LeaveType>()))
            .Returns((LeaveType leaveType) => 
            {
                leaveTypes.Remove(leaveType);
                return Task.CompletedTask;
            });
        
        return mockRepo;
    }
}
