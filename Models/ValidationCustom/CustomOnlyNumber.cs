using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Models.ValidationCustom
{
    class CustomOnlyNumber : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            string regexItem = "^[0-9 ]*$";
            string valor = value.ToString(); 

            return Regex.IsMatch(valor, regexItem);
        }
    }
}
