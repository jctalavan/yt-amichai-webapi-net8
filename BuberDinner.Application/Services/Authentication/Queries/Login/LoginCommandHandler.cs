using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Persistence;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Domain.Entities;
using BuberDinner.Domain.Errors;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Services.Authentication.Queries.Login
{
    public class LoginCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository) : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<ErrorOr<AuthenticationResult>> Handle(
            LoginQuery request,
            CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            //1. Validar que el usuario existe
            if (_userRepository.GetUserByEmail(request.Email) is not User user)
                return Errors.Authentication.Login.InvalidUser;

            //2. Comprobar que el password es correcto
            if (user.Password != request.Password)
                return Errors.Authentication.Login.InvalidPassword;

            //3. Crear JWT Token
            string jwtToken = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                jwtToken);
        }
    }
}
