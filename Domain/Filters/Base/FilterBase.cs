using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Filters
{
    public abstract class FilterBase
    {
        public FilterBase()
        {
            this.PageIndex = 0;
            this.PageSize = 50;
            this.IsPagination = true;
        }

        public int PageSkipped
        {
            get
            {
                return (this.PageIndex > 0 ? this.PageIndex - 1 : 0) * this.PageSize;
            }
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public bool IsPagination { get; set; }
        public string AttributeBehavior { get; set; }
        public string QueryOptimizerBehavior { get; set; }
        public string[] OrderFields { get; set; }

    }
}
