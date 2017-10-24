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
using Project.Common;
using System.Linq.Expressions;

namespace Project.Repository
{
   public class VehicleMakeRepository : IVehicleMakeRepository
    {
      protected IRepository Repository { get; private set; }

        public VehicleMakeRepository(IRepository repository)
        {
            this.Repository = repository;
        }

        public virtual async Task<IEnumerable<IVehicleMake>> GetAsync(IFilter filter = null)
        {
            if (filter != null)
            {
                var vehicles = Mapper.Map<IEnumerable<VehicleMake>>(
                    await Repository.Table<VehicleMake>()
                    .OrderBy(m => m.MakeName)
                    .ToListAsync());

                if (!string.IsNullOrWhiteSpace(filter.SearchVehicle))
                {
                    vehicles = vehicles.Where(m => m.MakeName.ToUpper()
                    .Contains(filter.SearchVehicle.ToUpper()))
                    .ToList();
                }
                return vehicles;
            }
            else
            {
                return Mapper.Map<IEnumerable<VehicleMake>>(await Repository.Table<VehicleMake>().ToListAsync());
            }
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

