using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Components.Components;

public partial class DateDigitalClockSheet
{
    [Parameter] public bool Show { get; set; }
    [Parameter] public EventCallback<bool> ShowChanged { get; set; }
    [Parameter] public DateTime Value { get; set; }
    [Parameter] public EventCallback<DateTime> ValueChanged { get; set; }

    private DateTime _internalDate;
    private bool _previousShow;

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (_previousShow != Show)
        {
            _previousShow = Show;

            if (Show)
            {
                _internalDate = Value;
            }
        }
    }

    private void InternalDateChanged(DateTime date)
    {
        _internalDate = date;
    }

    private void HandleOnCancel()
    {
        ShowChanged.InvokeAsync(false);
    }

    private async Task HandleOnConfirm()
    {
        await ValueChanged.InvokeAsync(_internalDate);
        _ = ShowChanged.InvokeAsync(false);
    }
}
