namespace Memo.Blog.App.Common;

public class Configs
{
    public static string Base = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2" : "http://localhost";
    // public static string Base = "http://10.0.2.2";

    public static string ApiUrl = $"{Base}:11010/";
}
