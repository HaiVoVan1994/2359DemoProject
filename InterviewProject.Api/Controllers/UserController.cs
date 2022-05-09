using InterviewProject.Application.UserFeature;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InterviewProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public UserController(IMediator mediator, ILogger<UserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody] RegisterCommand request) {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
