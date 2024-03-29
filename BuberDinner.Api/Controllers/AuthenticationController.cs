using BuberDinner.Application.Services.Authentication.Commands.Register;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Application.Services.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BuberDinner.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController(IMediator mediator, IMapper mapper)
        : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            RegisterCommand command = _mapper.Map<RegisterCommand>(request);

            AuthenticationResult authenticationResult = await _mediator.Send(command);

            AuthenticationResponse authenticationResponse = _mapper.Map<AuthenticationResponse>(authenticationResult);

            return Ok(authenticationResponse);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            LoginQuery query = _mapper.Map<LoginQuery>(request);

            AuthenticationResult authenticationResult = await _mediator.Send(query);

            AuthenticationResponse authenticationResponse = _mapper.Map<AuthenticationResponse>(authenticationResult);

            return Ok(authenticationResponse);
        }
    }
}
