using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMDB.Staff;
using MyMDB.Staff.Consumers;
using MyMDB.Staff.Models;
using MyMDB.Staff.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

var services = builder.Services;

var busControl = Bus.Factory.CreateUsingRabbitMq(x =>
{
	x.Host("192.168.6.201");
	x.ReceiveEndpoint("movie-created-event", c => c.Consumer<MovieCreatedConsumer>());
});
await busControl.StartAsync();

services.AddSqlite<PersonDbContext>(configuration.GetConnectionString("Staff"));

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddScoped<PersonService>();


var app = builder.Build();

app.UseSwagger().UseSwaggerUI();

app.MapGet("/person/latest", (PersonService service) =>
{
	return service.GetList();
});

app.MapPost("/person", ([FromBody] Person person, PersonService service) =>
{
	return service.Add(person);
});

app.Run();
