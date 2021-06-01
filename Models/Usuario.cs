using System;

namespace Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
