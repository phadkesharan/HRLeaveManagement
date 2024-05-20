using HRLeaveManagement.Application.DTOs.Common;

namespace HRLeaveManagement.Application;

public class UpdateLeaveTypeDto : BaseDto, ILeaveTypeDto
{
    public string Name { get; set; } = string.Empty;

    public int DefaultDays { get; set; }
}
