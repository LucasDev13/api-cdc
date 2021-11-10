using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api_CasadoCodigo.Application.Validation
{
    public class BlockDomainValidator : ValidationAttribute
    {
        public string Domain { get; set; }

        public BlockDomainValidator(string domain)
        {
            Domain = domain;
        }

        protected override ValidationResult IsValid(object value,
                                                    ValidationContext validationContext)
        {
            //Aqui eu poderia ir no banco buscar esse email.
            return ((string)value).Contains(Domain)
                ? new ValidationResult("Domínio inválido.") 
                : ValidationResult.Success;
        }
    }
}
