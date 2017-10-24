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

        public VehicleMakeService(IVehicleMakeRepository repository)
        {
            this.Repository = repository;
        }

        public Task<IEnumerable<IVehicleMake>> GetAsync(IFilter filter = null)
        {
            return Repository.GetAsync();
        }

        public Task<IVehicleMake> GetByMakeIDAsync(Guid MakeID)
        {
            return Repository.GetByMakeIDAsync(MakeID);
        }

        public Task<int> AddAsync(IVehicleMake vehiclemake)
        {
            return Repository.AddAsync(vehiclemake);
        } 

        public Task<int> UpdateAsync(IVehicleMake vehiclemake)
        {
            return Repository.UpdateAsync(vehiclemake);
        }

        public Task<int> DeleteAsync(Guid MakeID)
        {
            return Repository.DeleteAsync(MakeID);
        }
    }
}
