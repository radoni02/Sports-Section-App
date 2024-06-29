using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Keycloak
{
    public static class KeycloakExtension
    {
        public static IServiceCollection AddKeycloak(this IServiceCollection services, IConfiguration configuration)
        {

            return services;
        }
    }
}
