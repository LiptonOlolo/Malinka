using DryIoc;
using MaterialDesignXaml.DialogsHelper;
using Prism.DryIoc;
using Prism.Ioc;
using System;
using System.Windows;

namespace Malinka
{
    static class ContainerHelper
    {
        public static void RegisterDialogView<T, TVM>(this IContainerRegistry containerRegistry) where T : FrameworkElement
                                                                                                 where TVM : class
        {
            containerRegistry.RegisterDialogView<T>();
            containerRegistry.RegisterSingleton<TVM>();
        }

        public static void RegisterDialogView<T>(this IContainerRegistry containerRegistry) where T : FrameworkElement
        {
            containerRegistry.Register<FrameworkElement, T>(typeof(T).Name);
        }

        public static IDialogIdentifier ResolveRootDialogIdentifier(this IContainer container)
        {
            return container.Resolve<IDialogIdentifier>("rootdialog");
        }

        public static void RegisterDelegate<T>(this IContainerRegistry containerRegistry,
                                               Func<IResolverContext, T> func,
                                               IReuse reuse,
                                               string key = null)
        {
            containerRegistry.GetContainer().RegisterDelegate(func, reuse, serviceKey: key);
        }
    }
}
