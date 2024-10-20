using Memo.Blog.App.Components.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Memo.Blog.App.Components.Components.Image;

public partial class ImagePreview : DialogComponentBase
{
    [Parameter] public string Src { get; set; } = string.Empty;

    [Inject] ImageJsModule Module { get; set; } = default!;

    ElementReference _previewImg;
    double _zoomOutTimes = 1;
    int _rotateTimes;
    bool _visible = true;
    string _left = "50%";
    string _top = "50%";

    private async Task BeforeShowContent()
    {
        await Module.ImgDragAndDrop(_previewImg);
    }

    private void HandleZoomIn()
    {
        _zoomOutTimes++;
    }

    private void HandleZoomOut()
    {
        if (int.Parse(_zoomOutTimes.ToString()) > 1)
        {
            _zoomOutTimes--;
        }
    }

    private void HandleRotateRight()
    {
        _rotateTimes++;
    }

    private void HandleRotateLeft()
    {
        _rotateTimes--;
    }

    private async Task WeelHandZoom(WheelEventArgs wheelEventArgs)
    {
        _left = await Module.GetStyle(_previewImg, "left") ?? string.Empty;
        _top = await Module.GetStyle(_previewImg, "top") ?? string.Empty;

        if (wheelEventArgs.DeltaY < 0)
        {
            _zoomOutTimes += 0.1;
        }
        else if (_zoomOutTimes > 0.5)
        {
            _zoomOutTimes -= 0.1;
        }
    }
}
