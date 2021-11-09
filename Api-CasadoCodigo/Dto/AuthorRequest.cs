using Api_CasadoCodigo.Model;
using System.ComponentModel.DataAnnotations;

namespace Api_CasadoCodigo.Dto
{
    public class AuthorRequest
    {
        [Required]
        [StringLength(10)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(400, ErrorMessage = "Decrição muito grande.")]
        public string Description { get;  set; }

        public Author ToModel()
        {
            return new Author(
                this.Name,
                this.Email,
                this.Description
            );
        }

        public override string ToString()
            => $"{Name} - {Email} - {Description}";
    }
}
