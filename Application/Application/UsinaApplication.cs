using Application.Dto;
using AutoMapper;
using Domain.Entitys;
using Domain.Filters;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Application.Application
{
    public class UsinaApplication
    {
        protected readonly IUsinaService _service;
        protected readonly IMapper _mapper;

        public UsinaApplication(IUsinaService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        public async Task<UsinaDto> GetOne(UsinaFilter filters)
        {
            var resultDomain = await this._service.GetOne(filters);
            UsinaDto resultDto = await this.MapperDomainToDto(resultDomain);
            return resultDto;

        }
        public async Task<IEnumerable<UsinaDto>> GetByFilters(UsinaFilter filters)
        {

            var result = await this._service.GetByFilters(filters);
            var resultDto = this.MapperDomainToDtoResult(result);
            return resultDto;
        }


        public async Task<int> Remove(UsinaDto entity)
        {
            var model = await this.MapperDtoToDomain(entity);
            return this._service.Remove(model);            
        }

        protected async Task<Usina> MapperDtoToDomain(UsinaDto dto)
        {
            return await Task.Run(() =>
            {
                var result = this._mapper.Map<UsinaDto, Usina>(dto);
                return result;
            });
        }

        protected async Task<UsinaDto> MapperDomainToDto(Usina dto)
        {
            return await Task.Run(() =>
            {
                var result = this._mapper.Map<Usina, UsinaDto>(dto);
                return result;
            });
        }

        protected async Task<IEnumerable<UsinaDto>> MapperDomainToDtoResult(IEnumerable<Usina> entitys)
        {
            return await Task.Run(() =>
            {
                var result = this._mapper.Map<IEnumerable<Usina>, IEnumerable<UsinaDto>>(entitys);
                return result;
            });
        }
    }
}
