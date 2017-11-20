using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model.Common;
using Project.Common;


namespace Project.Service.Common
{
   public interface IVehicleMakeService
    {
        Task<IEnumerable<IVehicleMake>> GetAsync(Filter filter = null);
        Task<IVehicleMake> GetByMakeIDAsync(Guid MakeID);
        Task<int> AddAsync(IVehicleMake vehiclemake);
        Task<int> UpdateAsync(IVehicleMake vehiclemake);
        Task<int> DeleteAsync(Guid MakeID);
    }
}
