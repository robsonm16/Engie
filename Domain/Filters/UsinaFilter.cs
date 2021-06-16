using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Filters
{
    public class UsinaFilter : FilterBase
    {
        public Guid UsinaId { get; set; }
        public string Fornecedor { get; set; }
        public string UC { get; set; }
        public bool? Ativo { get; set; }
    }
}
