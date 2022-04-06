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
    public class StoryDeleteModel : PageModel
    {
        private readonly UtahCrashStats.Models.StoryDbContext _context;

        public StoryDeleteModel(UtahCrashStats.Models.StoryDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Story Story { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Story = await _context.Story.FirstOrDefaultAsync(m => m.STORY_ID == id);

            if (Story == null)
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

            Story = await _context.Story.FindAsync(id);

            if (Story != null)
            {
                _context.Story.Remove(Story);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./StoryHome");
        }
    }
}
