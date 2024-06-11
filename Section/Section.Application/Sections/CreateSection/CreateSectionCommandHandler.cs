using Section.Application.Abstractions.CQRS;
using Section.Application.Abstractions.Messaging;
using Section.Application.Abstractions.Messaging.Messages;
using Section.Domain.Abstractions;
using Section.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section.Application.Sections.CreateSection;

internal sealed class CreateSectionCommandHandler : ICommandHandler<CreateSectionCommand>
{
    private readonly ISectionRepository _sectionRepository;
    private readonly IMessageSender _messageSender;

    public CreateSectionCommandHandler(ISectionRepository sectionRepository, IMessageSender messageSender)
    {
        _sectionRepository = sectionRepository;
        _messageSender = messageSender;
    }

    public async Task<Result> Handle(CreateSectionCommand request, CancellationToken cancellationToken)
    {
        var section = Section.Domain.Models.Section.CreateSection(request.Name,request.Descritpion,request.IsSport,request.Day,request.Time,request.LimitOfPlaces);
        await _sectionRepository.AddSection(section);
        _messageSender.SendMessage(new AddSection(section.TeacherId));
        //SendMessage should be inside UnitOfWork.SaveChanges
        return Result.Success();
    }
}
