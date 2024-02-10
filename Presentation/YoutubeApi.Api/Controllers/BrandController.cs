using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YoutubeApi.Application.Features.Brands.Commands.CreateBrand;
using YoutubeApi.Application.Features.Products.Command.DeleteProduct;

namespace YoutubeApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator mediator;

        public BrandController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrands(CreateBrandCommandRequest request)
        {
            await mediator.Send(request);

            return Ok();
        }
    }
}
