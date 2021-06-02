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
            string regexItem = "^[0-9 ]*$";
            string valor = (string)value;

            return Regex.IsMatch(valor, regexItem);
        }
    }
}
