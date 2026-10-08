using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FIESTA_Backend.Converters
{
    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyConverter() : base(
                dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
                dateTime => DateOnly.FromDateTime(dateTime))
        {
        }
    }
}
