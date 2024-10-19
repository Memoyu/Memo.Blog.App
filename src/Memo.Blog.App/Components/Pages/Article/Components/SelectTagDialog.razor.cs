using Masa.Blazor;
using Memo.Blog.App.Models.Article;
using Memo.Blog.App.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Memo.Blog.App.Components.Pages.Article.Components;

public partial class SelectTagDialog
{
    [Parameter] public virtual bool Visible { get; set; }
    [Parameter] public EventCallback<bool> VisibleChanged { get; set; }
    [Parameter] public List<TagResult> Tags { get; set; } = [];
    [Parameter] public CategoryResult Category { get; set; } = new();
    [Parameter] public EventCallback<List<TagResult>> TagsChanged { get; set; }
    [Parameter] public EventCallback<CategoryResult> CategoryChanged { get; set; }

    [Inject] protected TagService TagService { get; set; } = default!;
    [Inject] protected CategoryService CategoryService { get; set; } = default!;

    List<StringNumber> _selectedTags = [];
    string _selectCategory = string.Empty;
    List<TagResult> _allTags = [];
    List<CategoryResult> _allCategories = [];
    bool _showInput;
    string _inputValue = string.Empty;
    string _inputLabel = "标签名称";
    int _addType = 1; // 1: 标签； 2：分类

    private async Task BeforeShowContent()
    {
        _allTags = await TagService.ArticleTagListAsync();
        _allCategories = await CategoryService.ArticleCategoryListAsync();

        var selectedTags = new List<StringNumber>();
        Tags.ForEach(t =>
        {
            selectedTags.Add(t.TagId);
        });
        _selectedTags = selectedTags;

        _selectCategory = Category.CategoryId;
    }

    private void HandleAddTag()
    {
        _showInput = true;
        _addType = 1;
        _inputLabel = "标签名称";
    }

    private void HandleAddCategory()
    {
        _showInput = true;
        _addType = 2;
        _inputLabel = "分类名称";
    }

    private async Task HandleSaveTagOrCategory()
    {
        // TODO: 保存标签或分类
    }

    private async Task HandleCancel()
    {
        await InternalVisibleChanged(false);
    }

    private async Task HandleSave()
    {
        var tags = new List<TagResult>();
        _selectedTags.ForEach(st =>
        {
            var tag = _allTags.FirstOrDefault(t => t.TagId == st);
            if (tag is not null)
            {
                tags.Add(tag);
            }
        });
        Tags = tags;
        if (TagsChanged.HasDelegate)
        {
            await TagsChanged.InvokeAsync(tags);
        }

        var category = _allCategories.FirstOrDefault(c => c.CategoryId == _selectCategory);
        if (category is not null)
        {
            Category = category;
        }
        if (CategoryChanged.HasDelegate)
        {
            await CategoryChanged.InvokeAsync(Category);
        }

        await InternalVisibleChanged(false);
    }

    protected virtual async Task InternalVisibleChanged(bool value)
    {
        Visible = value;

        if (VisibleChanged.HasDelegate)
        {
            await VisibleChanged.InvokeAsync(value);
        }
    }
}
