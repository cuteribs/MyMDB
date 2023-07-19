using LiteDB;
using System.Linq.Expressions;

namespace MyMDB.SharedLibrary.Data;

public abstract class LiteDbRepository<T> : IRepository<T> where T : class
{
	private readonly ILiteDatabase _database;

	protected ILiteCollection<T> Collection { get; }

	public LiteDbRepository(ILiteDatabase database)
	{
		_database = database;
		this.Collection = database.GetCollection<T>();
	}

	public void Add(T item)
		=> this.Collection.Insert(item);

	public void AddRange(params T[] items)
		=> this.Collection.Insert(items);

	public void Delete(T item)
		=> throw new NotImplementedException();

	public bool Exists(Expression<Func<T, bool>> predicate)
		=> this.Collection.Exists(predicate);

	public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
		=> this.Collection.Find(predicate);

	public IEnumerable<T> FindAll()
		=> this.Collection.FindAll();
	public T? Get(object id)
		=> id is BsonValue bsonId ? this.Collection.FindById(bsonId) : null;

	public void Update(T item)
		=> this.Collection.Update(item);

	public bool StartTransaction()
		=> _database.BeginTrans();

	public void SaveChanges()
		=> _database.Commit();

	public void UndoChanges()
		=> _database.Rollback();
}
