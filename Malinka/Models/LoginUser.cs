using Malinka.Lang.Properties;
using Malinka.ViewModels.Base;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Malinka.Models
{
    /// <summary>
    /// User for login page.
    /// </summary>
    public class LoginUser : ValidateViewModel
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        public LoginUser()
        {
#if DEBUG
            EMail = "test@mail.ru";
            Password = "123456789";
#endif
        }

        /// <summary>
        /// Email for login page.
        /// </summary>
        [Display(Name = nameof(Resources.EMail), ResourceType = typeof(Resources))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_NotEmpty))]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_NeedEMail))]
        public string EMail { get; set; }

        /// <summary>
        /// Password for login page.
        /// </summary>
        [Display(Name = nameof(Resources.PasswordBox), ResourceType = typeof(Resources))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_NotEmpty))]
        [StringLength(20, MinimumLength = 9, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Length))]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_PasswordRegex))]
        public string Password { get; set; }
    }
}
