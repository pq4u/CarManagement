using System.Collections.Generic;
using System.Threading.Tasks;
using CarManagement.Application.Features.Brands.Commands.CreateBrand;
using CarManagement.Application.Features.Brands.Commands.DeleteBrand;
using CarManagement.Application.Features.Brands.Commands.EditBrand;
using CarManagement.Application.Features.Brands.Queries.GetBrandDetail;
using CarManagement.Application.Features.Brands.Queries.GetBrandsExport;
using CarManagement.Application.Features.Brands.Queries.GetBrandsList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllBrands")]
        public async Task<ActionResult<List<BrandInListViewModel>>> GetAllBrands()
        {
            var list = await _mediator.Send(new GetBrandsListQuery());
            return Ok(list);
        }

        [HttpGet("{id}", Name = "GetBrandById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BrandDetailViewModel>> GetBrandById(int id)
        {
            var detailViewModel = await _mediator.Send(new GetBrandDetailQuery() {Id = id});

            return Ok(detailViewModel);
        }

        [HttpPost(Name = "AddBrand")]
        public async Task<ActionResult<int>> Create([FromBody] CreateBrandCommand createBrandCommand)
        {
            var result = await _mediator.Send(createBrandCommand);

            return Ok(result.BrandId);
        }

        [HttpPut(Name = "UpdateBrand")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateBrandCommand updateBrandCommand)
        {
            await _mediator.Send(updateBrandCommand);
            return NoContent();
        }

        [HttpDelete(Name = "DeleteBrand")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteBrand(int id)
        {
            var deleteBrandCommand = new DeleteBrandCommand() {BrandId = id};
            await _mediator.Send(deleteBrandCommand);
            return NoContent();
        }
        
        [HttpGet("export", Name = "ExportBrands")]
        public async Task<FileResult> ExportEvents()
        {
            var fileDto = await _mediator.Send(new GetBrandsExportQuery());

            return File(fileDto.Data, fileDto.ContentType, fileDto.BrandExportFileName);
        }
    }
}