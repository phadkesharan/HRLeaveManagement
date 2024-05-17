﻿using HRLeaveManagement.Application.DTOs.Common;
using HRLeaveManagement.Application.DTOs.LeaveType;

namespace HRLeaveManagement.Application.DTOs.LeaveRequest;

public class LeaveRequestDto : BaseDto, ILeaveRequestDto
{
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public LeaveTypeDto LeaveType { get; set; }    

    public int LeaveTypeId { get; set; }

    public DateTime DateRequested { get; set; }

    public string RequestComments { get; set; } = string.Empty;

    public DateTime? DateActioned { get; set; }

    public bool? Approved { get; set; }

    public bool Cancelled { get; set; }

}
