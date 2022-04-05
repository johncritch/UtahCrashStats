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
    public class IndexModel : PageModel
    {
        private readonly UtahCrashStats.Models.CrashDbContext _context;

        public IndexModel(UtahCrashStats.Models.CrashDbContext context)
        {
            _context = context;
        }

        public IList<Crash> Crash { get;set; }

        public async Task OnGetAsync()
        {
            Crash = await _context.Crash.Take(10).ToListAsync();
        }


    }
}
