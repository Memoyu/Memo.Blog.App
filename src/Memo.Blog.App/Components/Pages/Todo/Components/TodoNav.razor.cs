using Memo.Blog.App.Models.Todo;
using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Components.Pages.Todo.Components;

public partial class TodoNav
{
    [Parameter] public bool? Show { get; set; }

    [Parameter] public EventCallback<bool?> ShowChanged { get; set; }

    [Parameter] public bool Permanent { get; set; }

    [Parameter] public bool ShowAddTask { get; set; }

    [Parameter] public EventCallback OnAddTagClick { get; set; }

    [Parameter] public List<TodoTag> Tags { get; set; } = [];

    private static TodoNavItem[] _categories =
    [
        new TodoNavItem("Today", "mdi-calendar-today-outline", "/todo"),
        new TodoNavItem("Inbox", "mdi-inbox-outline", "/todo/inbox")
    ];

    record TodoNavItem(string Title, string IconOrColor, string Href);

}
