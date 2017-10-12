using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DAL;
using Project.Model;
using Project.Model.Common;
using Project.Repository.Common;
using AutoMapper;
using System.Data.Entity;

namespace Project.Repository
{
   public class VehicleMakeRepository : IVehicleMakeRepository
    {
      protected IRepository Repository { get; private set; }

        public VehicleMakeRepository(IRepository repository)
        {
            this.Repository = repository;
        }

        public virtual async Task<IEnumerable<IVehicleMake>> GetAsync()
        {
            return Mapper.Map<IEnumerable<VehicleMake>>(await Repository.Table<VehicleMake>().ToListAsync());
        }

        public virtual async Task<IVehicleMake> GetByMakeIDAsync(Guid MakeID)
        {
            return Mapper.Map<VehicleMake>(await Repository.Table<VehicleMake>().Where(p => p.MakeID == MakeID).FirstOrDefaultAsync());
        }

        public virtual Task<int> AddAsync(IVehicleMake vehiclemake)
        {
            return Repository.AddAsync(Mapper.Map<VehicleMake>(vehiclemake));
        }

        public virtual Task<int> UpdateAsync(IVehicleMake vehiclemake)
        {
            return Repository.UpdateAsync(Mapper.Map<VehicleMake>(vehiclemake));
        }

        public virtual Task<int> DeleteAsync(Guid MakeID)
        {
            return Repository.DeleteAsync(Mapper.Map<VehicleMake>(MakeID));
        }
    }
}
