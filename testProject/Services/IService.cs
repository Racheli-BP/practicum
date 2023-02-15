using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IService<T>
    {
        public Task<T >GetById(int id);
        public Task< List<T> >GetAll();
        public Task<T> Add(T entity);
        public Task<T> Update(T entity);
        public Task Delete(int id);
    }
}
