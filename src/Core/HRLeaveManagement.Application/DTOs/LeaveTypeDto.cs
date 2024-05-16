using HRLeaveManagement.Application.DTOs.Common;

namespace HRLeaveManagement.Application.DTOs;

public class LeaveTypeDto : BaseDto
{
    public string Name { get; set; } = string.Empty;

    public int DefaultDays { get; set; }

}
