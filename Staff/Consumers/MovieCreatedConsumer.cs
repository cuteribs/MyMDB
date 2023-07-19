using MassTransit;
using MyMDB.SharedLibrary.Events;
using System.Text.Json;

namespace MyMDB.Staff.Consumers;

public class MovieCreatedConsumer : IConsumer<IMovieCreated>
{
	public Task Consume(ConsumeContext<IMovieCreated> context)
	{
		var json = JsonSerializer.Serialize(context);
		Console.WriteLine(json);
		return Task.CompletedTask;
	}
}
