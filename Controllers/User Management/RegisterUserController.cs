using Microsoft.AspNetCore.Mvc;
using My_Demo_Project.Models;
using System.Collections.Generic;

namespace My_Demo_Project.Controllers.User_Management
{
    public class RegisterUserController : Controller
    {
        private static readonly object _lock = new();
        private static readonly List<User> users = new()
        {
            new User { Id = 1, Name = "Ali Khan", Email = "ali@gmail.com", Phone = "03001234567", Username = "alikhan", Password = "P@ssw0rd1", Role = "Admin" },
            new User { Id = 2, Name = "Ahmed Shah", Email = "ahmed@gmail.com", Phone = "03111234567", Username = "ahmeds", Password = "P@ssw0rd2", Role = "General" }
        };
        private static readonly List<string> roles = new()
        {
            "Admin",
            "General"
        };

        // Show Users Grid
        public IActionResult Users()
        {
            return View(users);
        }

        // Open Register User page
        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }

        // Save User (accept JSON via AJAX)
        [HttpPost]
        public IActionResult RegisterUser([FromBody] User user)
        {
            // Ensure model validation runs for objects bound from body
            if (!TryValidateModel(user))
            {
                return BadRequest(ModelState);
            }

            lock (_lock)
            {
                user.Id = users.Count + 1;
                users.Add(user);
            }

            return Ok(new { success = true });
        }

        // Default index
        public IActionResult Index()
        {
            return View();
        }

        // Return available role names as JSON
        [HttpGet]
        public IActionResult GetRoles()
        {
            return Json(roles);
        }

        // Add a new role via AJAX
        public class RoleDto { public string Name { get; set; } }

        [HttpPost]
        public IActionResult AddRole([FromBody] RoleDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Name))
                return BadRequest(new { error = "Role name is required." });

            var name = dto.Name.Trim();
            lock (_lock)
            {
                if (roles.Contains(name, System.StringComparer.OrdinalIgnoreCase))
                    return BadRequest(new { error = "Role already exists." });

                roles.Add(name);
            }

            return Ok(new { name });
        }

        // Additional action for AddUser view if needed
        public IActionResult AddUser()
        {
            return View();
        }
    }
}
