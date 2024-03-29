using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Persistence;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Domain.Entities;
using MediatR;

namespace BuberDinner.Application.Services.Authentication.Queries.Login
{
    public class LoginCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository) : IRequestHandler<LoginQuery, AuthenticationResult>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<AuthenticationResult> Handle(
            LoginQuery request,
            CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            //1. Validar que el usuario existe
            if (_userRepository.GetUserByEmail(request.Email) is not User user)
                throw new Exception("No existe ningún usuario para este email.");

            //2. Comprobar que el password es correcto
            if (user.Password != request.Password)
                throw new Exception("La contraseña introducida es incorrecta");

            //3. Crear JWT Token
            string jwtToken = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                jwtToken);
        }
    }
}
