using Data.Context;
using Domain.Commom;
using Domain.Entitys;
using Domain.Filters;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.Repository
{
    public class UsinaRepository : IUsinaRepository
    {

        protected DbContextEngie ctx;
        protected DbSet<Usina> dbSet;

        public UsinaRepository(DbContextEngie ctx)
        {
            this.ctx = ctx;
            this.dbSet = this.ctx.Set<Usina>();
        }

        public IQueryable<Usina> GetAll()
        {
            return this.dbSet.AsNoTracking();
        }

        public IQueryable<Usina> GetAll(params Expression<Func<Usina, object>>[] includes)
        {
            IQueryable<Usina> query = ctx.Set<Usina>();
            return includes.Aggregate(query, (current, include) => current.Include(include))
                .AsNoTracking();
        }

        public Usina Add(Usina entity)
        {
            var result = this.dbSet.Add(entity);
            this.ctx.SaveChanges();
            return result.Entity;
        }

        public Usina Update(Usina entity)
        {
            
            var entry = this.ctx.Entry(entity);
            this.dbSet.Attach(entity);
            entry.State = EntityState.Modified;
            this.ctx.SaveChanges();
            return entity;
        }

        public int Remove(Usina entity)
        {
            dbSet.Remove(entity);
            return this.ctx.SaveChanges();
        }

        public IQueryable<Usina> GetByFilters(UsinaFilter filters)
        {
            var souce = this.GetAll();

            if (!string.IsNullOrEmpty(filters.Fornecedor))
                souce = souce.Where(_ => _.Fornecedor.ToLower().Contains(filters.Fornecedor.ToLower()));

            if (!string.IsNullOrEmpty(filters.UC))
                souce = souce.Where(_ => _.UC.ToLower() == filters.UC.ToLower());

            if (filters.Ativo != null)
                souce = souce.Where(_ => _.Ativo == filters.Ativo);

            return souce;
        }

        public IQueryable<Usina> Paginate(IQueryable<Usina> source, UsinaFilter filter)
        {
            if (filter.IsPagination)
            {
                var pageSize = filter.PageSize;
                return source.Skip(filter.PageSkipped).Take(pageSize);
            }
            return source;
        }


    }
}
