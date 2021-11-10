using Api_CasadoCodigo.Dto;
using Api_CasadoCodigo.Mapper;
using Api_CasadoCodigo.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api_CasadoCodigo.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AutorController : ControllerBase
    {

        IMapper _mapper;
        public AutorController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Save([FromBody] AuthorRequest authorRequest)
        {
            Guid guid = Guid.NewGuid();
            try
            {
                if (ModelState.IsValid)
                    BadRequest();
                var author = _mapper.Map<Author>(authorRequest);
                Console.WriteLine($"{author} - { guid}");
               
                //salvar no banco

                //monta a url da requisição
                var urlRequisicao = $"[{Request?.Method?.ToUpper()}] {Request?.Path}";
                Console.WriteLine(urlRequisicao);
                return Ok(urlRequisicao);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Menssagem de erro -> {e.Message}");
            }
            return Ok(authorRequest);

        }
    }
}
