using Library.Application;
using Library.Application.Extensions;
using Library.Infrastructure;
using Library.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigurePersistence(builder.Configuration);
builder.Services.ConfigureApplication();


builder.Services.AddControllers();
builder.Services.AddControllers()
.AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();