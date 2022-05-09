using InterviewProject.Application.ProductFeature;
using InterviewProject.Application.UserFeature;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InterviewProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public ProductController(IMediator mediator, ILogger<UserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [HttpGet("SearchProduct"), Authorize]
        public async Task<ActionResult> SearchProduct([FromQuery] SearchProductQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("CreateProduct"), Authorize(Policy = "Administrator")]
        public async Task<ActionResult> CreateProduct([FromForm] CreateProductCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
