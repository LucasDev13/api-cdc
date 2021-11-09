using System;

namespace Api_CasadoCodigo.Model
{
    public class Author {

        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public int numero { get; set; }
        public DateTime Instant { get; set; }

        public Author(string name, string email, string description) {
            Name = name;
            Email = email;
            Description = description;
            this.Instant = DateTime.UtcNow;
        }

        public override string ToString()
            => $"{Name} - {Email} - {Description} - {numero} - {Instant}";


    }
}
