using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SystemProjectTasks.Models;
using SystemProjectTasks.Services;

namespace SystemProjectTasks.Pages
{
    public class UserModel : PageModel
    {

        private readonly UserDAO _userDAO = default!;

        public List<User> Users { get; set; } = default!;

        public UserModel(UserDAO userDao)
        {
            this._userDAO = userDao;
        }

        public void OnGet()
        {
            this.Users = this._userDAO.ObtenerUsuarios();
        }

        public IActionResult OnGetEliminarUsuario(int id)
        {
            this._userDAO.EliminarUsuario(this._userDAO.ObtenerUsuario(id));
            return RedirectToAction("Get");
        }
    }
}
