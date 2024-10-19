using Masa.Blazor;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Memo.Blog.App.Common;

namespace Memo.Blog.App.Components.Components.Markdown;

public partial class MarkdownEdit
{
    //[Inject] IMediaResourceManager MediaResourceManager { get; set; } = default!;
    //[Inject] IAppFileManager AppFileManager { get; set; } = default!;
    [Inject] MarkdownJsModule Module { get; set; } = default!;
    [Inject] ILogger<MarkdownEdit> Logger { get; set; } = default!;

    [CascadingParameter(Name = "IsDark")]
    public bool Dark { get; set; }
    [Parameter] public string? Value { get; set; }
    [Parameter] public EventCallback<string> ValueChanged { get; set; }
    [Parameter] public string? Class { get; set; }
    [Parameter] public string? WrapClass { get; set; }
    [Parameter] public bool Autofocus { get; set; }
    [Parameter] public EventCallback OnAfter { get; set; }

    private const long maxAllowedSize = 512 * 1024 * 1024;
    private bool firstLineIndent;
    private bool codeLineNumber;
    private bool taskListLineThrough;
    private Dictionary<string, object>? _options;
    private MMarkdown mMarkdown = default!;
    private InputFile? inputFile;

    public async Task InsertValueAsync(string value)
    {
        if (string.IsNullOrEmpty(Value))
        {
            await Module.Focus(mMarkdown.Ref);
        }

        await mMarkdown.InsertValueAsync(value);
    }


    public ValueTask<string?> GetValueAsync() => mMarkdown.GetValueAsync();

    protected override void OnInitialized()
    {
        base.OnInitialized();

        firstLineIndent = true;
        codeLineNumber = true;
        taskListLineThrough = true;
        SetOptions();
    }

    private string? InternalClass => $"{Class} {(firstLineIndent ? "first-line-indent" : "")} {(taskListLineThrough ? "task-list-line-through" : "")}";


    private void SetOptions()
    {
        string theme = Dark ? "dark" : "light";
        var previewTheme = new Dictionary<string, object?>()
            {
                { "current", theme },
                { "path", "npm/vditor/3.10.6/dist/css/content-theme" }
            };
        var previewHljs = new Dictionary<string, object>()
            {
                { "lineNumber", codeLineNumber }
            };
        var previewMarkdown = new Dictionary<string, object?>()
            {
                { "toc", true },
                { "mark", true }
            };
        var preview = new Dictionary<string, object?>()
            {
                { "theme", previewTheme },
                { "hljs", previewHljs },
                { "markdown", previewMarkdown },
            };
        var link = new Dictionary<string, object?>()
            {
                { "isOpen", false }
            };
        var btnImage = new Dictionary<string, object?>()
            {
                { "hotkey", "⇧⌘I" },
                { "name", "image" },
                { "tipPosition", "n" },
                { "tip", "添加图片" },
                { "className", "" },
                { "icon", "<svg><use xlink:href=\"#vditor-icon-image\"></use></svg>" },
            };

        var btnAudio = new Dictionary<string, object?>()
            {
                { "hotkey", "⇧⌘A" },
                { "name", "audio" },
                { "tipPosition", "n" },
                { "tip", "添加音频" },
                { "className", "" },
                { "icon", "<svg><use xlink:href=\"#vditor-icon-audio\"></use></svg>" },
            };
        var btnVideo = new Dictionary<string, object?>()
            {
                { "hotkey", "⇧⌘V" },
                { "name", "video" },
                { "tipPosition", "n" },
                { "tip", "添加视频" },
                { "className", "" },
                { "icon", "<svg><use xlink:href=\"#vditor-icon-video\"></use></svg>" },
            };
        var btnUpload = new Dictionary<string, object?>()
            {
                { "name", "upload" },
                { "className", "d-none" },
            };
        string[] accept = ["image/*", "audio/*", "video/*"];
        var upload = new Dictionary<string, object?>()
            {
                { "max", maxAllowedSize },
                { "accept", accept },
            };

        _options = new()
            {
                { "mode", "ir" },
                { "toolbar", new object[]{"headings", "bold", "italic", "strike", "line", "quote","list", "ordered-list", "check", "indent", "outdent", "code", "inline-code", "link", btnImage, btnAudio, btnVideo, "undo", "redo", "fullscreen", btnUpload }},
                { "placeholder", "请输入内容" },
                { "cdn", "npm/vditor/3.10.6" },
                //{ "lang", lang },
                { "icon","material" },
                { "theme", theme },
                { "preview", preview },
                { "link", link },
                { "typewriterMode", true },
                { "height", "100%" },
                { "upload", upload },
            };
    }

