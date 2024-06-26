﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Section.Domain.Repositories;
using Section.Infrastructure.Database.Repositories;
using Section.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Section.Application.Abstractions.Messaging;
using Section.Infrastructure.Abstractions.Messaging;

namespace Section.Infrastructure;

public static class InfrastructureExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);
        services.AddMediatR(cf => cf.RegisterServicesFromAssemblies(typeof(DatabaseExtension).Assembly));
        services.AddScoped<IMessageSender, MessageSender>();

        return services;
    }
}
