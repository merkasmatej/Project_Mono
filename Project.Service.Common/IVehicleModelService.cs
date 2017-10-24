using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model.Common;
using Project.Common;

namespace Project.Service.Common
{
   public interface IVehicleModelService
    {
        Task<IEnumerable<IVehicleModel>> GetAsync(IFilter filter = null;);
        Task<IVehicleModel> GetByModelIDAsync(Guid ModelID);
        Task<int> AddAsync(IVehicleModel vehiclemodel);
        Task<int> UpdateAsync(IVehicleModel vehiclemodel);
        Task<int> DeleteAsync(Guid ModelID);
    }
}
