using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThemeParkManagementSystem.Models
{
    public class StaffIndexData
    {
        public IEnumerable<ThemeParkManagementSystem.Models.RIDES_STAFF> RidesStaff { get; set; }
        public IEnumerable<ThemeParkManagementSystem.Models.RIDE> Rides { get; set; }
        public IEnumerable<ThemeParkManagementSystem.Models.STAFF> Staff { get; set; }
    }
}