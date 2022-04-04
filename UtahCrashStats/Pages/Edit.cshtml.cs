using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UtahCrashStats.Models;

namespace UtahCrashStats.Pages
{
    public class EditModel : PageModel
    {
        private readonly UtahCrashStats.Models.CrashDbContext _context;

        public EditModel(UtahCrashStats.Models.CrashDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Crash Crash { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Crash = await _context.Crash.FirstOrDefaultAsync(m => m.CRASH_ID == id);

            if (Crash == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Crash).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CrashExists(Crash.CRASH_ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CrashExists(int id)
        {
            return _context.Crash.Any(e => e.CRASH_ID == id);
        }
    }
}
