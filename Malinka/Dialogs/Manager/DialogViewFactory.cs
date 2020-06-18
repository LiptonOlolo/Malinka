using DryIoc;
using System;
using System.Windows;

namespace Malinka.Dialogs.Manager
{
    /// <summary>
    /// Dialog view factory.
    /// </summary>
    class DialogViewFactory : IDialogViewFactory
    {
        /// <summary>
        /// Container.
        /// </summary>
        readonly IContainer container;

        /// <summary>
        /// Ctor.
        /// </summary>
        public DialogViewFactory(IContainer container)
        {
            this.container = container;
        }

        /// <summary>
        /// Get view.
        /// </summary>
        /// <returns></returns>
        public object GetView<TViewModel>(TViewModel viewModel)
        {
            var atr = (DialogNameAttribute)Attribute.GetCustomAttribute(typeof(TViewModel), typeof(DialogNameAttribute));

            if (atr == null)
            {
                Logger.Log.Error($"DialogNameAttribute is null, ViewModel: {viewModel}");
                return null;
            }

            var view = container.Resolve<FrameworkElement>(atr.View);

            if (view.GetType().Name == nameof(FrameworkElement))
            {
                Logger.Log.Error($"GetView<T> view is null, ViewModel: {viewModel}");
                return null;
            }

            view.DataContext = viewModel;

            return view;
        }
    }
}
