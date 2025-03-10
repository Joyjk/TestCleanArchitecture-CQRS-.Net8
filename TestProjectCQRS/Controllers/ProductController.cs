using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Application.Command.ProductCommand;
using Test.Application.DTO;
using Test.Application.Query.ProductQuery;

namespace TestProjectCQRS.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> SaveProduct(ProductDTO product)
        {
            var data = await _mediator.Send(new CreateProductCommand() { Model = product });
            return Ok(data);
        }
        [HttpPut("{OldProductName}")]
        public async Task<IActionResult> UpdateProduct(ProductDTO product, string OldProductName)
        {
            var data = await _mediator.Send(new UpdateProductCommand() { OldProductName = OldProductName, Model = product });
            return Ok(data);
        }
        [HttpDelete("{ProductName}")]
        public async Task<IActionResult> DeleteProduct(string ProductName)
        {
            await _mediator.Send(new DeleteProductCommand() { ProductName = ProductName });
            return NoContent();
        }
        [HttpGet("{ProductName}")]
        public async Task<IActionResult> GetProductSearch(string ProductName)
        {
            var data = await _mediator.Send(new GetProductSearchByNameQuery() { ProductName = ProductName });
            return Ok(data);
        }
        [HttpGet("{ProductName}")]
        public async Task<IActionResult> GetProductByName(string ProductName)
        {
            var data = await _mediator.Send(new GetProductbyNameQuery() { ProductName = ProductName });
            return Ok(data);
        }
    }
}
