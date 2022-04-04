using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UtahCrashStats.Models;

namespace UtahCrashStats.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly UtahCrashStats.Models.CrashDbContext _context;

        public DeleteModel(UtahCrashStats.Models.CrashDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Crash = await _context.Crash.FindAsync(id);

            if (Crash != null)
            {
                _context.Crash.Remove(Crash);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
