using System;
using System.Collections.Generic;

namespace SysGestFullstack.Models
{
    public class DashboardViewModel
    {
        public int TotalUsers { get; set; }
        public int ActiveUsers { get; set; }
        public List<Activity> RecentActivities { get; set; }
    }
}

