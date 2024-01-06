using Microsoft.EntityFrameworkCore;
using SystemProjectTasks.Models;

namespace SystemProjectTasks.Services
{
    public class UserDAO
    {
        private readonly SystemProjectTasksContext contexto = default!;

        public UserDAO(SystemProjectTasksContext context)
        {
            this.contexto = context;
        }

        // Obtener todos los usuarios
        public List<User> ObtenerUsuarios() => contexto.Users
        .Include(u => u.Tasks).ToList();

        // Obtener usuario por id
        public User ObtenerUsuario(int idUser) => contexto.Users
        .Include(u => u.Tasks)
        .Include(u => u.ProjectUsers)
        .First(u => u.IdUser == idUser);

        // Crear Usuario
        public bool CrearUsuario(User usuario)
        {
            contexto.Users.Add(usuario);
            return contexto.SaveChanges() > 0;
        }

        // Editar Usuario
        public bool ModificarUsuario(User usuario)
        {
            contexto.Entry(usuario).State = EntityState.Modified;
            return contexto.SaveChanges() > 0;
        }

        // Eliminar Usuario
        public bool EliminarUsuario(User usuario)
        {
            contexto.Remove(usuario);
            return contexto.SaveChanges() > 0;
        }

    }
}
