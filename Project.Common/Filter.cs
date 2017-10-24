using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Common
{
   public class Filter: IFilter
    {
        public string SearchVehicle { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public string OrderBy { get; set; }


        
          public int  DefaultPageSize = 5;
        

        public Filter(string searchString, int pageNumber, int pageSize)
        {
            SearchVehicle = searchString;
            SetPageNumberAndSize(pageNumber, pageSize);
  
        }

        private void SetPageNumberAndSize(int pageNumber = 1, int pageSize = 0)
        {
            Page = (pageNumber > 0) ? pageNumber : 1;
            PageSize = (pageSize > 0 && pageSize <= DefaultPageSize) ? pageSize : DefaultPageSize;
        }
    }
}
