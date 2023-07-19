namespace MyMDB.Movie.Models;

public class Movie
{
	public int Id { get; set; }

	public string Name { get; set; } = "Unknown";

	public string? ReleaseDate { get; set; }

	public IEnumerable<string>? Staff { get; set; }
}
