using Masa.Blazor;
using Memo.Blog.App.Models.App;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;

namespace Memo.Blog.App.Components.Layout;

public partial class TopTabs
{
    const string defaultQueryParameterKey = "tabs";

    private StringNumber? previousValue;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;

    [Parameter] public StringNumber? Value { get; set; }

    [Parameter] public EventCallback<StringNumber?> ValueChanged { get; set; }

    [Parameter] public List<TabItem> Items { get; set; } = [];

    [Parameter] public string? QueryParameterKey { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        await InitValueAsync();
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        UpdateQueryParameter();
    }

    private string InternalQueryParameterKey
        => string.IsNullOrEmpty(QueryParameterKey) ? defaultQueryParameterKey : QueryParameterKey;

    private async Task InitValueAsync()
    {
        var uri = new Uri(NavigationManager.Uri);
        var queryString = QueryHelpers.ParseQuery(uri.Query);
        if (queryString.TryGetValue(InternalQueryParameterKey, out var queryParameterValue))
        {
            var index = Items.FindIndex(it => it.Key == queryParameterValue.ToString());
            if (index >= 0)
            {
                Value = previousValue = index;
                if (ValueChanged.HasDelegate)
                {
                    await ValueChanged.InvokeAsync(Value);
                }

                return;
            }
        }

        Value = previousValue = 0;
    }

    private void UpdateQueryParameter()
    {
        if (previousValue != Value)
        {
            previousValue = Value;
            var index = Value?.ToInt32() ?? 0;
            var uri = NavigationManager.GetUriWithQueryParameter(InternalQueryParameterKey, Items[index].Key);
            NavigationManager.NavigateTo(uri, replace: true);
        }
    }
}
