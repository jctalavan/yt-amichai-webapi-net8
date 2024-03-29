using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Persistence;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Domain.Entities;
using MediatR;

namespace BuberDinner.Application.Services.Authentication.Commands.Register
{
    public class RegisterCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository) : IRequestHandler<RegisterCommand, AuthenticationResult>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<AuthenticationResult> Handle(
            RegisterCommand request,
            CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            //1. Validar que el usuario no existe
            if (_userRepository.GetUserByEmail(request.Email) is not null)
                throw new Exception("Ya existe un usuario con este email");

            //2. Crear el usuario (with unique ID) & Guardar BD
            User user = new()
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password,
            };

            _userRepository.Add(user);

            //3. Crear JWT Token
            string jwtToken = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                jwtToken);
        }
    }
}
