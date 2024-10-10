using Memo.Blog.App.Common;

namespace Memo.Blog.App.Models.Article
{
    public class PageArticleQuery : PaginationQuery
    {
        public string? Title { get; set; }

        public long? CategoryId { get; set; }

        public List<long>? TagIds { get; set; }

        public ArticleStatus? Status { get; set; }
    }
}
