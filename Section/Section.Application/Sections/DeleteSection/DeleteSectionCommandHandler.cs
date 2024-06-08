using Section.Application.Abstractions.CQRS;
using Section.Domain.Abstractions;
using Section.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section.Application.Sections.DeleteSection;

internal sealed class DeleteSectionCommandHandler : ICommandHandler<DeleteSectionCommand>
{
    private readonly ISectionRepository _sectionRepository;

    public DeleteSectionCommandHandler(ISectionRepository sectionRepository)
    {
        _sectionRepository = sectionRepository;
    }

    public async Task<Result> Handle(DeleteSectionCommand request, CancellationToken cancellationToken)
    {
        var section = await _sectionRepository.GetSection(request.Id);
        if (section is null)
        {
            throw new Exception();
        }
        await _sectionRepository.DeleteSection(section);
        return Result.Success();
    }
}
