//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThemeParkManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SHOP_STAFF
    {
        public int EmployeeID { get; set; }
        public int ShopID { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
    
        public virtual SHOP SHOP { get; set; }
        public virtual STAFF STAFF { get; set; }
    }
}