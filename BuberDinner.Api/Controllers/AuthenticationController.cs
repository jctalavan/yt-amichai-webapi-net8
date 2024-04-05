using BuberDinner.Application.Services.Authentication.Commands.Register;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Application.Services.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/auth")]
    public class AuthenticationController(IMediator mediator, IMapper mapper) : ApiController
    {
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            RegisterCommand command = _mapper.Map<RegisterCommand>(request);

            ErrorOr<AuthenticationResult> authenticationResult = await _mediator.Send(command);

            return authenticationResult.Match(
                onValue: result => Ok(_mapper.Map<AuthenticationResponse>(result)),
                onError: errors => Problem(errors));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            LoginQuery query = _mapper.Map<LoginQuery>(request);

            ErrorOr<AuthenticationResult> authenticationResult = await _mediator.Send(query);

            return authenticationResult.Match(
                onValue: result => Ok(_mapper.Map<AuthenticationResponse>(result)),
                onError: errors => Problem(errors));
        }
    }
}
