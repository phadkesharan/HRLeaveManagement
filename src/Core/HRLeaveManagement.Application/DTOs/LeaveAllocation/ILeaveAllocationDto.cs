﻿namespace HRLeaveManagement.Application;

public interface ILeaveAllocationDto
{
    public int NumberOfDays { get; set; }

    public int LeaveTypeId { get; set; }    

    public int Period  { get; set; }

}
