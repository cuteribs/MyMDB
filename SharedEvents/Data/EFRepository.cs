using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MyMDB.SharedLibrary.Data;

public abstract class EFRepository<T> : IRepository<T> where T : class
{
	protected DbContext Context { get; }
	protected DbSet<T> DbSet { get; }

	protected EFRepository(DbContext context)
	{
		this.Context = context;
		this.DbSet = this.Context.Set<T>();
	}

	public virtual T? Get(object id)
		=> this.DbSet.Find(id);

	public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
		=> this.DbSet.Where(predicate).ToArray();

	public virtual IEnumerable<T> FindAll()
		=> this.DbSet.ToArray();

	public virtual bool Exists(Expression<Func<T, bool>> predicate)
		=> this.DbSet.Any(predicate);

	public virtual void Add(T item)
		=> this.DbSet.Add(item);

	public virtual void AddRange(params T[] items)
		=> this.DbSet.AddRange(items);

	public virtual void Update(T item)
		=> this.DbSet.Update(item);

	public virtual void Delete(T item)
		=> this.DbSet.Remove(item);

	public virtual void SaveChanges()
		=> this.Context.SaveChanges();
}
