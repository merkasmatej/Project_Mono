using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model.Common;
using Project.DAL;

namespace Project.Repository.Common
{
   public interface IVehicleMakeRepository
    {
        Task<IEnumerable<IVehicleMake>> GetAsync();         //get VehicleMake

        Task<IVehicleMake> GetByMakeIDAsync(Guid MakeID);     //getVehicleMake by ID

        Task<int> AddAsync(IVehicleMake vehiclemake);       //create VehicleMake

        Task<int> UpdateAsync(IVehicleMake vehiclemake);    //updateVehicleMake

        Task<int> DeleteAsync(Guid MakeID);                  //delete VehicleMake by ID
    }
}
