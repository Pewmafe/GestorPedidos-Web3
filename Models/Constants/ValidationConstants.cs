using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Constants
{
    class ValidationConstants
    {
        public const string RequiredField = "Este campo es requerido";
        public const string OnlyString = "Por favor no ingrese caracteres especiales.";
        public const string OnlyNumber = "Por favor ingrese solo numeros";
        public const string MinLengthEightDigits = "Por favor ingrese al menos 8 digitos";
        public const string MaxLengthTenDigits = "Por favor ingrese un maximo de 10 digitos";
        public const string InvalidEmailFormat = "Por favor ingrese un formato de email valido.";
        public const string InvalidDate = "La fecha no debe ser mayor al dia de hoy";
        public const string TextMax300Characters = "Este campo no puede exceder los 300 caracteres";
        public const string TextMax50Characters = "Este campo no puede exceder los 50 caracteres";
    }
}
