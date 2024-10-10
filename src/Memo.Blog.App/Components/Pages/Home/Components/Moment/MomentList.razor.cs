using Memo.Blog.App.Models.Moment;
using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Components.Pages.Home.Components.Moment;

public partial class MomentList
{
    [Parameter] public List<MomentResult> Moments { get; set; } = [];
}
