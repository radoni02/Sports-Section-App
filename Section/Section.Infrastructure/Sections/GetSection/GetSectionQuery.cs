using Section.Application.Abstractions.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section.Infrastructure.Sections.GetSection;

public record GetSectionQuery(Guid Id) : IQuery<GetSectionResponse> { }
