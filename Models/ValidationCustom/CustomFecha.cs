using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ValidationCustom
{
    public class CustomFecha : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            DateTime fecha = (DateTime)value;
            if (fecha.Year >= DateTime.Now.Year) return false;
            return true;
        }
    }
}
