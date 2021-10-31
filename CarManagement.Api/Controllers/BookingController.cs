using System.Collections.Generic;
using System.Threading.Tasks;
using CarManagement.Application.Features.Bookings.Commands.CreateBooking;
using CarManagement.Application.Features.Bookings.Commands.DeleteBooking;
using CarManagement.Application.Features.Bookings.Commands.UpdateBooking;
using CarManagement.Application.Features.Bookings.Queries.GetBookingDetail;
using CarManagement.Application.Features.Bookings.Queries.GetBookingsList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllBookings")]
        public async Task<ActionResult<List<BookingInListViewModel>>> GetAllBookings()
        {
            var list = await _mediator.Send(new GetBookingsListQuery());
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetBookingById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BookingDetailViewModel>> GetBookingById(int id)
        {
            var detailViewModel = await _mediator.Send(new GetBookingDetailQuery() {Id = id});

            return Ok(detailViewModel);
        }

        [HttpPost(Name = "AddBooking")]
        public async Task<ActionResult<int>> Create([FromBody] CreateBookingCommand createBookingCommand)
        {
            var result = await _mediator.Send(createBookingCommand);

            return Ok(result.BookingId);
        }

        [HttpPut(Name = "UpdateBooking")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateBookingCommand updateBookingCommand)
        {
            await _mediator.Send(updateBookingCommand);
            return NoContent();
        }

        [HttpDelete(Name = "DeleteBooking")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteBooking(int id)
        {
            var deleteBookingCommand = new DeleteBookingCommand() {BookingId = id};
            await _mediator.Send(deleteBookingCommand);
            return NoContent();
        }
        
        [HttpGet("export", Name = "ExportBookings")]
        public async Task<FileResult> ExportBookings()
        {
            var fileDto = await _mediator.Send(new GetBookingsExportQuery());

            return File(fileDto.Data, fileDto.ContentType, fileDto.BookingExportFileName);
        }
    }
}