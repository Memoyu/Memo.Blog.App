using Masa.Blazor;
using Memo.Blog.App.Models.App;
using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Components.Components;

public partial class SummaryCard
{
    private int columns => 12 / Columns!.ToInt32();

    [Parameter] public StringNumber? Columns { get; set; } = 3;

    [Parameter]
    public List<SummaryCardItem> Items { get; set; } = [];

    //private List<SummaryCardItem> _items = [];
    //[Parameter]
    //public List<SummaryCardItem> Items
    //{
    //    get => _items;
    //    set
    //    {
    //        if (_items == value) return;
    //        _items = value;
    //        ItemsChanged.InvokeAsync(value);
    //    }
    //}

    //[Parameter] public EventCallback<List<SummaryCardItem>> ItemsChanged { get; set; }
}
