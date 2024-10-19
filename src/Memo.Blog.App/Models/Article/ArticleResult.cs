using Memo.Blog.App.Common;

namespace Memo.Blog.App.Models.Article;

public class ArticleResult
{ /// <summary>
  /// 文章Id
  /// </summary>
    public string ArticleId { get; set; }

    /// <summary>
    /// 所属分类
    /// </summary>
    public CategoryResult Category { get; set; } = new();

    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// 正文
    /// </summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// 描述
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// 文章横幅图
    /// </summary>
    public string Banner { get; set; } = string.Empty;

    /// <summary>
    /// 文章缩略图封面图
    /// </summary>
    public string Thumbnail { get; set; } = string.Empty;

    /// <summary>
    /// 字数
    /// </summary>
    public int WordNumber { get; set; }

    /// <summary>
    /// 预计阅读时长
    /// </summary>
    public int ReadingTime { get; set; }

    /// <summary>
    /// 文章状态
    /// </summary>
    public ArticleStatus Status { get; set; }

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
    /// 关联标签
    /// </summary>
    public List<TagResult> Tags { get; set; } = [];

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? UpdateTime { get; set; }
}
