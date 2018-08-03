using System.Globalization;
using System.Windows.Controls;

namespace MaterialDesignDemo.Domain
{
    //This class is used for the MaterialDesign NuGet Package
    public class NotEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return string.IsNullOrWhiteSpace((value ?? "").ToString())
                ? new ValidationResult(false, "Field is required.")
                : ValidationResult.ValidResult;
        }
    }
}