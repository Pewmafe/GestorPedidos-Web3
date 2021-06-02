using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Client : IAuditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public int Cuit { get; set; }
        public int CreatedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime CreatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int UpdateBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime UpdateDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int DeletedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime DeletedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Delete { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
