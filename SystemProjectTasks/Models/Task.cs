using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SystemProjectTasks.Models;

public partial class Task
{
    public int IdTask { get; set; }

    [Required]
    public string NameT { get; set; } = null!;

    public string? DescriptionT { get; set; }

    public int? Priority { get; set; }

    public int? StatusP { get; set; }

    public DateTime? DueDate { get; set; }

    public int? IdProjectFk { get; set; }

    public int? IdUserFx { get; set; }

    public virtual Project? IdProjectFkNavigation { get; set; }

    public virtual User? IdUserFxNavigation { get; set; } = default!;
}
