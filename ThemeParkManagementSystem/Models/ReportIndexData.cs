using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThemeParkManagementSystem.Models
{
    public class ReportIndexData
    {
        public IEnumerable<ThemeParkManagementSystem.Models.GUEST_RIDES> GuestRides { get; set; }
        public IEnumerable<ThemeParkManagementSystem.Models.GUEST_TICKET> GuestTickets { get; set; }
    }
}