using Api_CasadoCodigo.Dto;
using Api_CasadoCodigo.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_CasadoCodigo.Application.Validation
{
    public class AuthorValidator : AbstractValidator<AuthorRequest>
    {
        public AuthorValidator()
        {
            RuleFor(cp => cp.Name)
                .NotNull().WithMessage("Não pode ser nulo.")
                .NotEmpty().WithMessage("Não pode ser vazio.")
                .MaximumLength(30).WithMessage("30 caracteres.");
            RuleFor(cp => cp.Email)
                .EmailAddress()
                .Equal(x => x.Email)
                .NotNull().WithMessage("Não pode ser nulo.")
                .NotEmpty().WithMessage("Não pode ser vazio.");
            RuleFor(cp => cp.Idade)
                .NotNull().WithMessage("Não pode ser nulo.")
                .NotEmpty().WithMessage("Não pode ser vazio.")
                .Must(AutorMaiorDeIdade).WithMessage("Deve ter no mínimo 18 anos.");
        }

        //Validação customizada.
        private static bool AutorMaiorDeIdade(DateTime idade)
        {
            return idade <= DateTime.Now.AddYears(-18);
        }
    }
}
