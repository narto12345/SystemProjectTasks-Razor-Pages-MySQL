using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SystemProjectTasks.Models;
using SystemProjectTasks.Services;

namespace SystemProjectTasks.Pages
{
    public class ProjectDetailModel : PageModel
    {
        private readonly ProjectDAO _projectDAO = default!;
        private readonly TaskDAO _taskDAO = default!;
        public Project ProjectDetail { get; set; } = default!;
        public List<ProjectUser> Users { get; set; } = default!;
        public List<Models.Task> Tasks { get; set; } = default!;

        [BindProperty]
        public int IdProject { get; set; } = default!;

        [BindProperty]
        public Models.Task Task { get; set; } = default!;

        public ProjectDetailModel(ProjectDAO projectDAO, TaskDAO taskDAO)
        {
            _projectDAO = projectDAO;
            _taskDAO = taskDAO;
        }

        public void OnGet(int id)
        {
            this.ProjectDetail = this._projectDAO.ObtenerProyecto(id);
            this.Users = this._projectDAO.ObtenerUsuariosProyecto(id);
            this.Tasks = this._taskDAO.ObtenerTareasProyecto(id);
            this.IdProject = id;
        }

        public IActionResult OnGetQuitarParticipante(int idProject, int idProjectUser, int idUser)
        {
            this._taskDAO.EliminarTareasUsuarioProyecto(this._taskDAO.ObtenerTareasProyectoUsuario(idProject, idUser));
            this._projectDAO.EliminarUsuarioProyecto(this._projectDAO.ObtenerProyectoUsuario(idProjectUser));

            return RedirectToPage($"/detail/ProjectDetail", new { id = idProject });
        }

        public IActionResult OnPostCrearTarea()
        {
            if (ModelState.IsValid)
            {
                this.Task.IdProjectFk = this.IdProject;
                if (this.Task.IdUserFx != 0)
                {
                    this._taskDAO.CrearTarea(this.Task);
                }
            }


            return RedirectToPage($"/detail/ProjectDetail", new { id = this.IdProject });
        }

        public List<ProjectUser> ObtenerUsuarios(int idProyecto)
        {
            List<ProjectUser> usuarios = this._projectDAO.ObtenerUsuariosProyecto(idProyecto);
            return usuarios;
        }
    }
}
