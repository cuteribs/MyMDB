using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMDB.Staff.Models;

[Table("Person")]
public class Person
{
	[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }

	[StringLength(100)]
	public string Name { get; set; } = "Unknown";

	[StringLength(10)]
	public string? Birthday { get; set; }

	[StringLength(2000)]
	public string? Bio { get; set; }
}
