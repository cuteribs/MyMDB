using System.Linq.Expressions;

namespace MyMDB.SharedLibrary.Data
{
	public interface IRepository<T> where T : class
	{
		void Add(T item);
		void AddRange(params T[] items);
		void Delete(T item);
		bool Exists(Expression<Func<T, bool>> predicate);
		IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
		IEnumerable<T> FindAll();
		T? Get(object id);
		void SaveChanges();
		void Update(T item);
	}
}