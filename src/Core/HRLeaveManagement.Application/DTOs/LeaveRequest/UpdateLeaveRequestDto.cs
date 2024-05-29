﻿using HRLeaveManagement.Application.DTOs.Common;

namespace HRLeaveManagement.Application.DTOs.LeaveRequest;

public class UpdateLeaveRequestDto : BaseDto, ILeaveRequestDto
{
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int LeaveTypeId { get; set; }

    public string RequestComments { get; set; } = string.Empty;

    public bool Cancelled { get; set; }
}
