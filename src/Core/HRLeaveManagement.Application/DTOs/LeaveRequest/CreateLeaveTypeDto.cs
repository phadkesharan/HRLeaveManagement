using HRLeaveManagement.Application.DTOs.Common;

namespace HRLeaveManagement.Application;

public class CreateLeaveTypeDto : BaseDto
{
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int LeaveTypeId { get; set; }

    public DateTime DateRequested { get; set; }

    public string RequestComments { get; set; } = string.Empty;
}
