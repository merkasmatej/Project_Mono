using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model.Common;

namespace Project.Model
{
   public class VehicleModel : IVehicleModel
    {
        public Guid ModelID { get; set; }
        public Guid MakeID { get; set; }
        public string ModelName { get; set; }
        public string ModelAbrv { get; set; }
        public IVehicleMake VehicleMake { get; set; }
    }
}
