namespace MyMDB.SharedLibrary.Events;

public interface IMovieCreated
{
	int Id { get; set; }
	IEnumerable<string> Staff { get; set; }
}