using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section.Infrastructure.Sections.GetSection;

public sealed class GetSectionResponse //might be record
{
    public string Name { get; init; }
    public string Description { get; init; }
    public bool IsSport { get; init; }
    public DayOfWeek Day { get; init; }
    public TimeOnly Time { get; init; }
    public int LimitOfPlaces { get; init; }

    public string TeacherName { get; init; } = String.Empty;
    public string TeacherSurname { get; init; } = String.Empty;
}
