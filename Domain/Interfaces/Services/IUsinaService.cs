using Domain.Commom;
using Domain.Dto;
using Domain.Entitys;
using Domain.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IUsinaService
    {

        public  Task<PaginateResult<Dto.UsinaDto>> GetByFilters(UsinaFilter filters);
        public  Task<Dto.UsinaDto> GetOne(UsinaFilter filters);

        public  Task<int> Remove(Dto.UsinaDto model);

        public  Task<Dto.UsinaDto> Save(Dto.UsinaDto model, bool questionToContinue = true);

        public  Task<Dto.UsinaDto> SavePartial(Dto.UsinaDto model, bool questionToContinue = true);
    }
}
