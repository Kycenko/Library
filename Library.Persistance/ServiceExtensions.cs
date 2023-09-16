using FluentValidation;
using Library.Application.Features.User;
using Library.Application.Repositories;
using Library.Application.Services;
using Library.Domain.Common.Interfaces.Services;
using Library.Domain.Entities;
using Library.Infrastructure.Context;
using Library.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure;

public static class ServiceExtensions
{
	public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("Library");
		services.AddDbContext<LibraryDbContext>(opt => opt.UseNpgsql(connectionString));
		services.AddScoped<IUserRepository, UserRepository>();
		services.AddScoped<IUnitOfWork, UnitOfWork>();
		services.AddScoped<IUserService, UserService>();
		services.AddScoped<IValidator<User>, UserValidator>();
	}
}