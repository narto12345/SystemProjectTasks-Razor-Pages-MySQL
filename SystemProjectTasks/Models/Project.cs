using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SystemProjectTasks.Models;

public partial class Project
{
    public int IdProject { get; set; }

    [Required]
    // [StringLength(50)]
    public string NameP { get; set; } = null!;

    public string? DescriptionP { get; set; }

    public bool StatusP { get; set; }

    public virtual ICollection<ProjectUser> ProjectUsers { get; set; } = new List<ProjectUser>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

    public override string ToString() => $"Project[IdProject={IdProject}, NameP={NameP}, DescriptionP={DescriptionP}, StatusP={StatusP}]";
}
