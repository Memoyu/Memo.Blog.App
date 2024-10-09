namespace Memo.Blog.App.Models.App;

public record SummaryCardItem
{
    public SummaryCardItem(string title, string value)
    {
        Title = title;
        Value = value;
    }
    public string Title { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}
