using System.Collections.Generic;
using System.Threading.Tasks;
using CarManagement.Application.Features.Vehicles.Commands.AddVehicle;
using CarManagement.Application.Features.Vehicles.Commands.DeleteVehicle;
using CarManagement.Application.Features.Vehicles.Commands.EditVehicle;
using CarManagement.Application.Features.Vehicles.Queries.GetVehicleDetail;
using CarManagement.Application.Features.Vehicles.Queries.GetVehiclesList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehicleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllVehicles")]
        public async Task<ActionResult<List<VehicleInListViewModel>>> GetAllVehicles()
        {
            var list = await _mediator.Send(new GetVehiclesListQuery());
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetVehicleById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<VehicleDetailViewModel>> GetVehicleById(int id)
        {
            var detailViewModel = await _mediator.Send(new GetVehicleDetailQuery() {Id = id});

            return Ok(detailViewModel);
        }

        [HttpPost(Name = "AddVehicle")]
        public async Task<ActionResult<int>> Create([FromBody] CreateVehicleCommand createVehicleCommand)
        {
            var result = await _mediator.Send(createVehicleCommand);

            return Ok(result.VehicleId);
        }

        [HttpPut(Name = "UpdateVehicle")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateVehicleCommand updateVehicleCommand)
        {
            await _mediator.Send(updateVehicleCommand);
            return NoContent();
        }

        [HttpDelete(Name = "DeleteVehicle")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteVehicle(int id)
        {
            var deleteVehicleCommand = new DeleteVehicleCommand() {VehicleId = id};
            await _mediator.Send(deleteVehicleCommand);
            return NoContent();
        }
        
        [HttpGet("export", Name = "ExportVehicles")]
        public async Task<FileResult> ExportVehicles()
        {
            var fileDto = await _mediator.Send(new GetVehiclesExportQuery());

            return File(fileDto.Data, fileDto.ContentType, fileDto.VehicleExportFileName);
        }
    }
}