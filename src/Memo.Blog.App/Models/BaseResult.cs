using System.ComponentModel;

namespace Memo.Blog.App.Models;

public record BaseResult
{
    public bool IsSuccess => Code == ResultCode.Success;

    public ResultCode Code { get; set; }

    public string Message { get; set; }
}

public record BaseResult<T> : BaseResult
{
    public T? Data { get; set; }
}

/// <summary>
/// 服务响应Code
/// </summary>
public enum ResultCode
{
    [Description("失败")]
    Failure = 0,

    [Description("成功")]
    Success = 1,

    [Description("令牌过期")]
    TokenExpired = 4010,

    [Description("无效令牌")]
    TokenInvalidation = 4011,

    [Description("认证失败")]
    AuthenticationFailure = 4012,

    [Description("未授权")]
    Forbidden = 4030,
}

