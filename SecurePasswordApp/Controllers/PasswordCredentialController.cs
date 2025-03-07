using Microsoft.AspNetCore.Mvc;
using SecurePasswordApp.Data;
using SecurePasswordApp.Models;
using System.Linq;

namespace SecurePasswordApp.Controllers
{
    public class PasswordCredentialController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PasswordCredentialController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var credentials = _context.PasswordCredentials.ToList();
            return View(credentials);
        }
    }
}
