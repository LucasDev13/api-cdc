using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api_CasadoCodigo.Application.Validation
{
    public class EmailCustomValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, 
                                                    ValidationContext validationContext)
        {
            //Aqui eu poderia ir no banco buscar esse email.
            return (string)value == "lucas@uol.com"
                ? new ValidationResult("Este email já existe.")
                : ValidationResult.Success;
        }
    }
}
