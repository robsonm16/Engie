using AutoMapper;
using Domain.Entitys;
using Domain.Filters;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Dto;
using System.Linq;
using Domain.Commom;

namespace Domain.Services
{
    public class UsinaService : IUsinaService
    {
        protected readonly IUsinaRepository _rep;
        protected readonly IMapper _mapper;

        public UsinaService(IUsinaRepository rep, IMapper mapper)
        {
            this._rep = rep;
            this._mapper = mapper;
        }

        public async Task<PaginateResult<UsinaDto>> GetByFilters(UsinaFilter filters)
        {
            var result = this._rep.GetByFilters(filters);
            var paginatedResult = this._rep.Paginate(result, filters);
            var resultDto = this._mapper.Map<IEnumerable<Usina>, IEnumerable<UsinaDto>>(paginatedResult);
            
            return new PaginateResult<UsinaDto>
            {
                PageSize = paginatedResult.Count(),
                Datalist = resultDto,
                TotalCount = result.Count()
            };
        }

        public Task<UsinaDto> GetOne(UsinaFilter filters)
        {
            var result = this._rep.GetAll().Where(_ => _.UsinaId == filters.UsinaId).SingleOrDefault();
            return this.MapperDomainToDto(result);
        }

        public async Task<int> Remove(UsinaDto model)
        {
            var entity = await this.MapperDtoToDomain(model);
            return this._rep.Remove(entity);
        }

        public async Task<UsinaDto> Save(UsinaDto model, bool questionToContinue = true)
        {
            var entity = await this.MapperDtoToDomain(model);

            var validation = await this.GetByFilters(new UsinaFilter { Fornecedor = model.Fornecedor, UC = model.UC });

            if (validation.Datalist.Count() == 0)
                entity = this._rep.Add(entity);


            model = await this.MapperDomainToDto(entity);
            return model;
        }

        public async Task<UsinaDto> SavePartial(UsinaDto model, bool questionToContinue = true)
        {
            var entity = await this.MapperDtoToDomain(model);
            entity = this._rep.Update(entity);

            model = await this.MapperDomainToDto(entity);
            return model;
        }

        protected async virtual Task<Usina> MapperDtoToDomain(UsinaDto dto)
        {
            return await Task.Run(() =>
            {
                var result = this._mapper.Map<UsinaDto, Usina>(dto);
                return result;
            });
        }

        protected async virtual Task<UsinaDto> MapperDomainToDto(Usina model)
        {
            return await Task.Run(() =>
            {
                var result = this._mapper.Map<Usina, UsinaDto>(model);
                return result;
            });
        }


    }
}
