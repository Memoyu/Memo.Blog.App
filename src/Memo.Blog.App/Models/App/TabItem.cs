namespace Memo.Blog.App.Models.App;

public record TabItem
{
    public TabItem(string title, string key, bool isInit = false)
    {
        Title = title;
        Key = key;
        IsInit = isInit;
    }

    public string Title { get; set; }

    public string Key { get; set; }

    public bool IsInit { get; set; }
}
