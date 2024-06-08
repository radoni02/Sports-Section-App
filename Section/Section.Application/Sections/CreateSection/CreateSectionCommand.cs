using Section.Application.Abstractions.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section.Application.Sections.CreateSection;

public record CreateSectionCommand(
    string Name,
    string? Descritpion,
    bool IsSport,
    DayOfWeek Day,
    TimeOnly Time,
    Guid TeacherId,
    int LimitOfPlaces) : ICommand;

