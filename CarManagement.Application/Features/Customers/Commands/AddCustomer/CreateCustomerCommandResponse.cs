using CarManagement.Application.Responses;
using FluentValidation.Results;

namespace CarManagement.Application.Features.Customers.Commands.AddCustomer
{
    public class CreateCustomerCommandResponse : BaseResponse
    {
        public int? CustomerId { get; set; }

        public CreateCustomerCommandResponse() : base()
        {
        }

        public CreateCustomerCommandResponse(ValidationResult validationResult) : base(validationResult)
        {
        }

        public CreateCustomerCommandResponse(string message) : base(message)
        {
        }

        public CreateCustomerCommandResponse(string message, bool success) : base(message, success)
        {
        }

        public CreateCustomerCommandResponse(int customerId)
        {
            CustomerId = customerId;
        }
    }
}