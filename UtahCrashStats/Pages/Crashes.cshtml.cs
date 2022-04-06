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

        public List<int> dataList { get; set; }

        public void OnGet(int p = 1, int s = 10, string search = "", int wo = 0, int pe = 0, int bi = 0, int mo = 0, int im = 0, int un = 0, int du = 0,
            int inter = 0, int wi = 0, int dom = 0, int ro = 0, int co = 0, int te = 0, int se = 0, int ni = 0, int si = 0, int di = 0, int dr = 0, int road = 0)
        {
            searchTerm = search;


            crashes = context.Crash
                .Where(
                x => (x.CITY.Contains(search) ||
                x.COUNTY_NAME.Contains(search) ||
                x.MAIN_ROAD_NAME.Contains(search)) &&
                (x.WORK_ZONE_RELATED.Equals(wo) || x.WORK_ZONE_RELATED.Equals(1)) &&
                (x.PEDESTRIAN_INVOLVED.Equals(pe) || x.PEDESTRIAN_INVOLVED.Equals(1)) &&
                (x.BICYCLIST_INVOLVED.Equals(bi) || x.BICYCLIST_INVOLVED.Equals(1)) &&
                (x.MOTORCYCLE_INVOLVED.Equals(mo) || x.MOTORCYCLE_INVOLVED.Equals(1)) &&
                (x.IMPROPER_RESTRAINT.Equals(im) || x.IMPROPER_RESTRAINT.Equals(1)) &&
                (x.UNRESTRAINED.Equals(un) || x.UNRESTRAINED.Equals(1)) &&
                (x.DUI.Equals(du) || x.DUI.Equals(1)) &&
                (x.INTERSECTION_RELATED.Equals(inter) || x.INTERSECTION_RELATED.Equals(1)) &&
                (x.WILD_ANIMAL_RELATED.Equals(wi) || x.WILD_ANIMAL_RELATED.Equals(1)) &&
                (x.DOMESTIC_ANIMAL_RELATED.Equals(dom) || x.DOMESTIC_ANIMAL_RELATED.Equals(1)) &&
                (x.OVERTURN_ROLLOVER.Equals(ro) || x.OVERTURN_ROLLOVER.Equals(1)) &&
                (x.COMMERCIAL_MOTOR_VEH_INVOLVED.Equals(co) || x.COMMERCIAL_MOTOR_VEH_INVOLVED.Equals(1)) &&
                (x.TEENAGE_DRIVER_INVOLVED.Equals(te) || x.TEENAGE_DRIVER_INVOLVED.Equals(1)) &&
                (x.OLDER_DRIVER_INVOLVED.Equals(se) || x.OLDER_DRIVER_INVOLVED.Equals(1)) &&
                (x.NIGHT_DARK_CONDITION.Equals(ni) || x.NIGHT_DARK_CONDITION.Equals(1)) &&
                (x.SINGLE_VEHICLE.Equals(si) || x.SINGLE_VEHICLE.Equals(1)) &&
                (x.DISTRACTED_DRIVING.Equals(di) || x.DISTRACTED_DRIVING.Equals(1)) &&
                (x.DROWSY_DRIVING.Equals(dr) || x.DROWSY_DRIVING.Equals(1)) &&
                (x.ROADWAY_DEPARTURE.Equals(road) || x.ROADWAY_DEPARTURE.Equals(1))
                )
                .OrderByDescending(x => x.CRASH_DATETIME)
                .Skip((p - 1) * s)
                .Take(s)
                .ToList();
            totalCrashes = context.Crash
                .Where(
                x => (x.CITY.Contains(search) ||
                x.COUNTY_NAME.Contains(search) ||
                x.MAIN_ROAD_NAME.Contains(search)) &&
                (x.WORK_ZONE_RELATED.Equals(wo) || x.WORK_ZONE_RELATED.Equals(1)) &&
                (x.PEDESTRIAN_INVOLVED.Equals(pe) || x.PEDESTRIAN_INVOLVED.Equals(1)) &&
                (x.BICYCLIST_INVOLVED.Equals(bi) || x.BICYCLIST_INVOLVED.Equals(1)) &&
                (x.MOTORCYCLE_INVOLVED.Equals(mo) || x.MOTORCYCLE_INVOLVED.Equals(1)) &&
                (x.IMPROPER_RESTRAINT.Equals(im) || x.IMPROPER_RESTRAINT.Equals(1)) &&
                (x.UNRESTRAINED.Equals(un) || x.UNRESTRAINED.Equals(1)) &&
                (x.DUI.Equals(du) || x.DUI.Equals(1)) &&
                (x.INTERSECTION_RELATED.Equals(inter) || x.INTERSECTION_RELATED.Equals(1)) &&
                (x.WILD_ANIMAL_RELATED.Equals(wi) || x.WILD_ANIMAL_RELATED.Equals(1)) &&
                (x.DOMESTIC_ANIMAL_RELATED.Equals(dom) || x.DOMESTIC_ANIMAL_RELATED.Equals(1)) &&
                (x.OVERTURN_ROLLOVER.Equals(ro) || x.OVERTURN_ROLLOVER.Equals(1)) &&
                (x.COMMERCIAL_MOTOR_VEH_INVOLVED.Equals(co) || x.COMMERCIAL_MOTOR_VEH_INVOLVED.Equals(1)) &&
                (x.TEENAGE_DRIVER_INVOLVED.Equals(te) || x.TEENAGE_DRIVER_INVOLVED.Equals(1)) &&
                (x.OLDER_DRIVER_INVOLVED.Equals(se) || x.OLDER_DRIVER_INVOLVED.Equals(1)) &&
                (x.NIGHT_DARK_CONDITION.Equals(ni) || x.NIGHT_DARK_CONDITION.Equals(1)) &&
                (x.SINGLE_VEHICLE.Equals(si) || x.SINGLE_VEHICLE.Equals(1)) &&
                (x.DISTRACTED_DRIVING.Equals(di) || x.DISTRACTED_DRIVING.Equals(1)) &&
                (x.DROWSY_DRIVING.Equals(dr) || x.DROWSY_DRIVING.Equals(1)) &&
                (x.ROADWAY_DEPARTURE.Equals(road) || x.ROADWAY_DEPARTURE.Equals(1))
                )
                .Count();
            pageSize = s;
            pageNum = p;
        }
    }
}
