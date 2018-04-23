using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThemeParkManagementSystem.Models
{
    public class ShopIndexData
    {
        public IEnumerable<ThemeParkManagementSystem.Models.INVENTORY> Inventory { get; set; }
        public IEnumerable<ThemeParkManagementSystem.Models.SHOP> Shops { get; set; }
    }
}