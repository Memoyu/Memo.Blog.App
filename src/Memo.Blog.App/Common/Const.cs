namespace Memo.Blog.App.Common;

public class Const
{
    private static readonly Lazy<string?> _assemblyName = new(() => typeof(Const).Assembly.GetName().Name);

    public static string? AssemblyName => _assemblyName.Value;

    public const string TOKEN_CACHE_KEY = "user_token";

}
