using BuberDinner.Application.Common.Services;

namespace BuberDinner.Infraestructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
