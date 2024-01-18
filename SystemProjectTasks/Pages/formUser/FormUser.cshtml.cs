using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SystemProjectTasks.Models;
using SystemProjectTasks.Services;

namespace SystemProjectTasks.Pages
{
    public class FormUserModel : PageModel
    {
        private UserDAO _userDAO = default!;
        [BindProperty]
        public User UserBind { get; set; } = default!;

        public string? IdUser { get; set; } = default!;

        public FormUserModel(UserDAO userDAO)
        {
            this._userDAO = userDAO;
        }
        public void OnGet()
        {
            this.IdUser = Request.Query["id"];
            UserBind = new();
            if (IdUser != null)
            {
                UserBind = _userDAO.ObtenerUsuario(int.Parse(IdUser));
            }
        }

        public IActionResult OnPostCrearUsuario()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            this._userDAO.CrearUsuario(UserBind);
            return Redirect("/User");
        }

        public IActionResult OnPostEditarUsuario()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            this._userDAO.ModificarUsuario(UserBind);
            return Redirect("/User");
        }
    }
}
