using Application.Dto;
using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ConfigMapper
{
    public class ConfigMapper : AutoMapper.Profile
    {
        public ConfigMapper()
        {
            CreateMap(typeof(Usina), typeof(UsinaDto)).ReverseMap();
        }
       
    }
}
