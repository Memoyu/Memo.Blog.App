﻿namespace Memo.Blog.App.Common;

public class Configs
{
    // public static string Base = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2" : "http://192.168.3.86";
    // public static string Base = "http://10.0.2.2";
    public static string Base = "http://192.168.3.86"; // "http://localhost";

    public static string ApiUrl = $"{Base}:11010/api/";
}
