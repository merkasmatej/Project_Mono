using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Common
{
   public interface IFilter
    {
        string SearchVehicle { get; set; }

        int Page { get; set; }

        int PageSize { get; set; }

        string OrderBy { get; set; }
    }
}
