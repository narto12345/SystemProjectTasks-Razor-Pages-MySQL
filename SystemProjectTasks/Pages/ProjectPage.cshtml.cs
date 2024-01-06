using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SystemProjectTasks.Models;
using SystemProjectTasks.Services;

namespace SystemProjectTasks.Pages
{
    public class ProjectPageModel : PageModel
    {
        public bool mostrarFormulario = false;
        private readonly ProjectDAO _projectDAO = default!;
        public List<Project> Projects { get; set; } = default!;

        [BindProperty]
        public Project Project { get; set; } = default!;

        public ProjectPageModel(ProjectDAO projectDAO)
        {
            _projectDAO = projectDAO;
        }

        public void OnGet()
        {
            Projects = _projectDAO.ObtenerProyectos();
        }

        public IActionResult OnPostCrearProyecto()
        {
            if (!ModelState.IsValid || Project == null)
            {
                Projects = _projectDAO.ObtenerProyectos();
                this.mostrarFormulario = true;
                return Page();
            }

            _projectDAO.CrearProyecto(Project);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostDelete(int id)
        {
            this._projectDAO.EliminarProyecto(id);
            return RedirectToAction("Get");
        }

        public string TransformarEstado(bool estado) => estado ? "En curso" : "Completado";
    }
}
