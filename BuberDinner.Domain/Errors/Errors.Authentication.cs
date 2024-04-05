using ErrorOr;

namespace BuberDinner.Domain.Errors
{
    public static partial class Errors
    {
        public static partial class Authentication
        {
            public static class Register
            {
                public static Error DuplicateEmail => Error.Validation(code: "Auth.Register.DuplicateEmail", description: "Ya existe un usuario con este email");
            }

            public static class Login
            {
                public static Error InvalidUser => Error.NotFound(code: "Auth.Login.InvalidUser", description: "No existe ningún usuario para este email.");
                public static Error InvalidPassword => Error.NotFound(code: "Auth.Login.InvalidPassword", description: "La contraseña introducida es incorrecta");
            }
        }
    }
}
