using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Models.ValidationCustom
{
   public  class CustomOnlyString : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            string regexItem = "^[a-zA-Z0-9 ]*$";
            string valor = (string)value;

            return Regex.IsMatch(valor, regexItem);
        }
    }
}
