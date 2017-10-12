using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
   public class VehicleModel
    {
        public Guid ModelID { get; set; }
        public Guid MakeID { get; set; }
        public string ModelName { get; set; }
        public string ModelAbrv { get; set; }
        public virtual VehicleMake VehicleMake { get; set; }

    }
}
