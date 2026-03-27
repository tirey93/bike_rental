using BikeRental.BikeAtStationService.Infrastructure;
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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
