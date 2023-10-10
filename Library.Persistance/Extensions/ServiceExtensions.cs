
using FluentValidation;
using Library.Application.DTO_s.User;
using Library.Application.Repositories;
using Library.Application.Validation;
using Library.Domain.Entities;
using Library.Infrastructure.Context;
using Library.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure.Extensions;

public static class ServiceExtensions
{
	public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("Library");
		services.AddDbContext<LibraryDbContext>(opt => opt.UseNpgsql(connectionString));
		services.AddScoped<IValidator<User>, UserValidator>();
		services.AddScoped<IUserRepository, UserRepository>();
		services.AddScoped<IUnitOfWork, UnitOfWork>();
	}
}