using Masa.Blazor.JSInterop;
using Microsoft.JSInterop;

namespace Memo.Blog.App.Extensions.Masa;

public class JsModuleExtension : JSModule
{
    public JsModuleExtension(IJSRuntime js, string moduleUrl) : base(js, $"./{moduleUrl}")
    {
    }
}

