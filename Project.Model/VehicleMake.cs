using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model.Common;

namespace Project.Model
{
  public  class VehicleMake : IVehicleMake
    {
        public Guid MakeID { get; set; }
        public string MakeName { get; set; }
        public string MakeAbrv { get; set; }
        public virtual IList<IVehicleModel> VehicleModels { get; set; }
    }
}
