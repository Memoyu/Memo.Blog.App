namespace Memo.Blog.App.Models.Moment;

public class MomentResult
{
    public string MomentId { get; set; }

    /// <summary>
    /// 动态标签
    /// </summary>
    public List<string> Tags { get; set; } = [];

    /// <summary>
    /// 动态内容
    /// </summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// 点赞次数
    /// </summary>
    public int Likes { get; set; }

    /// <summary>
    /// 是否展示
    /// </summary>
    public bool Showable { get; set; }

    /// <summary>
    /// 是否开启评论
    /// </summary>
    public bool Commentable { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }
}
