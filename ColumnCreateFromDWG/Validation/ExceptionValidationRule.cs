using System.Globalization;
using System.Windows.Controls;

namespace ColumnCreateFromDWG.Validation
{
    public class ExceptionValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double result = 0;
            bool canConvert = double.TryParse(value as string, out result);

            return new ValidationResult(canConvert, "Not a valid value");
        }
    }
}
