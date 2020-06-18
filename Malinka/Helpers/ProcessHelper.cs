using System.Diagnostics;
using System.Windows;

namespace Malinka.Helpers
{
    static class ProcessHelper
    {
        public static void RestartApp()
        {
            Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
    }
}
