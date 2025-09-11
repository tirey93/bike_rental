using BikeRental.StationService.Events;
using BikeRental.StationService.Infrastructure;
using Rebus.Bus;
using Rebus.Config;
using Rebus.Handlers;
using Rebus.Routing.TypeBased;
using StationService.Handlers;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var fileName = builder.Configuration.GetConnectionString("WebApiDatabase");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(fileName);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));



builder.Services.AddRebus(configure => configure
    .Transport(t => t.UseRabbitMq("amqp://localhost", "station-service-input-queue"))
    .Logging(l => l.Console())
);

builder.Services.AutoRegisterHandlersFromAssemblyOf<Program>();


var app = builder.Build();

app.Lifetime.ApplicationStarted.Register(async () =>
{
    using var scope = app.Services.CreateScope();
    var bus = scope.ServiceProvider.GetRequiredService<IBus>();

    await bus.Subscribe<string>();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
