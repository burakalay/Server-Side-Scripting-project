using Microsoft.AspNetCore.Mvc;
using SecurePasswordApp.Data;
using SecurePasswordApp.Models;
using System.Linq;
using System.Threading.Tasks;

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

        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceName,Username,Password")] PasswordCredential passwordCredential)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passwordCredential);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(passwordCredential);
        }

       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var passwordCredential = await _context.PasswordCredentials.FindAsync(id);
            if (passwordCredential == null) return NotFound();

            return View(passwordCredential);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ServiceName,Username,Password")] PasswordCredential passwordCredential)
        {
            if (id != passwordCredential.PasswordCredentialId) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(passwordCredential);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(passwordCredential);
        }

      
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var passwordCredential = await _context.PasswordCredentials.FindAsync(id);
            if (passwordCredential == null) return NotFound();

            return View(passwordCredential);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var passwordCredential = await _context.PasswordCredentials.FindAsync(id);
            if (passwordCredential != null)
            {
                _context.PasswordCredentials.Remove(passwordCredential);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var passwordCredential = await _context.PasswordCredentials.FindAsync(id);
            if (passwordCredential == null) return NotFound();

            return View(passwordCredential);
        }
    }
}
