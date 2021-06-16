using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entitys
{
    public class DomainBase
    {
        [NotMapped]
        public string AttributeBehavior { get; protected set; }
    }
}
