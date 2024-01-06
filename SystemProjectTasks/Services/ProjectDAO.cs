using Microsoft.EntityFrameworkCore;
using SystemProjectTasks.Models;

namespace SystemProjectTasks.Services
{
    public class ProjectDAO
    {
        private readonly SystemProjectTasksContext contexto = default!;

        public ProjectDAO(SystemProjectTasksContext context)
        {
            this.contexto = context;
        }

        // Obtener todos los proyectos
        public List<Project> ObtenerProyectos() => contexto.Projects.ToList();

        // Obtener proyecto por id
        //public Project ObtenerProyecto(int idProject) => contexto.Projects.First(u => u.IdProject == idProject);
        public Project ObtenerProyecto(int idProject) =>
                                                        contexto.Projects.
                                                        Include(u => u.ProjectUsers).
                                                        First(u => u.IdProject == idProject);

        // Crear proyecto
        public bool CrearProyecto(Project project)
        {
            contexto.Projects.Add(project);
            return contexto.SaveChanges() > 0;
        }

        // Editar proyecto
        public bool EditarProyecto(Project project)
        {
            contexto.Entry(project).State = EntityState.Modified;
            return contexto.SaveChanges() > 0;
        }

        // Eliminar proyecto
        public bool EliminarProyecto(int idProject)
        {
            contexto.Remove(this.ObtenerProyecto(idProject));
            return contexto.SaveChanges() > 0;
        }

        // Agregar un usuario a un proyecto
        public bool AgregarUsuarioProyecto(int idProject, int idUser)
        {
            contexto.ProjectUsers.Add(new ProjectUser()
            {
                IdProjectFk = idProject,
                IdUserFx = idUser
            });
            return contexto.SaveChanges() > 0;
        }

        // Eliminar un usuario de un proyecto
        public bool EliminarUsuarioProyecto(ProjectUser projectUser)
        {
            contexto.Remove(projectUser);
            return contexto.SaveChanges() > 0;
        }

        // Obtener ProjectUser de un usuario
        public ProjectUser ObtenerProyectoUsuario(int idProyectoUsuario) => contexto.ProjectUsers
        .First(u => u.IdProjectUser == idProyectoUsuario);

        // Obtener proyectos de un usuario
        public List<ProjectUser> ObtenerProyectosUsuario(int idUser) => contexto.ProjectUsers
        .Where(usuario => usuario.IdUserFx == idUser)
        .Include(u => u.IdProjectFkNavigation)
        .Include(u => u.IdUserFxNavigation)
        .ToList();

        // Obtener usuarios de un proyecto
        public List<ProjectUser> ObtenerUsuariosProyecto(int idProyecto) => contexto.ProjectUsers
        .Where(usuario => usuario.IdProjectFk == idProyecto)
        .Include(u => u.IdProjectFkNavigation)
        .Include(u => u.IdUserFxNavigation)
        .ToList();

        // Obtener usuarios que no pertenecen a un proyecto
        public List<User> ObtenerNoPertenecenProyecto(int idProyecto) => this.VerificarUsuarios(contexto.Users
        .Include(u => u.ProjectUsers)
        .ToList(), idProyecto);

        private List<User> VerificarUsuarios(List<User> usuariosTodos, int idProyecto)
        {
            List<User> usuariosVerificados = new();

            usuariosTodos.ForEach(usuario =>
            {
                bool isPresente = true;
                foreach (var relation in usuario.ProjectUsers)
                {
                    if (relation.IdProjectFk == idProyecto)
                    {
                        isPresente = false;
                    }
                }

                if (isPresente)
                {
                    usuariosVerificados.Add(usuario);
                }
            });

            return usuariosVerificados;
        }
    }
}