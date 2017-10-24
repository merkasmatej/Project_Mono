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
   public class VehicleModelService: IVehicleModelService
    {
        protected IVehicleModelRepository Repository { get; private set; }

        public VehicleModelService(IVehicleModelRepository repository)
        {
            this.Repository = repository;
        }

        public Task<IEnumerable<IVehicleModel>> GetAsync(IFilter filter = null)
        {
            return Repository.GetAsync();
        }

        public Task<IVehicleModel> GetByModelIDAsync(Guid ModelID)
        {
            return Repository.GetByModelIDAsync(ModelID);
        }

        public Task<int> AddAsync(IVehicleModel vehiclemodel)
        {
            return Repository.AddAsync(vehiclemodel);
        }

        public Task<int> UpdateAsync(IVehicleModel vehiclemodel)
        {
            return Repository.UpdateAsync(vehiclemodel);
        }

        public Task<int> DeleteAsync(Guid ModelID)
        {
            return Repository.DeleteAsync(ModelID);
        }
    }
}
