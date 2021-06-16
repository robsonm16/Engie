using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Data.Maps;
using Domain.Entitys;

namespace Data.Context
{
    public class DbContextEngie : DbContext
    {

        public DbContextEngie(DbContextOptions<DbContextEngie> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UsinaMap(modelBuilder.Entity<Usina>());
        }
    }
}
