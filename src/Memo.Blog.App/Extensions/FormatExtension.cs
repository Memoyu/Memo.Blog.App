using System.Text.Json;

namespace Memo.Blog.App.Extensions;

public static class FormatExtension
{
    public static string ToJson(this object obj, JsonSerializerOptions? options = null)
    {
        if (obj == null) return string.Empty;
        return JsonSerializer.Serialize(obj, options);
    }

    public static T? ToDesJson<T>(this string json, JsonSerializerOptions? options = null)
    {
        if (string.IsNullOrWhiteSpace(json)) return default;
        return JsonSerializer.Deserialize<T>(json, options);
    }
}
