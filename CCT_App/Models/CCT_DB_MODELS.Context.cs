﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CCT_App.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CCTEntities : DbContext
    {
        public CCTEntities()
            : base("name=CCTEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<JNZB_ACTIVITIES> JNZB_ACTIVITIES { get; set; }
        public virtual DbSet<SUPERVISOR> SUPERVISORs { get; set; }
        public virtual DbSet<ACCOUNT> ACCOUNTs { get; set; }
        public virtual DbSet<ACT_CLUB_DEF> ACT_CLUB_DEF { get; set; }
        public virtual DbSet<CM_SESSION_MSTR> CM_SESSION_MSTR { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<PART_DEF> PART_DEF { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<Activity_Info> Activity_Info { get; set; }
        public virtual DbSet<Membership> Membership { get; set; }
    
        public virtual ObjectResult<ACTIVE_CLUBS_PER_SESS_ID_Result> ACTIVE_CLUBS_PER_SESS_ID(string sESS_CDE)
        {
            var sESS_CDEParameter = sESS_CDE != null ?
                new ObjectParameter("SESS_CDE", sESS_CDE) :
                new ObjectParameter("SESS_CDE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ACTIVE_CLUBS_PER_SESS_ID_Result>("ACTIVE_CLUBS_PER_SESS_ID", sESS_CDEParameter);
        }
    }
}
