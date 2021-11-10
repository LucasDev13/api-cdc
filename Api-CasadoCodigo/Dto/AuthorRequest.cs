using Api_CasadoCodigo.Application.Validation;
using Api_CasadoCodigo.Model;
using FsCheck;
using System;
using System.ComponentModel.DataAnnotations;

namespace Api_CasadoCodigo.Dto
{
    public class AuthorRequest
    {
        public string Name { get; set; }
        [EmailCustomValidation]
        [BlockDomainValidator("gmail.com")]
        public string Email { get; set; }
        public string Description { get;  set; }
        public DateTime Idade { get; set; }

        public AuthorRequest()
        {
        }

        public override bool Equals(object obj)
        {
            return obj is AuthorRequest request &&
                   Description == request.Description;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Description);
        }

        public override string ToString()
            => $"{Name} - {Email} - {Description}";
    }
}
