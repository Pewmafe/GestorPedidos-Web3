using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public int Cuit { get; set; }
    }
}
