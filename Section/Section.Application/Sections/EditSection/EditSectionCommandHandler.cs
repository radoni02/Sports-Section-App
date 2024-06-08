using Section.Application.Abstractions.CQRS;
using Section.Domain.Abstractions;
using Section.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section.Application.Sections.EditSection
{
    internal sealed class EditSectionCommandHandler : ICommandHandler<EditSectionCommand>
    {
        private readonly ISectionRepository _sectionRepository;

        public EditSectionCommandHandler(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public async Task<Result> Handle(EditSectionCommand request, CancellationToken cancellationToken)
        {
            var section = await _sectionRepository.GetSection(request.Id);
            if(section is null)
            {
                throw new Exception();
            }
            section.UpdateSection(request.Name, request.Descritpion, request.Day, request.Time, request.LimitOfPlaces,request.TeacherId);
            await _sectionRepository.EditSection(section);
            return Result.Success();
        }
    }
}
