using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UtahCrashStats.Models;

namespace UtahCrashStats.Pages
{
    public class CrashesModel : PageModel
    {
        private readonly UtahCrashStats.Models.CrashDbContext _context;

        public CrashesModel(UtahCrashStats.Models.CrashDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGetSelectAll()
        {
            List<Crash> data = _context.Crash.ToList();
            return new JsonResult(data);
        }
    }
}
