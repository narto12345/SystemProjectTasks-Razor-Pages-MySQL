using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SystemProjectTasks.Models;
using SystemProjectTasks.Services;

namespace SystemProjectTasks.Pages
{
    public class AddUserProjectModel : PageModel
    {

        private readonly ProjectDAO _projectDAO = default!;
        public int IdProject { get; set; } = default!;

        public List<User> Users { get; set; } = default!;

        public AddUserProjectModel(ProjectDAO projectDAO)
        {
            _projectDAO = projectDAO;
        }
        public void OnGet(int id)
        {
            this.IdProject = id;
            Users = _projectDAO.ObtenerNoPertenecenProyecto(this.IdProject);
        }

        public IActionResult OnGetAgregar(int idProject, int idUser)
        {
            this._projectDAO.AgregarUsuarioProyecto(idProject, idUser);
            return RedirectToPage($"/detail/ProjectDetail", new { id = idProject });
        }
    }
}
