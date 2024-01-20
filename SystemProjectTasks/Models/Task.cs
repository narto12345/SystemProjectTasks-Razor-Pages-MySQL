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

    public Priority Priority { get; set; }

    public StatusP StatusP { get; set; }

    public DateTime DueDate { get; set; }

    public int? IdProjectFk { get; set; }

    public int? IdUserFx { get; set; }

    public virtual Project? IdProjectFkNavigation { get; set; }

    public virtual User? IdUserFxNavigation { get; set; } = default!;
}

public enum StatusP
{
    [Display(Name = "Pendiente")]
    Pendiente,
    [Display(Name = "En Progreso")]
    EnProgreso,
    [Display(Name = "Completada")]
    Completada
}

public enum Priority
{
    Baja,
    Media,
    Alta
}
