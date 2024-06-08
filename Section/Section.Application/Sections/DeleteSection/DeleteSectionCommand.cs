using Section.Application.Abstractions.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section.Application.Sections.DeleteSection;

public record DeleteSectionCommand(Guid Id) : ICommand;
