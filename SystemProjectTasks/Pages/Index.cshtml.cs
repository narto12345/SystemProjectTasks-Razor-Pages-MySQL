using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SystemProjectTasks.Services;
using SystemProjectTasks.Models;

namespace SystemProjectTasks.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public readonly UserDAO userDAO = default!;
    public readonly ProjectDAO projectDAO = default!;
    public readonly TaskDAO taskDAO = default!;

    public IndexModel(ILogger<IndexModel> logger, UserDAO userDAO, ProjectDAO projectDAO, TaskDAO taskDAO)
    {
        _logger = logger;
        this.userDAO = userDAO;
        this.projectDAO = projectDAO;
        this.taskDAO = taskDAO;
    }

    public void OnGet()
    {

    }
}