    private async Task AfterMarkdownRender()
    {
        await Module.After(mMarkdown.Ref);
        if (Autofocus)
        {
            await Module.Autofocus(mMarkdown.Ref);
        }

        if (OnAfter.HasDelegate)
        {
            await OnAfter.InvokeAsync();
        }
    }

    private async void HandleToolbarButtonClick(string btnName)
    {
        switch (btnName)
        {
            case "image":
                await AddImageAsync();
                break;
            case "audio":
                await AddAudioAsync();
                break;
            case "video":
                await AddVideoAsync();
                break;
        }
    }

    private async Task AddImageAsync()
    {
        // TODO 实现md功能
        //var resources = await MediaResourceManager.AddMultipleImageAsync();
        //await AddMediaFilesAsync(resources);
    }

    private async Task AddAudioAsync()
    {
        // TODO 实现md功能
        //var resources = await MediaResourceManager.AddMultipleAudioAsync();
        //await AddMediaFilesAsync(resources);
    }

    private async Task AddVideoAsync()
    {
        // TODO 实现md功能
        //var resources = await MediaResourceManager.AddMultipleVideoAsync();
        //await AddMediaFilesAsync(resources);
    }

    //private async Task AddMediaFilesAsync(IEnumerable<ResourceModel>? resources)
    //{
    //    string? insertContent = CreateInsertContent(resources);
    //    if (insertContent is null) return;

    //    await InsertValueAsync(insertContent);
    //}

    //private static string? CreateInsertContent(string src, MediaResource mediaResource)
    //{
    //    return mediaResource switch
    //    {
    //        MediaResource.Image => $"![]({src})",
    //        MediaResource.Audio => $"<audio src=\"{src}\" controls ></audio>",
    //        MediaResource.Video => $"<video src=\"{src}\" controls ></video>",
    //        _ => null
    //    };
    //}

    //public async Task<string?> CreateInsertContent(List<string?> filePaths)
    //{
    //    var resources = await MediaResourceManager.AddMediaFilesAsync(filePaths);
    //    return CreateInsertContent(resources);
    //}

    //static string? CreateInsertContent(IEnumerable<ResourceModel>? resources)
    //{
    //    if (resources is null) return null;
    //    var insertContents = resources.Select(it => CreateInsertContent(it.ResourceUri!, it.ResourceType));
    //    return string.Join("\n", insertContents);
    //}

    private async Task HandleBeforeAllUpload()
    {
        await Module.Upload(mMarkdown.Ref, inputFile?.Element);
    }

    private async void LoadFiles(InputFileChangeEventArgs e)
    {
        //List<string?> filePaths = [];
        //foreach (var browserFile in e.GetMultipleFiles())
        //{
        //    var kind = MediaResourceManager.GetResourceKind(browserFile.Name);
        //    if (kind == MediaResource.Unknown)
        //    {
        //        continue;
        //    }

        //    try
        //    {
        //        var filePath = await AppFileManager.CreateTempFileAsync(browserFile.Name, browserFile.OpenReadStream(maxAllowedSize));
        //        filePaths.Add(filePath);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogInformation(ex, "OpenReadStream error");
        //    }
        //}
        //if (filePaths.Count == 0)
        //{
        //    return;
        //}

        //var insertContent = await CreateInsertContent(filePaths);
        //if (string.IsNullOrEmpty(insertContent))
        //{
        //    return;
        //}

        // await InsertValueAsync(insertContent);
    }
}
