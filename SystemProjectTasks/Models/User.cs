using System;
using System.Collections.Generic;

namespace SystemProjectTasks.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string NameU { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<ProjectUser> ProjectUsers { get; set; } = new List<ProjectUser>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
