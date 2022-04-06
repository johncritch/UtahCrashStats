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

        public int wo { get; set; }
        public int pe { get; set; }
        public int bi { get; set; }
        public int mo { get; set; }
        public int im { get; set; }
        public int un { get; set; }
        public int du { get; set; }
        public int inter { get; set; }
        public int wi { get; set; }
        public int dom { get; set; }
        public int ro { get; set; }
        public int co { get; set; }
        public int te { get; set; }
        public int se { get; set; }
        public int ni { get; set; }
        public int si { get; set; }
        public int di { get; set; }
        public int dr { get; set; }
        public int road { get; set; }

        public void OnGet(int p = 1, int s = 10, string search = "", int wo = 0, int pe = 0, int bi = 0, int mo = 0, int im = 0, int un = 0, int du = 0,
            int inter = 0, int wi = 0, int dom = 0, int ro = 0, int co = 0, int te = 0, int se = 0, int ni = 0, int si = 0, int di = 0, int dr = 0, int road = 0)
        {
            if (search == null)
            {
                search = "";
            }
            searchTerm = search;

            this.wo = wo;
            this.pe = pe;
            this.bi = bi;
            this.mo = mo;
            this.im = im;
            this.un = un;
            this.du = du;
            this.inter = inter;
            this.wi = wi;
            this.dom = dom;
            this.ro = ro;
            this.co = co;
            this.te = te;
            this.se = se;
            this.ni = ni;
            this.si = si;
            this.di = di;
            this.dr = dr;
            this.road = road;

            crashes = context.Crash
                .Where(
                x => (x.CITY.Contains(searchTerm) ||
                x.COUNTY_NAME.Contains(searchTerm) ||
                x.MAIN_ROAD_NAME.Contains(searchTerm)) &&
                (x.WORK_ZONE_RELATED.Equals(this.wo) || x.WORK_ZONE_RELATED.Equals(1)) &&
                (x.PEDESTRIAN_INVOLVED.Equals(this.pe) || x.PEDESTRIAN_INVOLVED.Equals(1)) &&
                (x.BICYCLIST_INVOLVED.Equals(this.bi) || x.BICYCLIST_INVOLVED.Equals(1)) &&
                (x.MOTORCYCLE_INVOLVED.Equals(this.mo) || x.MOTORCYCLE_INVOLVED.Equals(1)) &&
                (x.IMPROPER_RESTRAINT.Equals(this.im) || x.IMPROPER_RESTRAINT.Equals(1)) &&
                (x.UNRESTRAINED.Equals(this.un) || x.UNRESTRAINED.Equals(1)) &&
                (x.DUI.Equals(this.du) || x.DUI.Equals(1)) &&
                (x.INTERSECTION_RELATED.Equals(this.inter) || x.INTERSECTION_RELATED.Equals(1)) &&
                (x.WILD_ANIMAL_RELATED.Equals(this.wi) || x.WILD_ANIMAL_RELATED.Equals(1)) &&
                (x.DOMESTIC_ANIMAL_RELATED.Equals(this.dom) || x.DOMESTIC_ANIMAL_RELATED.Equals(1)) &&
                (x.OVERTURN_ROLLOVER.Equals(this.ro) || x.OVERTURN_ROLLOVER.Equals(1)) &&
                (x.COMMERCIAL_MOTOR_VEH_INVOLVED.Equals(this.co) || x.COMMERCIAL_MOTOR_VEH_INVOLVED.Equals(1)) &&
                (x.TEENAGE_DRIVER_INVOLVED.Equals(this.te) || x.TEENAGE_DRIVER_INVOLVED.Equals(1)) &&
                (x.OLDER_DRIVER_INVOLVED.Equals(this.se) || x.OLDER_DRIVER_INVOLVED.Equals(1)) &&
                (x.NIGHT_DARK_CONDITION.Equals(this.ni) || x.NIGHT_DARK_CONDITION.Equals(1)) &&
                (x.SINGLE_VEHICLE.Equals(this.si) || x.SINGLE_VEHICLE.Equals(1)) &&
                (x.DISTRACTED_DRIVING.Equals(this.di) || x.DISTRACTED_DRIVING.Equals(1)) &&
                (x.DROWSY_DRIVING.Equals(this.dr) || x.DROWSY_DRIVING.Equals(1)) &&
                (x.ROADWAY_DEPARTURE.Equals(this.road) || x.ROADWAY_DEPARTURE.Equals(1))
                )
                .OrderByDescending(x => x.CRASH_DATETIME)
                .Skip((p - 1) * s)
                .Take(s)
                .ToList();
            totalCrashes = context.Crash
                .Where(
                x => (x.CITY.Contains(searchTerm) ||
                x.COUNTY_NAME.Contains(searchTerm) ||
                x.MAIN_ROAD_NAME.Contains(searchTerm)) &&
                (x.WORK_ZONE_RELATED.Equals(this.wo) || x.WORK_ZONE_RELATED.Equals(1)) &&
                (x.PEDESTRIAN_INVOLVED.Equals(this.pe) || x.PEDESTRIAN_INVOLVED.Equals(1)) &&
                (x.BICYCLIST_INVOLVED.Equals(this.bi) || x.BICYCLIST_INVOLVED.Equals(1)) &&
                (x.MOTORCYCLE_INVOLVED.Equals(this.mo) || x.MOTORCYCLE_INVOLVED.Equals(1)) &&
                (x.IMPROPER_RESTRAINT.Equals(this.im) || x.IMPROPER_RESTRAINT.Equals(1)) &&
                (x.UNRESTRAINED.Equals(this.un) || x.UNRESTRAINED.Equals(1)) &&
                (x.DUI.Equals(this.du) || x.DUI.Equals(1)) &&
                (x.INTERSECTION_RELATED.Equals(this.inter) || x.INTERSECTION_RELATED.Equals(1)) &&
                (x.WILD_ANIMAL_RELATED.Equals(this.wi) || x.WILD_ANIMAL_RELATED.Equals(1)) &&
                (x.DOMESTIC_ANIMAL_RELATED.Equals(this.dom) || x.DOMESTIC_ANIMAL_RELATED.Equals(1)) &&
                (x.OVERTURN_ROLLOVER.Equals(this.ro) || x.OVERTURN_ROLLOVER.Equals(1)) &&
                (x.COMMERCIAL_MOTOR_VEH_INVOLVED.Equals(this.co) || x.COMMERCIAL_MOTOR_VEH_INVOLVED.Equals(1)) &&
                (x.TEENAGE_DRIVER_INVOLVED.Equals(this.te) || x.TEENAGE_DRIVER_INVOLVED.Equals(1)) &&
                (x.OLDER_DRIVER_INVOLVED.Equals(this.se) || x.OLDER_DRIVER_INVOLVED.Equals(1)) &&
                (x.NIGHT_DARK_CONDITION.Equals(this.ni) || x.NIGHT_DARK_CONDITION.Equals(1)) &&
                (x.SINGLE_VEHICLE.Equals(this.si) || x.SINGLE_VEHICLE.Equals(1)) &&
                (x.DISTRACTED_DRIVING.Equals(this.di) || x.DISTRACTED_DRIVING.Equals(1)) &&
                (x.DROWSY_DRIVING.Equals(this.dr) || x.DROWSY_DRIVING.Equals(1)) &&
                (x.ROADWAY_DEPARTURE.Equals(this.road) || x.ROADWAY_DEPARTURE.Equals(1))
                )
                .Count();
            pageSize = s;
            pageNum = p;
        }
    }
}
