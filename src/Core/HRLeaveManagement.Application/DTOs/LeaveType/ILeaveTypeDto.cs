namespace HRLeaveManagement.Application;

public interface ILeaveTypeDto
{
    public string Name { get; set; }

    public int DefaultDays { get; set; }

}
