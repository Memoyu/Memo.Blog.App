namespace Memo.Blog.App.Models.Todo;

public class TodoTask
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string? Description { get; set; }

    public DateTime DueAt { get; set; }

    public TodoTaskPriority Priority { get; set; }

    public bool Important { get; set; }

    public bool Completed { get; set; }

    public string[] TagIds
    {
        get => Tags?.Split(';').Where(t => !string.IsNullOrEmpty(t)).ToArray() ?? [];
        set
        {
            Tags = string.Join(';', value);
            if (Tags.Length > 0)
            {
                Tags += ";";
            }
        }
    }

    public string? Tags { get; set; }

    public object ShallowCopy()
    {
        return this.MemberwiseClone();
    }
}
