using Microsoft.EntityFrameworkCore;
using Section.Application.Abstractions.CQRS;
using Section.Domain.Abstractions;
using Section.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section.Infrastructure.Sections.GetSection
{
    internal sealed class GetSectionQueryHandler : IQueryHandler<GetSectionQuery, GetSectionResponse>
    {
        private readonly DbSet<Section.Domain.Models.Section> _sections;

        public GetSectionQueryHandler(ApplicationDbContext context)
        {
            _sections = context.sections;
        }

        public async Task<Result<GetSectionResponse>> Handle(GetSectionQuery request, CancellationToken cancellationToken)
        {
            var section = await _sections.FirstOrDefaultAsync(s => s.Id == request.Id);
            if(section is null)
            {
                throw new Exception();
            }
            //here send message to identity to feach teacher name and lastname
            var sectionResponse = new GetSectionResponse()
            {
                Name = section.Name,
                Description = section.Description,
                IsSport = section.IsSport,
                Day = section.Day,
                Time = section.Time
            };
            return Result.Create(sectionResponse);
        }
    }
}
