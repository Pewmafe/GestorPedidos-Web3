using Models.ValidationCustom;
using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Item : IAuditable
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [CustomOnlyNumber(ErrorMessage = "Por favor ingrese solo numeros")]
        public int Code { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Description { get; set; }
        public int CreatedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime CreatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int UpdateBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime UpdateDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int DeletedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime DeletedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Deleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
