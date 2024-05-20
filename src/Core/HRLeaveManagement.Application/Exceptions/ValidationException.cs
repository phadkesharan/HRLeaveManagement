using FluentValidation.Results;

namespace HRLeaveManagement.Application.Exceptions;


public class ValidationException : ApplicationException
{
    List<string> Errors { get; set; } = [];

    public ValidationException(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            Errors.Add(error.ErrorMessage);           
        }
    }
}
