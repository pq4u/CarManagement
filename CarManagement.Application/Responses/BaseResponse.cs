using System.Collections.Generic;
using FluentValidation.Results;

namespace CarManagement.Application.Responses
{
    public class BaseResponse
    {
        public BaseResponse Status { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }

        public BaseResponse()
        {
            ValidationErrors = new List<string>();
            Success = true;
        }

        public BaseResponse(string message = null)
        {
            ValidationErrors = new List<string>();
            Success = true;
            Message = message;
        }

        public BaseResponse(string message, bool success)
        {
            ValidationErrors = new List<string>();
            Success = success;
            Message = message;
        }

        public BaseResponse(ValidationResult validationResult)
        {
            ValidationErrors = new List<string>();
            Success = validationResult.Errors.Count < 0;
            foreach (var item in validationResult.Errors)
            {
                ValidationErrors.Add(item.ErrorMessage);
            }
        }

        public enum ResponseStatus
        {
            Success = 0,
            NotFound = 1,
            BadQueryRequest = 2,
            ValidationError = 3,
            Exception = 4,
            DataBaseError = 5,
            OtherClientApiError = 5
        }
    }
}