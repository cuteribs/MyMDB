using MyMDB.SharedLibrary.Data;

namespace MyMDB.Staff.Repositories;

public class PersonRepository : EFRepository<Models.Person>
{
	public PersonRepository(PersonDbContext context) : base(context) { }
}
