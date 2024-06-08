using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section.Domain.Repositories;

public interface ISectionRepository
{
    Task AddSection(Section.Domain.Models.Section section);
    Task DeleteSection(Section.Domain.Models.Section section);
    Task EditSection(Section.Domain.Models.Section section);
    Task<Section.Domain.Models.Section> GetSection(Guid id);
}
