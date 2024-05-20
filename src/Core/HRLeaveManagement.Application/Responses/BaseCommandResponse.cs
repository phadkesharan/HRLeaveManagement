namespace HRLeaveManagement.Application.Responses;

public class BaseCommandResponse
{
    public int Id { get; set; }
    public bool Success { get; set;}

    public string Message {get; set;} = string.Empty;

    public List<string> Errors {get; set;} = [];
}
