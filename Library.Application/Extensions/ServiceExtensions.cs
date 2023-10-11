using System.Reflection;
using FluentValidation;
using Library.Application.DTO_s.Author;
using Library.Application.Features.Author.Queries;
using Library.Application.MappingProfiles;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(UserProfile), typeof(AuthorProfile));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
    }
}