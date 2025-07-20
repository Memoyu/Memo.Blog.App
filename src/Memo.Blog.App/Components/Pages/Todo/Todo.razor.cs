using Memo.Blog.App.Components.Pages.Todo.Components;
using Memo.Blog.App.Models.Todo;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Memo.Blog.App.Components.Pages.Todo;

public partial class Todo
{
    [Parameter] public string? Filter { get; set; }
    [Parameter] public string? Tag { get; set; }

    [Inject] NavigationManager NavigationManager { get; set; }
    [Inject] IPopupService PopupService { get; set; }

    private static string[] colors = ["red", "orange", "blue", "green", "purple", "pink", "yellow"];

    private bool? _drawer = false;
    private string? _prevFilter;
    private string _prevTag;

    private EditSheet _taskSheet = default!;

    private bool _tagSheet;

    private TodoTag _newTag = new();

    private int _page = 1;
    private int _pageSize = 10;
    private List<TodoTask> _tasks = new();
    private List<TodoTask> _completedTasks = new();
    private List<TodoTag> _tags = new();

    private List<StringNumber> _expandedPriority = [0, 1, 2, 3, -1];
    private IDisposable? _locationChangingRegistration;

    private TodoTag? CurrentTag => _tags.FirstOrDefault(t => t.Id == Tag);

    private string Title => CurrentTag?.Name ?? Filter ?? "Today";

    protected override void OnInitialized()
    {
        base.OnInitialized();

        _locationChangingRegistration = NavigationManager.RegisterLocationChangingHandler(LocationChangingHandler1);
        //_locationChangingRegistration.Dispose();
    }

    private async ValueTask LocationChangingHandler1(LocationChangingContext context)
    {
    }

    private async ValueTask LocationChangingHandler(LocationChangingContext context)
    {
        // Close all dialogs or sheets when navigating to other pages
        string absolutePath;
        if (!context.TargetLocation.StartsWith("http"))
        {
            absolutePath = NavigationManager.ToAbsoluteUri(context.TargetLocation).AbsolutePath;
        }
        else if (Uri.TryCreate(context.TargetLocation, UriKind.Absolute, out var uri))
        {
            absolutePath = uri.AbsolutePath;
        }
        else
        {
            return;
        }

        if (absolutePath == "/todo")
        {
            return;
        }

        _taskSheet.Hide();
        _tagSheet = false;
        await InvokeAsync(StateHasChanged).ConfigureAwait(false);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _prevFilter = Filter;
            _prevTag = Tag;

            await LoadTasks();
            await LoadTags();
            StateHasChanged();
        }
    }

    protected override async Task OnParametersSetAsync()
    {
        if (_prevFilter != Filter || _prevTag != Tag)
        {
            _prevFilter = Filter;
            _prevTag = Tag;
            await LoadTasks();
        }
    }

    private async Task LoadTasks()
    {
        List<TodoTask> tasks;

        if (!string.IsNullOrWhiteSpace(Tag))
        {
            tasks = new List<TodoTask>();
            //await ProDatabase.GetTasksAsync(_page, _pageSize, tag: Tag);
        }
        else
        {
            tasks = new List<TodoTask>();
            //Filter?.ToLowerInvariant() switch
            //{
            //    "inbox" => await ProDatabase.GetTasksAsync(_page, _pageSize),
            //    _ => await ProDatabase.GetTasksAsync(_page, _pageSize, DateTime.Today)
            //};
        }

        _tasks = tasks.Where(t => !t.Completed).ToList();
        _completedTasks = tasks.Where(t => t.Completed).ToList();
    }

    private async Task LoadTags()
    {
        //_tags = await ProDatabase.GetTagsAsync();
    }

    private async Task HandleOnSubmit(TodoTask model)
    {
        //await ProDatabase.CreateTaskAsync(model);
        await LoadTasks();
    }

    private async Task HandleOnUpdate(TodoTask model)
    {
        //await ProDatabase.UpdateTaskAsync(model);
        await LoadTasks();
    }

    private async Task HandleOnDelete(TodoTask model)
    {
        //await ProDatabase.DeleteTaskAsync(model);
        await LoadTasks();
    }

    private bool IsExpired(DateTime dueAt) => dueAt < DateTime.Today;

    private string GetAliasOfDueAt(DateTime dueAt)
    {
        var dateStr = GetDateStr();
        return dueAt.TimeOfDay == TimeSpan.Zero
            ? dateStr
            : $"{dateStr}, {dueAt.ToShortTimeString()}";

        string GetDateStr()
        {
            var today = DateTime.Today;
            var dateOfDue = dueAt.Date;
            if (dateOfDue == today)
            {
                return "Today";
            }

            if (dateOfDue == today.AddDays(-1))
            {
                return "Yesterday";
            }

            if (dateOfDue == today.AddDays(1))
            {
                return "Tomorrow";
            }

            if (dateOfDue.Year == DateTime.Today.Year)
            {
                return dateOfDue.ToString("M");
            }

            return dateOfDue.ToShortDateString();
        }
    }

    private async Task CompleteTask(TodoTask task)
    {
        if (task.Completed)
        {
            task.Completed = false;
            _tasks.Add(task);
            _completedTasks.Remove(task);
        }
        else
        {
            task.Completed = true;
            _completedTasks.Add(task);
            _tasks.Remove(task);
        }

        //await ProDatabase.UpdateTaskAsync(task);
    }

    private void ShowAddTagSheet()
    {
        _drawer = false;
        _tagSheet = true;
    }

    private void OnTagNameChanged(string val)
    {
        _newTag.Name = val.Trim(',').Trim(' ').Trim(';');
    }

    private async Task HandleOnAddTag()
    {
        //await ProDatabase.CreateTagAsync(_newTag);
        _tags.Add(_newTag);

        _newTag = new();
        _tagSheet = false;
    }

    private void EditTask(TodoTask task)
    {
        _taskSheet.Open(task);
    }

    private async Task DeleteTag(TodoTag model)
    {
        var confirm = await PopupService.ConfirmAsync("Delete tag", "Are you sure you want to delete this tag?");
        if (!confirm)
        {
            return;
        }

        //await ProDatabase.DeleteTagAsync(model);

        _ = PopupService.EnqueueSnackbarAsync("Tag deleted", AlertTypes.Success);

        var tag = _tags.FirstOrDefault(t => t.Id == model.Id);
        if (tag != null)
        {
            _tags.Remove(tag);
        }

        NavigationManager.NavigateTo("/todo");
    }

    public void Dispose()
    {
        _locationChangingRegistration?.Dispose();
    }
}
