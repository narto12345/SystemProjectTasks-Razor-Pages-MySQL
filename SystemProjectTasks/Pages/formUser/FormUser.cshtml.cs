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

        public FormUserModel(UserDAO userDAO)
        {
            this._userDAO = userDAO;
        }
        public void OnGet()
        {
            UserBind = new();
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
    }
}
