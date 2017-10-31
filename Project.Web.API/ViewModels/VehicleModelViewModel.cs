using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebAPI.ViewModels
{
    public class VehicleModelViewModel
    {
        public Guid ModelID { get; set; }
        public Guid MakeID { get; set; }
        public string ModelName { get; set; }
        public string ModelAbrv { get; set; }
    }
}