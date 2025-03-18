using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EncriptifyApp.Data;
using EncriptifyApp.Models;

namespace EncriptifyApp.Controllers
{
    public class PasswordCredentialsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PasswordCredentialsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PasswordCredentials
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PasswordCredentials.Include(p => p.UserDetail);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PasswordCredentials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passwordCredential = await _context.PasswordCredentials
                .Include(p => p.UserDetail)
                .FirstOrDefaultAsync(m => m.PasswordCredentialId == id);
            if (passwordCredential == null)
            {
                return NotFound();
            }

            return View(passwordCredential);
        }

        // GET: PasswordCredentials/Create
        public IActionResult Create()
        {
            ViewData["UserDetailId"] = new SelectList(_context.UserDetails, "UserDetailId", "Email");
            return View();
        }

        // POST: PasswordCredentials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PasswordCredentialId,WebsiteName,WebsiteUrl,WebsiteUsername,WebsitePassword,DateCreated,UserDetailId")] PasswordCredential passwordCredential)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passwordCredential);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserDetailId"] = new SelectList(_context.UserDetails, "UserDetailId", "Email", passwordCredential.UserDetailId);
            return View(passwordCredential);
        }

        // GET: PasswordCredentials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passwordCredential = await _context.PasswordCredentials.FindAsync(id);
            if (passwordCredential == null)
            {
                return NotFound();
            }
            ViewData["UserDetailId"] = new SelectList(_context.UserDetails, "UserDetailId", "Email", passwordCredential.UserDetailId);
            return View(passwordCredential);
        }

        // POST: PasswordCredentials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PasswordCredentialId,WebsiteName,WebsiteUrl,WebsiteUsername,WebsitePassword,DateCreated,UserDetailId")] PasswordCredential passwordCredential)
        {
            if (id != passwordCredential.PasswordCredentialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passwordCredential);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PasswordCredentialExists(passwordCredential.PasswordCredentialId))
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
            ViewData["UserDetailId"] = new SelectList(_context.UserDetails, "UserDetailId", "Email", passwordCredential.UserDetailId);
            return View(passwordCredential);
        }

        // GET: PasswordCredentials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passwordCredential = await _context.PasswordCredentials
                .Include(p => p.UserDetail)
                .FirstOrDefaultAsync(m => m.PasswordCredentialId == id);
            if (passwordCredential == null)
            {
                return NotFound();
            }

            return View(passwordCredential);
        }

        // POST: PasswordCredentials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var passwordCredential = await _context.PasswordCredentials.FindAsync(id);
            if (passwordCredential != null)
            {
                _context.PasswordCredentials.Remove(passwordCredential);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PasswordCredentialExists(int id)
        {
            return _context.PasswordCredentials.Any(e => e.PasswordCredentialId == id);
        }
    }
}
