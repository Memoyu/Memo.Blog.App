using Memo.Blog.App.Common;

namespace Memo.Blog.App.Models.Article;

public class PageArticleResult
{
    /// <summary>
    /// 文章Id
    /// </summary>
    public string ArticleId { get; set; } = string.Empty;

    /// <summary>
    /// 所属分类
    /// </summary>
    public required CategoryResult Category { get; set; }

    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// 关联标签
    /// </summary>
    public List<TagResult> Tags { get; set; } = [];

    /// <summary>
    /// 文章状态
    /// </summary>
    public ArticleStatus Status { get; set; }

    /// <summary>
    /// 评论条数
    /// </summary>
    public int Comments { get; set; }

    /// <summary>
    /// 浏览次数
    /// </summary>
    public int Views { get; set; }

    /// <summary>
    /// 点赞次数
    /// </summary>
    public int Likes { get; set; }

    /// <summary>
    /// 是否置顶
    /// </summary>
    public bool IsTop { get; set; }

    /// <summary>
    /// 是否开启评论
    /// </summary>
    public bool Commentable { get; set; }

    /// <summary>
    /// 是否公开
    /// </summary>
    public bool Publicable { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? UpdateTime { get; set; }

    /// <summary>
    /// 发布时间
    /// </summary>
    public DateTime? PublishTime { get; set; }
}
