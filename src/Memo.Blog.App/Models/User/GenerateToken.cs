namespace Memo.Blog.App.Models.User;

public record TokenGenerateRequest(
    string Username,
    string Password
);


public record TokenGenerateResult(
    string UserId,
    string Username,
    string AccessToken,
    string RefreshToken,
    DateTime ExpiredAt
);
