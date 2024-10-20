﻿using Masa.Blazor;
using Masa.Blazor.Presets;
using Memo.Blog.App.Components.Components.Markdown;
using Memo.Blog.App.Components.Components.Textarea;
using Memo.Blog.App.Models.App;
using Memo.Blog.App.Models.Article;
using Memo.Blog.App.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Memo.Blog.App.Components.Pages.Article
{
    public partial class ArticleEdit
    {
        [Parameter] public string? Id { get; set; }

        [Inject] ArticleService ArticleService { get; set; } = default!;
        [Inject] PageStackNavController NavController { get; set; } = default!;
        [Inject] NavigationManager NavigationManager { get; set; } = default!;
        [Inject] IJSRuntime JSRuntime { get; set; } = default!;
        [Inject] IPopupService PopupService { get; set; } = default!;

        bool _showSelectTag = false;
        bool _showSelectBanner = false;
        bool _editText = true;
        bool _autofocus = false;

        List<SheetItem> _shareSheetItems = [];
        List<SheetItem> _configSheetItems = [];

        ArticleResult _article = new();

        MarkdownEdit markdownEdit = default!;
        TextareaEdit textareaEdit = default!;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            InitBaseData();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
            {
                await InitServiceDataAsync();
                StateHasChanged();
            }
        }

        private void InitBaseData()
        {
            _shareSheetItems =
            [
                new(this,"微信",  "$wechat", ShareToWeChat, "#07c160" ),
                new(this,"复制链接","mdi-link-variant", CopyLink),
            ];

            _configSheetItems =
            [
                new(this,"置顶",  "mdi-format-vertical-align-top", ShareToWeChat),
                new(this,"评论","mdi-comment-check-outline", CopyLink),
                new(this,"公开","mdi-eye-outline", CopyLink),
            ];
        }

        private async Task InitServiceDataAsync()
        {
            _article = await ArticleService.ArticleGetAsync(Id);
        }


        private void ShareToWeChat()
        {
        }

        private void CopyLink()
        {
            _ = JSRuntime.InvokeVoidAsync(JsInteropConstants.CopyText, NavigationManager.Uri);
            _ = PopupService.EnqueueSnackbarAsync("Link has been copied to clipboard.");
        }

        private async Task HandleLaunchActivation()
        {
        }
    }
}
