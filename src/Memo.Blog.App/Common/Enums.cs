using System.ComponentModel;

namespace Memo.Blog.App.Common;

/// <summary>
/// 文章状态
/// </summary>
public enum ArticleStatus
{
    [Description("草稿")]
    Draft = 0,

    [Description("已发布")]
    Published = 1,

    [Description("下线")]
    Offline = 2,
}

public enum FileStoragPathType
{
    ArticlesBanner,

    MomentContent,

    AboutContent,

    AccountAvatar,

    ConfigBanner
}
