using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SystemProjectTasks.Models;
using SystemProjectTasks.Services;

namespace SystemProjectTasks.Pages
{
    public class ProjectUpdateModel : PageModel
    {
        private readonly ProjectDAO _projectDAO = default!;

        public Project ProjectBefore { get; set; } = default!;

        [BindProperty]
        public Project ProjectAfter { get; set; } = default!;
        public ProjectUpdateModel(ProjectDAO projectDAO)
        {
            _projectDAO = projectDAO;
        }

        public void OnGet(int id)
        {
            ProjectBefore = _projectDAO.ObtenerProyecto(id);
            System.Console.WriteLine(ProjectBefore.ToString());
        }

        public IActionResult OnPostEditarProyecto()
        {
            if (!ModelState.IsValid /*|| ProjectAfter == null*/)
            {
                ProjectBefore = ProjectAfter;
                // ProjectBefore = _projectDAO.ObtenerProyecto(idAux);
                // ProjectAfter = _projectDAO.ObtenerProyecto(idAux);
                return Page();
            }
            bool result = _projectDAO.EditarProyecto(ProjectAfter);
            if (result)
            {
                return Redirect("/ProjectPage");
            }
            else
            {
                return Redirect("/Privacy");
            }

        }
    }
}
