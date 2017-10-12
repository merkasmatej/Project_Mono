using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Repository.Common;
using Project.DAL;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Project.Model;

namespace Project.Repository
{
  public class Repository : IRepository
    {
        protected IVehicle DbContext { get; private set; }
        protected IUnitOfWorkCreating UnitOfWorkCreating { get; private set; }

        public Repository(IVehicle db, IUnitOfWorkCreating unitofworkcreating)
        {
            if (db == null)
            {
                throw new ArgumentException("DbContext");
            }
            DbContext = db;
            UnitOfWorkCreating = unitofworkcreating;
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            return UnitOfWorkCreating.CreateUnitOfWork();
        }

        public virtual Task<List<T>> GetAsync<T>()where T: class
        {
            return DbContext.Set<T>().ToListAsync();
        }

       public virtual Task<T> GetByIDAsync<T>(Guid id) where T : class
        {
            return DbContext.Set<T>().FindAsync();
        }

        public virtual async Task<int> AddAsync<T>(T entity) where T: class
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if(dbEntityEntry.State!= EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbContext.Set<T>().Add(entity);
            }
            return await DbContext.SaveChangesAsync();
        }
       
        public virtual async Task<int> UpdateAsync<T>(T entity) where T: class
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if(dbEntityEntry.State == EntityState.Detached)
            {
                DbContext.Set<T>().Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
            return await DbContext.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync<T>(T entity) where T: class
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if(dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbContext.Set<T>().Attach(entity);
                DbContext.Set<T>().Remove(entity);
            }
            return await DbContext.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync<T>(Guid id) where T: class
        {
            var entity = await GetByIDAsync<T>(id);
            if(entity == null)
            {
                throw new KeyNotFoundException("Entity with this id not found");
            }
            return await DeleteAsync<T>(entity);
        }

        public virtual IQueryable<T> Table <T>()where T : class
        {
            return DbContext.Set<T>();
        }
    }
}
