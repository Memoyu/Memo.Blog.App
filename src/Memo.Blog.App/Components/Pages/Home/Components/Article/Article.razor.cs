using Masa.Blazor;
using Memo.Blog.App.Models.App;
using Memo.Blog.App.Models.Article;
using Memo.Blog.App.Services;
using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Components.Pages.Home.Components.Article;

public partial class Article
{
    [Inject] public ArticleService ArticleService { get; set; } = default!;

    private List<SummaryCardItem> _summaries =
    [
        new SummaryCardItem ("文章", "0"),
        new SummaryCardItem ("评论", "0"),
        new SummaryCardItem ("浏览", "0"),
    ];

    private bool isInit = false;
    private List<PageArticleResult> _articles = [];
    private int _page = 1;
    private int _pageSize = 15;
    private MInfiniteScroll? _infiniteScroll;


    public async Task InitAsync()
    {
        isInit = true;
        if (_infiniteScroll != null)
        {
            await _infiniteScroll.ResetAsync();
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
    }

    private async Task HandleOnLoadAsync(InfiniteScrollLoadEventArgs args)
    {
        if (!isInit)
        {
            args.Status = InfiniteScrollLoadStatus.Empty;
            return;
        }

        // TODO：获取文章汇总数据
        var isFirstLoad = _page == 1;

        var page = await ArticleService.ArticlePageAsync(new PageArticleQuery
        {
            Page = _page++,
            Size = _pageSize,
        });
        var appendArticles = page.Items;

        if (isFirstLoad)
        {
            _articles = appendArticles;
        }
        else
        {
            _articles.AddRange(appendArticles);
        }

        args.Status = _articles.Count >= page.Total ? InfiniteScrollLoadStatus.Empty : InfiniteScrollLoadStatus.Ok;
    }

    private async Task HandleOnRefreshAsync()
    {
        _page = 1;

        if (_infiniteScroll != null)
        {
            await _infiniteScroll.ResetAsync();
        }
    }

}
