 using Microsoft.EntityFrameworkCore;
using MyMDB.Staff.Models;

namespace MyMDB.Staff;

public class PersonDbContext : DbContext
{
	public DbSet<Person> Persons { get; set; } = default!;

	public PersonDbContext(DbContextOptions options) : base(options)
	{
	}
}
