using Malinka.Lang.Properties;
using Malinka.ViewModels.Base;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Malinka.Models
{
    /// <summary>
    /// User for Sign Up page.
    /// </summary>
    public class SignUpUser : ValidateViewModel
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        public SignUpUser()
        {
#if DEBUG
            EMail = "test@mail.ru";
            Nickname = "test_nick";
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
        /// Nickname.
        /// </summary>
        [Display(Name = nameof(Resources.Nickname), ResourceType = typeof(Resources))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_NotEmpty))]
        [StringLength(20, MinimumLength = 4, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_Length))]
        public string Nickname { get; set; }
    }
}
