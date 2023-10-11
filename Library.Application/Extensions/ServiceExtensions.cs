using System.Reflection;
using FluentValidation;
using Library.Application.MappingProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(UserProfile));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
}