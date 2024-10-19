using HubScribe.APIs.Extensions;
using HubScribe.Application.Extensions;
using HubScribe.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.ConfigureApplicationLayer();
builder.Services.ConfigureInfrastructureLayer();
builder.Services.ConfigureApiVersioning();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureVersionedSwagger();
builder.Services.ConfigureLowercaseURLs();

var app = builder.Build();

app.UseSwaggerWithVersioning(app.Environment);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();