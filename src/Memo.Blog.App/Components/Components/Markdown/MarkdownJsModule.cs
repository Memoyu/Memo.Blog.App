using Memo.Blog.App.Extensions.Masa;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Memo.Blog.App.Components.Components.Markdown;

public class MarkdownJsModule : JsModuleExtension
{
        public MarkdownJsModule(IJSRuntime js) : base(js, "js/markdown-helper.js")
        {
        }

        public async Task After(ElementReference element)
        {
            await base.InvokeVoidAsync("after", element);
        }

        public async Task Focus(ElementReference element)
        {
            await base.InvokeVoidAsync("focus", element);
        }

        public async Task Autofocus(ElementReference element)
        {
            await base.InvokeVoidAsync("autofocus", element);
        }

        public async Task Upload(ElementReference element, ElementReference? inputFileElement)
        {
            await base.InvokeVoidAsync("upload", element, inputFileElement);
        }
    }

