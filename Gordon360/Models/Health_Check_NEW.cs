//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gordon360.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Health_Check_NEW
    {
        public int ID_Num { get; set; }
        public byte HealthStatusID { get; set; }
        public System.DateTime Created { get; set; }
        public Nullable<System.DateTime> emailed { get; set; }
    
        public virtual Health_Status_CTRL Health_Status_CTRL { get; set; }
    }
}