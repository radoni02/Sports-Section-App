using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Keycloak
{
    internal interface IKeycloakService
    {
        Task AddGroupAsync(Guid groupId, Guid teacherId);
    }
}
