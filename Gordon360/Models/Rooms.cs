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
    
    public partial class Rooms
    {
        public string room_id { get; set; }
        public string name { get; set; }
        public bool group { get; set; }
        public System.DateTime createdAt { get; set; }
        public System.DateTime lastUpdated { get; set; }
        public byte[] roomImage { get; set; }
    }
}
