using System;
using Core.Interfaces;

namespace DataAccess.Interfaces
{
	public interface IRepository<T> where T : class, IEntity,new()
	{
		Task<IEnumerable<T>> GetAllAsync();
		Task<T?> GetAsync(int? id);
        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync();

    }
}

