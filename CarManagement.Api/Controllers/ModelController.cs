using System.Collections.Generic;
using System.Threading.Tasks;
using CarManagement.Application.Features.Models.Commands.AddModel;
using CarManagement.Application.Features.Models.Commands.DeleteModel;
using CarManagement.Application.Features.Models.Commands.EditModel;
using CarManagement.Application.Features.Models.Queries.GetModelDetail;
using CarManagement.Application.Features.Models.Queries.GetModelsList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ModelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllModels")]
        public async Task<ActionResult<List<CarModelInListViewModel>>> GetAllModels()
        {
            var list = await _mediator.Send(new GetModelsListQuery());
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetModelById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<CarModelDetailViewModel>> GetModelById(int id)
        {
            var detailViewModel = await _mediator.Send(new GetModelDetailQuery() {Id = id});

            return Ok(detailViewModel);
        }

        [HttpPost(Name = "AddModel")]
        public async Task<ActionResult<int>> Create([FromBody] CreateModelCommand createModelCommand)
        {
            var result = await _mediator.Send(createModelCommand);

            return Ok(result.ModelId);
        }

        [HttpPut(Name = "UpdateModel")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateModelCommand updateModelCommand)
        {
            await _mediator.Send(updateModelCommand);
            return NoContent();
        }

        [HttpDelete(Name = "DeleteModel")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteModel(int id)
        {
            var deleteModelCommand = new DeleteModelCommand() {ModelId = id};
            await _mediator.Send(deleteModelCommand);
            return NoContent();
        }
    }
}