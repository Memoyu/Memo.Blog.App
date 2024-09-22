using System.Text.Encodings.Web;
using System.Text.Json;

namespace Memo.Blog.App.Extensions;

public static class FormatExtension
{
    private static readonly JsonSerializerOptions _defaultOption = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    };

    public static string ToJson(this object obj, JsonSerializerOptions? options = null)
    {
        if (obj == null) return string.Empty;
        options ??= _defaultOption;
        return JsonSerializer.Serialize(obj, options);
    }

    public static T? ToDesJson<T>(this string json, JsonSerializerOptions? options = null)
    {
        if (string.IsNullOrWhiteSpace(json)) return default;
        options ??= _defaultOption;
        return JsonSerializer.Deserialize<T>(json, options);
    }
}
