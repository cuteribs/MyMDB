using LiteDB;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using MyMDB.Movie.Repositories;
using MyMDB.Movie.Services;
using MyMDB.SharedLibrary.Data;
using MyMDB.SharedLibrary.Events;

namespace MyMDB.Movie;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		var configuration = builder.Configuration;

		var services = builder.Services;

		//Bus.Factory.CreateUsingRabbitMq(x =>
		//	x.ReceiveEndpoint("movie-created-event", c => c.Consumer<PersonCreatedConsumer>())
		//);
		services.AddMassTransit(c => c.UsingRabbitMq((_, cfg) => cfg.Host("192.168.6.201")));

		// inject LiteDb
		services.AddTransient<ILiteDatabase>(p => new LiteDatabase(configuration.GetConnectionString("Movie")));
		services.AddScoped<IRepository<Models.Movie>>(p => ActivatorUtilities.CreateInstance<MovieRepository>(p));

		services.AddEndpointsApiExplorer();
		services.AddSwaggerGen();

		services.AddScoped<MovieService>();


		var app = builder.Build();

		app.UseSwagger().UseSwaggerUI();

		app.MapGet("/movie/all", (MovieService service) => service.GetList());

		app.MapPost("/movie",
			async (
				[FromBody] Models.Movie movie,
				MovieService service,
				IPublishEndpoint publishEndpoint
			) =>
			{
				service.Add(movie);
				await publishEndpoint.Publish<IMovieCreated>(new
				{
					Id = movie.Id,
					Staff = movie.Staff,
				});
			});

		app.Run();
	}
}