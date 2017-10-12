using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
   public class VehicleMake
    {
        public Guid MakeID { get; set; }
        public string MakeName { get; set; }
        public string MakeAbrv { get; set; }
        public virtual List<VehicleModel> VehicleModels { get; set; }


    }
}
