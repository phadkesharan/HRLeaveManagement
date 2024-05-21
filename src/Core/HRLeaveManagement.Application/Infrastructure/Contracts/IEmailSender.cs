using HRLeaveManagement.Application.Models;

namespace HRLeaveManagement.Application.Infrastructure.Contracts;

public interface IEmailSender
{
    Task<bool> SendEmail(Email email);
}
