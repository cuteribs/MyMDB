using LiteDB;
using MyMDB.SharedLibrary.Data;

namespace MyMDB.Movie.Repositories;

public class MovieRepository : LiteDbRepository<Models.Movie>
{
	public MovieRepository(ILiteDatabase database) : base(database) { }
}
