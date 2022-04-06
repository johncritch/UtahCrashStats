using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UtahCrashStats.Models;

namespace UtahCrashStats.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly UtahCrashStats.Models.CrashDbContext context;

        public DashboardModel(UtahCrashStats.Models.CrashDbContext _context)
        {
            context = _context;
        }

        public List<Crash> crashes { get; set; }


        public void OnGet()
        {
            crashes = context.Crash
                .OrderByDescending(c => c.CRASH_DATETIME)
                .Take(5)
                .ToList();
        }
    }
}
