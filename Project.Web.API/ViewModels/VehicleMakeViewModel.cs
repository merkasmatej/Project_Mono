using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebAPI.ViewModels
{
    public class VehicleMakeViewModel
    {
        public Guid MakeID { get; set; }
        public string MakeName { get; set; }
        public string MakeAbrv { get; set; }
    }
}