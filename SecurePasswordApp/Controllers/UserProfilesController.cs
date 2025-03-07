using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecurePasswordApp.Data;
using SecurePasswordApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SecurePasswordApp.Controllers
{
    public class UserProfilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserProfilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserProfiles.ToListAsync());
        }

      
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var userProfile = await _context.UserProfiles.FindAsync(id);
            if (userProfile == null) return NotFound();

            return View(userProfile);
        }

       
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,Email,Age")] UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userProfile);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var userProfile = await _context.UserProfiles.FindAsync(id);
            if (userProfile == null) return NotFound();

            return View(userProfile);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Email,Age")] UserProfile userProfile)
        {
            if (id != userProfile.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.UserProfiles.Any(e => e.Id == userProfile.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userProfile);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var userProfile = await _context.UserProfiles.FindAsync(id);
            if (userProfile == null) return NotFound();

            return View(userProfile);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userProfile = await _context.UserProfiles.FindAsync(id);
            if (userProfile != null)
            {
                _context.UserProfiles.Remove(userProfile);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
