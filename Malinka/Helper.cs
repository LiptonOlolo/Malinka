using Malinka.Lang.Properties;
using MaterialDesignThemes.Wpf;

namespace Malinka
{
    static class Helper
    {
        public static void EnqueueWithCloseButton(this ISnackbarMessageQueue messageQueue, string text)
        {
            messageQueue.Enqueue(text, Resources.Close, () => { });
        }

        public static bool IsEmpty(this string str)
        {
            return string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
        }
    }
}
