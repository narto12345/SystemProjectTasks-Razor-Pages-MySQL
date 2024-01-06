using System;
using System.Collections.Generic;

namespace SystemProjectTasks.Models;

public partial class ProjectUser
{
    public int IdProjectUser { get; set; }

    public int? IdProjectFk { get; set; }

    public int? IdUserFx { get; set; }

    public virtual Project? IdProjectFkNavigation { get; set; }

    public virtual User? IdUserFxNavigation { get; set; } = default!;
}
