using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Keycloak;


internal sealed class KeycloakService : IKeycloakService
{
    private readonly HttpClient _httpClient;

    public KeycloakService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task AddGroupAsync(Guid groupId, Guid teacherId)
    {
    }
}
