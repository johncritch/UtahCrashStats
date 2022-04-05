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
    public class CrashesModel : PageModel
    {
        private readonly UtahCrashStats.Models.CrashDbContext context;

        public CrashesModel(UtahCrashStats.Models.CrashDbContext _context)
        {
            context = _context;
        }

        public List<Crash> crashes { get; set; }

        public int totalCrashes { get; set; }

        public int pageNum { get; set; }

        public int pageSize { get; set; }

        public string searchTerm { get; set; }

        public void OnGet(int p = 1, int s = 10, string search = "")
        {
            searchTerm = search;

            crashes = context.Crash
                .Where(x => x.CITY.Contains(search) ||
                x.COUNTY_NAME.Contains(search) ||
                x.MAIN_ROAD_NAME.Contains(search))
                .Skip((p - 1) * s)
                .Take(s)
                .ToList();
            totalCrashes = context.Crash
                .Where(x => x.CITY.Contains(search) ||
                x.COUNTY_NAME.Contains(search) ||
                x.MAIN_ROAD_NAME.Contains(search))
                .Count();
            pageSize = s;
            pageNum = p;
        }
        //public async Task OnGetAsync(int p = 1, int s = 15)
        //{
        //    Crash = await _context.Crash
        //        .Skip((p - 1) * s)
        //        .Take(s)
        //        .ToListAsync();
        //    pageSize = s;
        //    totalCrashes = Crash.Count;
        //    pageNum = p;
        //}
    }
}
