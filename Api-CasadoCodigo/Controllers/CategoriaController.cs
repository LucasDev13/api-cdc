using Api_CasadoCodigo.Dto;
using Api_CasadoCodigo.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_CasadoCodigo.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoriaController : ControllerBase
    {
        IMapper _mapper;
        public CategoriaController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult save([FromBody] CategoriaRequest categoriaRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var categoria = _mapper.Map<Categoria>(categoriaRequest);
                Console.WriteLine($"{categoria}");
                return Ok(categoria);
                
            }
            
        }
    }
}
