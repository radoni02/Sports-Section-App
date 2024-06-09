using MediatR;
using Microsoft.AspNetCore.Mvc;
using Section.Api.Dtos;
using Section.Application.Sections.CreateSection;
using Section.Application.Sections.DeleteSection;
using Section.Application.Sections.EditSection;
using Section.Domain.Abstractions;
using Section.Infrastructure.Sections.GetAllSections;
using Section.Infrastructure.Sections.GetSection;

namespace Section.Api.Controllers;

[ApiController]
[Route("api/sections")]
public class SectionController : ControllerBase
{
    private readonly ISender _sender;

    public SectionController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSection([FromBody]CreateSectionDto section)
    {
        var command = new CreateSectionCommand(
                                        section.Name,
                                        section.Description,
                                        section.IsSport,
                                        section.Day,
                                        section.Time,
                                        section.TeacherId,
                                        section.LimitOfPlaces);
        var result = await _sender.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteSection([FromRoute]Guid SectionId)
    {
        var command = new DeleteSectionCommand(SectionId);
        var result = await _sender.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditSection([FromBody]UpdateSectionDto section,[FromRoute]Guid id)
    {
        var command = new EditSectionCommand(id,section.Name,section.Description,section.Day,section.Time,section.TeacherId,section.LimitOfPlaces);
        var result = await _sender.Send(command);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<Result<GetSectionResponse>> GetSection([FromRoute] Guid id)
    {
        var query = new GetSectionQuery(id);
        var result = await _sender.Send(query);
        return result;
    }

    [HttpGet]
    public async Task<Result<IEnumerable<GetSectionResponse>>> GetAllSections()
    {
        var query = new GetAllSectionsQuery();
        var result = await _sender.Send(query);
        return result;
    }
}
