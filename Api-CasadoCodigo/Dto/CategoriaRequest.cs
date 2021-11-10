using Api_CasadoCodigo.Application.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api_CasadoCodigo.Dto
{
    public class CategoriaRequest
    {
        [Required(ErrorMessage = "Nome da categora obrigatorio.")]
        [EqualsName]
        public string nomeCategoria { get; set; }

        public override bool Equals(object obj)
        {
            return obj is CategoriaRequest request &&
                   nomeCategoria == request.nomeCategoria;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(nomeCategoria);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
