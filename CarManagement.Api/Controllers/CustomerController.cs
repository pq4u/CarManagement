using System.Collections.Generic;
using System.Threading.Tasks;
using CarManagement.Application.Features.Customers.Commands.AddCustomer;
using CarManagement.Application.Features.Customers.Commands.DeleteCustomer;
using CarManagement.Application.Features.Customers.Commands.EditCustomer;
using CarManagement.Application.Features.Customers.Queries.GetCustomerDetail;
using CarManagement.Application.Features.Customers.Queries.GetCustomersExport;
using CarManagement.Application.Features.Customers.Queries.GetCustomersList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllCustomers")]
        public async Task<ActionResult<List<CustomerInListViewModel>>> GetAllCustomers()
        {
            var list = await _mediator.Send(new GetCustomersListQuery());
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetCustomerById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<CustomerDetailViewModel>> GetCustomerById(int id)
        {
            var detailViewModel = await _mediator.Send(new GetCustomerDetailQuery() {Id = id});

            return Ok(detailViewModel);
        }

        [HttpPost(Name = "AddCustomer")]
        public async Task<ActionResult<int>> Create([FromBody] CreateCustomerCommand createCustomerCommand)
        {
            var result = await _mediator.Send(createCustomerCommand);

            return Ok(result.CustomerId);
        }

        [HttpPut(Name = "UpdateCustomer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateCustomerCommand updateCustomerCommand)
        {
            await _mediator.Send(updateCustomerCommand);
            return NoContent();
        }

        [HttpDelete(Name = "DeleteCustomer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            var deleteCustomerCommand = new DeleteCustomerCommand() {CustomerId = id};
            await _mediator.Send(deleteCustomerCommand);
            return NoContent();
        }
        
        [HttpGet("export", Name = "ExportCustomers")]
        public async Task<FileResult> ExportCustomers()
        {
            var fileDto = await _mediator.Send(new GetCustomersExportQuery());

            return File(fileDto.Data, fileDto.ContentType, fileDto.CustomerExportFileName);
        }
    }
}