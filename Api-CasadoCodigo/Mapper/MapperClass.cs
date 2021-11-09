using Api_CasadoCodigo.Dto;
using Api_CasadoCodigo.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_CasadoCodigo.Mapper
{
    public class MapperClass
    {
        public MapperClass()
        {
            var config = new MapperConfiguration(cfg =>
                     cfg.CreateMap<Author, AuthorRequest>()
               );
        }
    }
}
