using DryIoc;
using Malinka.API.Client.Interfaces;
using Malinka.Lang.Properties;
using Malinka.Models;
using MaterialDesignXaml.DialogsHelper;
using MaterialDesignXaml.DialogsHelper.Enums;
using System.Threading.Tasks;

namespace Malinka.Dialogs
{
    /// <summary>
    /// Sign up view model.
    /// </summary>
    [DialogName(nameof(SignUpView))]
    class SignUpViewModel : BaseDialogViewModel, IDialogIdentifier
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public string Identifier => nameof(SignUpViewModel);

        /// <summary>
        /// User for sign up.
        /// </summary>
        public SignUpUser User { get; }

        /// <summary>
        /// Sign up.
        /// </summary>
        readonly ISignUp signUp;

        /// <summary>
        /// Ctor for design.
        /// </summary>
        public SignUpViewModel()
        {
            User = new SignUpUser();
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        public SignUpViewModel(ISignUp signUp, IContainer container) : base(container)
        {
            this.signUp = signUp;

            User = new SignUpUser();
        }

        /// <summary>
        /// Can close dialog.
        /// </summary>
        /// <returns></returns>
        protected override bool CanCloseDialog()
        {
            return User.IsValid;
        }

        /// <summary>
        /// Sign up & close.
        /// </summary>
        /// <returns></returns>
        protected override async Task CloseDialog()
        {
            var res = await signUp.SignUpAsync(User.EMail, User.Nickname);

            if (!res)
            {
                Logger.Log.Error($"Sign Up error: {res.Code}");
                await this.ShowMessageBoxAsync(res.ToString(), MaterialMessageBoxButtons.Ok);
            }
            else if (!res.Result)
            {
                Logger.Log.Info($"Unsuccessful sign up {GetLog()}");
                await this.ShowMessageBoxAsync(res.Result.ToString(), MaterialMessageBoxButtons.Ok);
            }
            else
            {
                Logger.Log.Info($"Successful sign up {GetLog()}");
                await this.ShowMessageBoxAsync(Resources.Result_SucessfulSignUp, MaterialMessageBoxButtons.Ok);
                OwnerIdentifier.Close();
            }

            string GetLog() => $"(email: {User.EMail}, nick: {User.Nickname})";
        }
    }
}