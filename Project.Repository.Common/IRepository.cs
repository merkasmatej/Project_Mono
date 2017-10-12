using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
  public  interface IRepository
    {
        IUnitOfWork CreateUnitOfWork();

        Task<List<T>> GetAsync<T>() where T : class;
        Task<T> GetByIDAsync<T>(Guid id) where T : class;
        Task<int> AddAsync<T>(T entity) where T : class;
        Task<int> UpdateAsync<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(Guid id) where T: class;
        IQueryable<T> Table<T>() where T : class;
    }
}
