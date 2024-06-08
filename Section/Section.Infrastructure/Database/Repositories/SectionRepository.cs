using Section.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section.Infrastructure.Database.Repositories;

internal class SectionRepository : ISectionRepository
{
    private readonly ApplicationDbContext _context;

    public SectionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddSection(Section.Domain.Models.Section section)
    {
        await _context.AddAsync(section);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteSection(Section.Domain.Models.Section section)
    {
         _context.Remove(section);
         await _context.SaveChangesAsync();
    }

    public async Task EditSection(Section.Domain.Models.Section section)
    {
        _context.Update(section);
        await _context.SaveChangesAsync();
    }
}
