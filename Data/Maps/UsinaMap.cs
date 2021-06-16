using Domain.Entitys;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Maps
{
    public class UsinaMap
    {
        public UsinaMap(EntityTypeBuilder<Usina> type)
        {

            type.Property(t => t.UsinaId).IsRequired();
            type.Property(t => t.Fornecedor).HasMaxLength(50).IsRequired();
            type.Property(t => t.UC).HasMaxLength(50).IsRequired();
            type.Property(t => t.Ativo).IsRequired();

            type.HasKey(k => new { k.UsinaId });
        }
    }
}
