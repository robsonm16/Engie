using Domain.Commom;
using Domain.Entitys;
using Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Interfaces.Repository
{
    public interface IUsinaRepository
    {
        public IQueryable<Usina> GetAll();

        public IQueryable<Usina> GetAll(params Expression<Func<Usina, object>>[] includes);

        public Usina Add(Usina entity);

        public Usina Update(Usina entity);

        public int Remove(Usina entity);
        public IQueryable<Usina> GetByFilters(UsinaFilter filters);
        public IQueryable<Usina> Paginate(IQueryable<Usina> source, UsinaFilter filters);
    }
}
