namespace Memo.Blog.App.Models.Moment;

public class PageMomentQuery : PaginationQuery
{
    public List<string>? Tags { get; set; }

    public string? Content { get; set; }

    public DateTime? DateBegin { get; set; }

    public DateTime? DateEnd { get; set; }
}
