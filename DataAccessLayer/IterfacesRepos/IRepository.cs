using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IterfacesRepositories
{
    public interface IRepository<T> where T : class
    {
        Task <IEnumerable<T>> GetAll();
        Task<T> GetById(string id);
        Task<bool> Add(T entity);
        void Update(T entity);
        Task<bool> Delete(T entity);
    }
}
