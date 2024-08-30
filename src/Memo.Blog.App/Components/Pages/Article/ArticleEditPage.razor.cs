﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Memo.Blog.App.Components.Pages.Article
{
    public partial class ArticleEditPage
    {
        [Inject]
        protected IJSRuntime JS { get; set; } = default!;


        private async Task NavigateToBack()
        {
            await JS.InvokeVoidAsync("history.back");
        }
    }
}
