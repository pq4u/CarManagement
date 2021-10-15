using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace CarManagement.Application
{
    public class ValidationException : ApplicationException
    {
        public List<string> ErrorMessages { get; set; }

        public ValidationException(ValidationResult validationResult)
        {
            ErrorMessages = new List<string>();
            foreach (var item in validationResult.Errors)
            {
                ErrorMessages.Add(item.ErrorMessage);
            }
        }
    }
}