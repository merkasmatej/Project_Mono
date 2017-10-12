using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.Common
{
   public interface IVehicleMake
    {
        Guid MakeID { get; set; }
        string MakeName { get; set; }
        string MakeAbrv { get; set; }
        IList<IVehicleModel> VehicleModels { get; set; }
    }
}
