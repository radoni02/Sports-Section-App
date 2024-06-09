using MediatR;
using Microsoft.EntityFrameworkCore;
using Section.Application.Abstractions.CQRS;
using Section.Domain.Abstractions;
using Section.Infrastructure.Database;
using Section.Infrastructure.Sections.GetSection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section.Infrastructure.Sections.GetAllSections
{
    internal sealed class GetAllSectionsQueryHandler : IQueryHandler<GetAllSectionsQuery, IEnumerable<GetSectionResponse>>
    {
        private readonly DbSet<Section.Domain.Models.Section> _sections;

        public GetAllSectionsQueryHandler(ApplicationDbContext context)
        {
            _sections = context.sections;
        }
        public async Task<Result<IEnumerable<GetSectionResponse>>> Handle(GetAllSectionsQuery request, CancellationToken cancellationToken)
        {
            var sections = await _sections.ToListAsync();
            var sectionsResponse = sections.Select(s => new GetSectionResponse()
            {
                Name = s.Name,
                Description = s.Description,
                IsSport = s.IsSport,
                Day = s.Day,
                LimitOfPlaces = s.LimitOfPlaces,
                Time = s.Time
            });

            return Result.Create(sectionsResponse);
        }

    }
}
