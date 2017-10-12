using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.Common
{
   public interface IVehicleModel
    {
        Guid ModelID { get; set; }
        Guid MakeID { get; set; }
        string ModelName { get; set; }
        string ModelAbrv { get; set; }
        IVehicleMake VehicleMake { get; set; }
    }
}
