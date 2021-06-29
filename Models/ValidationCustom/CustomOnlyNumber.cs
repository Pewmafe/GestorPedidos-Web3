using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

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
