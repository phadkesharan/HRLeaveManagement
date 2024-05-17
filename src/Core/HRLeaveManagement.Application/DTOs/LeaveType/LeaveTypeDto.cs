using HRLeaveManagement.Application.DTOs.Common;

namespace HRLeaveManagement.Application.DTOs.LeaveType;

public class LeaveTypeDto : BaseDto, ILeaveTypeDto
{
    public string Name { get; set; } = string.Empty;

    public int DefaultDays { get; set; }

}
