using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UtahCrashStats.Models;

namespace UtahCrashStats.Pages
{
    public class CreateModel : PageModel
    {
        private readonly UtahCrashStats.Models.CrashDbContext _context;

        public CreateModel(UtahCrashStats.Models.CrashDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Crash Crash { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Crash.Add(Crash);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
