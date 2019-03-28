using System;
using System.Windows.Controls;
using System.Globalization;

namespace AlgorithmTrainer.Validation
{
    public class MyValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var error = ControleForm(value);

            return (error) ? new ValidationResult(false, "This field is required") : new ValidationResult(true, null);
        }
        public static bool ControleForm(object value)
        {
            if (value == null || ((String.IsNullOrEmpty((value.ToString())) || String.IsNullOrWhiteSpace((value.ToString())))))
            {
                return true;
            }
            return false;
        }
    }
}
