using Memo.Blog.App.Models.Todo;
using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Components.Pages.Todo.Components;

public partial class EditSheet
{
    [Parameter] public Func<DateTime, string> GetAliasOfDueAt { get; set; }
    [Parameter] public List<TodoTag> Tags { get; set; } = new();
    [Parameter] public EventCallback<TodoTask> OnAdd { get; set; }
    [Parameter] public EventCallback<TodoTask> OnUpdate { get; set; }
    [Parameter] public EventCallback<TodoTask> OnDelete { get; set; }
    [Parameter] public string? Attach { get; set; }

    [Inject] IPopupService PopupService { get; set; } = default!;

    private static List<(TodoTaskPriority priority, string? color)> Priorities =
    [
        (TodoTaskPriority.High, "red"),
        (TodoTaskPriority.Medium, "orange"),
        (TodoTaskPriority.Low, "blue"),
        (TodoTaskPriority.Default, null)
    ];

    private bool _show;
    private bool _calendarSheet;
    private MForm _form = null!;
    private bool _isEdit;

    private TodoTask _currentTask = new();

    private string? PriorityColor => _currentTask.Priority switch
    {
        TodoTaskPriority.High => "red",
        TodoTaskPriority.Medium => "orange",
        TodoTaskPriority.Low => "blue",
        _ => null
    };

    private async Task HandleOnAddOrUpdate()
    {
        var action = _isEdit ? OnUpdate : OnAdd;
        await action.InvokeAsync(_currentTask);
        _show = false;
    }

    private async Task DeleteTask()
    {
        var confirmed = await PopupService.ConfirmAsync("Delete task", $"Are you sure to delete task '{_currentTask.Title}'?");
        if (confirmed)
        {
            await OnDelete.InvokeAsync(_currentTask);
            _show = false;
        }
    }

    internal void Open()
    {
        _isEdit = false;
        _currentTask = new();
        _show = true;
    }

    internal void Open(TodoTask task)
    {
        _isEdit = true;
        _currentTask = (TodoTask)task.ShallowCopy();
        _show = true;
    }

    internal void Hide()
    {
        _isEdit = false;
        _show = false;
    }
}
