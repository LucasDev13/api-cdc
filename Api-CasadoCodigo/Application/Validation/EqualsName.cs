using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api_CasadoCodigo.Application.Validation
{
    public class EqualsName : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return (string)value == "Ciência"
                ? new ValidationResult("Este nome já existe")
                : ValidationResult.Success;
        }
    }
}
