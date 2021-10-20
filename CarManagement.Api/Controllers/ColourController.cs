using System.Collections.Generic;
using System.Threading.Tasks;
using CarManagement.Application.Features.Colours.Commands.AddColour;
using CarManagement.Application.Features.Colours.Commands.DeleteColour;
using CarManagement.Application.Features.Colours.Commands.EditColour;
using CarManagement.Application.Features.Colours.Queries.GetColourDetail;
using CarManagement.Application.Features.Colours.Queries.GetColoursList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColourController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ColourController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllColours")]
        public async Task<ActionResult<List<ColourInListViewModel>>> GetAllColours()
        {
            var list = await _mediator.Send(new GetColoursListQuery());
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetColourById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ColourDetailViewModel>> GetColourById(int id)
        {
            var detailViewModel = await _mediator.Send(new GetColourDetailQuery() {Id = id});

            return Ok(detailViewModel);
        }

        [HttpPost(Name = "AddColour")]
        public async Task<ActionResult<int>> Create([FromBody] CreateColourCommand createColourCommand)
        {
            var result = await _mediator.Send(createColourCommand);

            return Ok(result.ColourId);
        }

        [HttpPut(Name = "UpdateColour")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateColourCommand updateColourCommand)
        {
            await _mediator.Send(updateColourCommand);
            return NoContent();
        }

        [HttpDelete(Name = "DeleteColour")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteColour(int id)
        {
            var deleteColourCommand = new DeleteColourCommand() {ColourId = id};
            await _mediator.Send(deleteColourCommand);
            return NoContent();
        }
    }
}