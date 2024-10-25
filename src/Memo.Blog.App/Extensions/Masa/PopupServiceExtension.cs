using Masa.Blazor;

namespace Memo.Blog.App.Extensions.Masa
{
    public static class PopupServiceExtension
    {
        public static Task Info(this IPopupService popup, string message) => popup.EnqueueSnackbarAsync(message, AlertTypes.Info);

        public static Task Info(this IPopupService popup, string title, string message) => popup.EnqueueSnackbarAsync(title, message, AlertTypes.Info);

        public static Task Success(this IPopupService popup, string message) => popup.EnqueueSnackbarAsync(message, AlertTypes.Success);

        public static Task Success(this IPopupService popup, string title, string message) => popup.EnqueueSnackbarAsync(title, message, AlertTypes.Success);

        public static Task Warning(this IPopupService popup, string message) => popup.EnqueueSnackbarAsync(message, AlertTypes.Warning);

        public static Task Warning(this IPopupService popup, string title, string message) => popup.EnqueueSnackbarAsync(title, message, AlertTypes.Warning);

        public static Task Error(this IPopupService popup, string message) => popup.EnqueueSnackbarAsync(message, AlertTypes.Error);

        public static Task Error(this IPopupService popup, string title, string message) => popup.EnqueueSnackbarAsync(title, message, AlertTypes.Error);
    }
}
