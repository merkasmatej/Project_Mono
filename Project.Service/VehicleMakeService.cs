using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model.Common;
using Project.Repository.Common;
using Project.Service.Common;
using Project.Common;

namespace Project.Service
{
   public class VehicleMakeService : IVehicleMakeService
    {

        protected IVehicleMakeRepository Repository { get; private set; }

        public  VehicleMakeService(IVehicleMakeRepository repository)
        {
            this.Repository = repository;
        }

        public virtual async Task<IEnumerable<IVehicleMake>> GetAsync(Filter filter = null)
        {
            var vehiclemake = await Repository.GetAsync();

            vehiclemake.OrderBy(m => m.MakeName)
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToList();

            return await Repository.GetAsync();
        }

        public virtual async Task<IVehicleMake> GetByMakeIDAsync(Guid MakeID)
        {
            return await Repository.GetByMakeIDAsync(MakeID);
        }

        public virtual async Task<int> AddAsync(IVehicleMake vehiclemake)
        {
            return await Repository.AddAsync(vehiclemake);
        } 

        public virtual async Task<int> UpdateAsync(IVehicleMake vehiclemake)
        {
            return await Repository.UpdateAsync(vehiclemake);
        }

        public virtual async Task<int> DeleteAsync(Guid MakeID)
        {
            return await Repository.DeleteAsync(MakeID);
        }
    }
}
