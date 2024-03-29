using BuberDinner.Application.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infraestructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private static List<User> _users = new List<User>();

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return _users
                .SingleOrDefault(user => user.Email == email);
        }
    }
}