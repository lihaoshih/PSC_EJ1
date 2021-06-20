using System.Collections.Generic;
using System.Threading.Tasks;
using ParallelComparison.Models;

namespace ParallelComparison.Repository
{
	public interface IRepository<T> where T : BaseEntity
	{
		Task<List<T>> GetAllAsync();
		List<T> GetAll();
		Task<T> GetByIdAsync(T entity);
		T GetById(T entity);
		Task CreateAsync(T entity);
		void Create(T entity);
		Task UpdateAsync(T entity);
		void Update(T entity);
		Task DeleteAsync(string id);
		void Delete(T entity);
	}
}
