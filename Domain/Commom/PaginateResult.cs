using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Commom
{
    public class PaginateResult<T>
    {

        public IEnumerable<T> Datalist { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }

    }
}
