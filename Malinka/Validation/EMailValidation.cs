using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Windows.Controls;

namespace Malinka.Validation
{
    class EMailValidation : ValidationRule
    {
        public override System.Windows.Controls.ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            EmailAddressAttribute emailAddress = new EmailAddressAttribute();

            if (!emailAddress.IsValid(value))
            {
                return new System.Windows.Controls.ValidationResult(false, "EMAIL GOVNO!");
            }
            else return new System.Windows.Controls.ValidationResult(true, null);
        }
    }
}
