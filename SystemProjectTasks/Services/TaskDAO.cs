using Microsoft.EntityFrameworkCore;
using SystemProjectTasks.Models;

namespace SystemProjectTasks.Services
{
    public class TaskDAO
    {
        private readonly SystemProjectTasksContext contexto = default!;

        public TaskDAO(SystemProjectTasksContext context)
        {
            this.contexto = context;
        }

        // Obtener tareas de un usuario por id
        public List<Models.Task> ObtenerTareasUsuario(int idUser) =>
         (List<Models.Task>)contexto.Users
         .Include(u => u.Tasks).First(u => u.IdUser == idUser).Tasks;

        // Obtener tareas de un proyecto
        public List<Models.Task> ObtenerTareasProyecto(int idProyecto) =>
        contexto.Tasks.Where(u => u.IdProjectFk == idProyecto).
        Include(u => u.IdUserFxNavigation).
        ToList();

        // Obtener tareas de un proyecto por usuario
        public List<Models.Task> ObtenerTareasProyectoUsuario(int idProyecto, int idUsuario) =>
        contexto.Tasks.Where(u => (u.IdProjectFk == idProyecto) && (u.IdUserFx == idUsuario)).
        ToList();

        // Crear proyecto
        public bool CrearTarea(Models.Task task)
        {
            contexto.Tasks.Add(task);
            return contexto.SaveChanges() > 0;
        }

        // Eliminar tareas asigandos a un usuario en un proyecto
        public bool EliminarTareasUsuarioProyecto(List<Models.Task> tareas)
        {
            bool resultado = false;
            foreach (var tarea in tareas)
            {
                contexto.Tasks.Remove(tarea);
                resultado = true;
            }

            return resultado;
        }


    }
}