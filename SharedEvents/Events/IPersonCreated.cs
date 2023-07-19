namespace MyMDB.SharedLibrary.Events;

public interface IPersonCreated
{
    int Id { get; set; }
    string Name { get; set; }
}
