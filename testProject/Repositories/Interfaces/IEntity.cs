using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
	public interface IEntity<T>
	{
		Task<T> GetById(int id);
		Task<List<T>> GetAll();
		Task<T> Add(T entity);
		Task<T> Update(T entity);
		Task Delete(int id);
	}
}