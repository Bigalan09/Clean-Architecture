using CleanArchitecture.Application.Common;

namespace CleanArchitecture.Infrastructure.Services;
internal class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.UtcNow;
}
