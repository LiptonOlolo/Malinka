using DevExpress.Mvvm;
using Malinka.Core.Models;
using Prism.Regions;

namespace Malinka.ViewModels.Base
{
    /// <summary>
    /// Navigation view model.
    /// </summary>
    abstract class NavigationViewModel : ViewModelBase, INavigationAware
    {
        /// <summary>
        /// User.
        /// </summary>
        public MalinkaUser User { get; private set; }

        /// <summary>
        /// Navigated to current view.
        /// </summary>
        /// <param name="navigationContext">Parameters.</param>
        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey("user"))
            {
                var user = navigationContext.Parameters["user"] as MalinkaUser;

                User = user;
            }
        }

        /// <summary>
        /// ?
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        /// <summary>
        /// ?
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
