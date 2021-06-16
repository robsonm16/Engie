using Domain.Dto;
using Domain.Entitys;
using System;
using System.Collections.Generic;

namespace Domain.ConfigMapper
{
    public class AutoMapperConfig
    {
        public static Type[] RegisterMappings()
        {
            return new List<Type>
            {
                typeof(ConfigMapper),
            }.ToArray();
        }
    }
    public class ConfigMapper : AutoMapper.Profile
    {
        public ConfigMapper()
        {
            CreateMap(typeof(Entitys.Usina), typeof(Dto.UsinaDto)).ReverseMap();
        }
       
    }
}
