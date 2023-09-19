using Library.Application;
using Library.Infrastructure;
using Library.Infrastructure.Context;


var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigurePersistence(builder.Configuration);
builder.Services.ConfigureApplication();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


var serviceScope = app.Services.CreateScope();

var dataContext = serviceScope.ServiceProvider.GetService<LibraryDbContext>();


if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();