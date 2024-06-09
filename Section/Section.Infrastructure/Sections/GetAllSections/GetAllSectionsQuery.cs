using Section.Application.Abstractions.CQRS;
using Section.Infrastructure.Sections.GetSection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section.Infrastructure.Sections.GetAllSections;

public sealed record GetAllSectionsQuery() : IQuery<IEnumerable<GetSectionResponse>>;
