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
    public class StoryHomeModel : PageModel
    {
        private readonly UtahCrashStats.Models.StoryDbContext _context;

        public StoryHomeModel(UtahCrashStats.Models.StoryDbContext context)
        {
            _context = context;
        }

        public IList<Story> Story1 { get; set; }
        public IList<Story> Story2 { get; set; }
        public IList<Story> Story3 { get; set; }

        public int totalCrashes { get; set; }
        public int pageNum { get; set; }
        public int pageSize { get; set; }
        public string searchTerm { get; set; }

        public async Task OnGetAsync(int p = 1, int s = 9)
        {
            totalCrashes = _context.Story.Count();
            pageSize = s;
            pageNum = p;

            Story1 = await _context.Story
                .Skip((p - 1) * 9)
                .Take(3)
                .ToListAsync();
            Story2 = await _context.Story
                .Skip(((p - 1) * 9) + 3)
                .Take(3)
                .ToListAsync();
            Story3 = await _context.Story
                .Skip(((p - 1) * 9) + 6)
                .Take(3)
                .ToListAsync();
        }
    }
}
