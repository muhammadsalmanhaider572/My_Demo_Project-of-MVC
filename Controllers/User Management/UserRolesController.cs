using Microsoft.AspNetCore.Mvc;

namespace My_Demo_Project.Controllers.User_Management
{
    public class UserRolesController : Controller
    {
        // Shows role management UI (roles are stored and exposed by RegisterUserController endpoints)
        public IActionResult Index()
        {
            return View();
        }
    }
}
