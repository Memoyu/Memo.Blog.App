using Microsoft.AspNetCore.Components.Web;

namespace Memo.Blog.App.Components.Base;

public class DialogComponentBase : VisibilityComponentBase
{
    protected virtual async Task HandleCancel(MouseEventArgs _)
    {
        await InternalVisibleChanged(false);
    }
}
