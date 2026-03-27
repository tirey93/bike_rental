using BikeRental.BikeAtStationService.Infrastructure;
using BikeRental.BikeService.Contracts.Events;
using BikeRental.StationService.Contracts.Events;
using Rebus.Bus;
using Rebus.Config;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var fileName = builder.Configuration.GetConnectionString("WebApiDatabase");
var rabbitHost = builder.Configuration["RabbitMQ:Hostname"] ?? "localhost";
var allowedOrigin = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(fileName);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddRebus(configure => configure
    .Transport(t => t.UseRabbitMq(
        connectionString: "amqp://" + rabbitHost,
        inputQueueName: "bike-at-station-service-input-queue")
    )
    .Logging(l => l.Console())
    .Options(o => o.LogPipeline(verbose: true))
);

builder.Services.AutoRegisterHandlersFromAssemblyOf<Program>();

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.WithOrigins(allowedOrigin)
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

var app = builder.Build();
app.UseCors("MyPolicy");

app.Lifetime.ApplicationStarted.Register(async () =>
{
    using var scope = app.Services.CreateScope();
    var bus = scope.ServiceProvider.GetRequiredService<IBus>();

    await bus.Subscribe<BikeCreatedEvent>();
    await bus.Subscribe<BikeDeletedEvent>();
    await bus.Subscribe<StationCreatedEvent>();
    await bus.Subscribe<StationRemovedEvent>();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
