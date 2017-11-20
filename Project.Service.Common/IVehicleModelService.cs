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
        Task<IEnumerable<IVehicleModel>> GetAsync(Filter filter = null);
        Task<IVehicleModel> GetByModelIDAsync(Guid ModelID);
        Task<int> AddAsync(Guid makeID, Guid modelID, string modelName, string modelAbrv);
        Task<int> UpdateAsync(Guid makeID, Guid modelID, string modelName, string modelAbrv);
        Task<int> DeleteAsync(Guid ModelID);
    }
}
