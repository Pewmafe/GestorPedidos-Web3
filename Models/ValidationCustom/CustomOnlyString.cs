using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Models.ValidationCustom
{
    public class CustomOnlyString : ValidationAttribute
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
