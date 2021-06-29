using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ValidationCustom
{
    public class CustomFecha : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            DateTime fecha = (DateTime)value;
            if (fecha.Year >= DateTime.Now.Year) return false;
            return true;
        }
    }
}
