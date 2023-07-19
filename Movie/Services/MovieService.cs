using MyMDB.SharedLibrary.Data;

namespace MyMDB.Movie.Services;

public class MovieService
{
	private readonly IRepository<Models.Movie> _repository;

	public MovieService(IRepository<Models.Movie> repository)
	{
		_repository = repository;
	}

	public IEnumerable<Models.Movie> GetList()
		=> _repository.FindAll();

	public void Add(Models.Movie movie)
		=> _repository.Add(movie);
}
