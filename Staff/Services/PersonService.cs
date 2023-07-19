using MyMDB.Staff.Models;

namespace MyMDB.Staff.Services;

public class PersonService
{
	private readonly PersonDbContext _context;

	public PersonService(PersonDbContext context)
	{
		_context = context;
	}

	public IEnumerable<Person> GetList()
		=> _context.Persons.ToList();

	public Person Add(Person person)
	{
		_context.Persons.Add(person);
		_context.SaveChanges();
		return person;
	}
}
