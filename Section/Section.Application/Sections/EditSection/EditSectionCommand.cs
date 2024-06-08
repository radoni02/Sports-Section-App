using Section.Application.Abstractions.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section.Application.Sections.EditSection
{
    public record EditSectionCommand(
        Guid Id,
        string? Name,
    string? Descritpion,
    DayOfWeek? Day,
    TimeOnly? Time,
    Guid? TeacherId,
    int? LimitOfPlaces) : ICommand;
}
