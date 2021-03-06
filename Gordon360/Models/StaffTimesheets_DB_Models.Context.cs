﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class StaffTimesheetsEntities : DbContext
    {
        public StaffTimesheetsEntities()
            : base("name=StaffTimesheetsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<hour_types> hour_types { get; set; }
        public virtual DbSet<paid_shifts> paid_shifts { get; set; }
        public virtual DbSet<staff_timesheets> staff_timesheets { get; set; }
    
        [DbFunction("StaffTimesheetsEntities", "CSVStringsToTable_fn")]
        public virtual IQueryable<CSVStringsToTable_fn_Result> CSVStringsToTable_fn(string array)
        {
            var arrayParameter = array != null ?
                new ObjectParameter("array", array) :
                new ObjectParameter("array", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<CSVStringsToTable_fn_Result>("[StaffTimesheetsEntities].[CSVStringsToTable_fn](@array)", arrayParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> staff_timesheets_already_worked_these_hours(Nullable<int> iD_NUM, Nullable<System.DateTime> shift_start_datetime, Nullable<System.DateTime> shift_end_datetime)
        {
            var iD_NUMParameter = iD_NUM.HasValue ?
                new ObjectParameter("ID_NUM", iD_NUM) :
                new ObjectParameter("ID_NUM", typeof(int));
    
            var shift_start_datetimeParameter = shift_start_datetime.HasValue ?
                new ObjectParameter("shift_start_datetime", shift_start_datetime) :
                new ObjectParameter("shift_start_datetime", typeof(System.DateTime));
    
            var shift_end_datetimeParameter = shift_end_datetime.HasValue ?
                new ObjectParameter("shift_end_datetime", shift_end_datetime) :
                new ObjectParameter("shift_end_datetime", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("staff_timesheets_already_worked_these_hours", iD_NUMParameter, shift_start_datetimeParameter, shift_end_datetimeParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> staff_timesheets_can_use_this_page(Nullable<int> iD_NUM)
        {
            var iD_NUMParameter = iD_NUM.HasValue ?
                new ObjectParameter("ID_NUM", iD_NUM) :
                new ObjectParameter("ID_NUM", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("staff_timesheets_can_use_this_page", iD_NUMParameter);
        }
    
        public virtual int staff_timesheets_delete_shift(Nullable<int> row_num, Nullable<int> iD_NUM)
        {
            var row_numParameter = row_num.HasValue ?
                new ObjectParameter("row_num", row_num) :
                new ObjectParameter("row_num", typeof(int));
    
            var iD_NUMParameter = iD_NUM.HasValue ?
                new ObjectParameter("ID_NUM", iD_NUM) :
                new ObjectParameter("ID_NUM", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("staff_timesheets_delete_shift", row_numParameter, iD_NUMParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> staff_timesheets_edit_shift_already_worked_these_hours(Nullable<int> iD_NUM, Nullable<System.DateTime> shift_start_datetime, Nullable<System.DateTime> shift_end_datetime, Nullable<int> shift_being_edited)
        {
            var iD_NUMParameter = iD_NUM.HasValue ?
                new ObjectParameter("ID_NUM", iD_NUM) :
                new ObjectParameter("ID_NUM", typeof(int));
    
            var shift_start_datetimeParameter = shift_start_datetime.HasValue ?
                new ObjectParameter("shift_start_datetime", shift_start_datetime) :
                new ObjectParameter("shift_start_datetime", typeof(System.DateTime));
    
            var shift_end_datetimeParameter = shift_end_datetime.HasValue ?
                new ObjectParameter("shift_end_datetime", shift_end_datetime) :
                new ObjectParameter("shift_end_datetime", typeof(System.DateTime));
    
            var shift_being_editedParameter = shift_being_edited.HasValue ?
                new ObjectParameter("shift_being_edited", shift_being_edited) :
                new ObjectParameter("shift_being_edited", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("staff_timesheets_edit_shift_already_worked_these_hours", iD_NUMParameter, shift_start_datetimeParameter, shift_end_datetimeParameter, shift_being_editedParameter);
        }
    
        public virtual int staff_timesheets_email_submissions(Nullable<int> iD_NUM)
        {
            var iD_NUMParameter = iD_NUM.HasValue ?
                new ObjectParameter("ID_NUM", iD_NUM) :
                new ObjectParameter("ID_NUM", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("staff_timesheets_email_submissions", iD_NUMParameter);
        }
    
        public virtual int staff_timesheets_insert_shift(Nullable<int> iD_NUM, Nullable<int> eml, Nullable<System.DateTime> shift_start_datetime, Nullable<System.DateTime> shift_end_datetime, string hours_worked, string hours_type, string shift_notes, string last_changed_by)
        {
            var iD_NUMParameter = iD_NUM.HasValue ?
                new ObjectParameter("ID_NUM", iD_NUM) :
                new ObjectParameter("ID_NUM", typeof(int));
    
            var emlParameter = eml.HasValue ?
                new ObjectParameter("eml", eml) :
                new ObjectParameter("eml", typeof(int));
    
            var shift_start_datetimeParameter = shift_start_datetime.HasValue ?
                new ObjectParameter("shift_start_datetime", shift_start_datetime) :
                new ObjectParameter("shift_start_datetime", typeof(System.DateTime));
    
            var shift_end_datetimeParameter = shift_end_datetime.HasValue ?
                new ObjectParameter("shift_end_datetime", shift_end_datetime) :
                new ObjectParameter("shift_end_datetime", typeof(System.DateTime));
    
            var hours_workedParameter = hours_worked != null ?
                new ObjectParameter("hours_worked", hours_worked) :
                new ObjectParameter("hours_worked", typeof(string));
    
            var hours_typeParameter = hours_type != null ?
                new ObjectParameter("hours_type", hours_type) :
                new ObjectParameter("hours_type", typeof(string));
    
            var shift_notesParameter = shift_notes != null ?
                new ObjectParameter("shift_notes", shift_notes) :
                new ObjectParameter("shift_notes", typeof(string));
    
            var last_changed_byParameter = last_changed_by != null ?
                new ObjectParameter("last_changed_by", last_changed_by) :
                new ObjectParameter("last_changed_by", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("staff_timesheets_insert_shift", iD_NUMParameter, emlParameter, shift_start_datetimeParameter, shift_end_datetimeParameter, hours_workedParameter, hours_typeParameter, shift_notesParameter, last_changed_byParameter);
        }
    
        public virtual ObjectResult<staff_timesheets_select_active_status_shifts_Result> staff_timesheets_select_active_status_shifts(Nullable<int> iD_NUM)
        {
            var iD_NUMParameter = iD_NUM.HasValue ?
                new ObjectParameter("ID_NUM", iD_NUM) :
                new ObjectParameter("ID_NUM", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<staff_timesheets_select_active_status_shifts_Result>("staff_timesheets_select_active_status_shifts", iD_NUMParameter);
        }
    
        public virtual ObjectResult<staff_timesheets_select_emls_for_ajax_selectbox_Result> staff_timesheets_select_emls_for_ajax_selectbox(Nullable<System.DateTime> start_datetime, Nullable<System.DateTime> end_datetime, Nullable<int> iD_NUM)
        {
            var start_datetimeParameter = start_datetime.HasValue ?
                new ObjectParameter("start_datetime", start_datetime) :
                new ObjectParameter("start_datetime", typeof(System.DateTime));
    
            var end_datetimeParameter = end_datetime.HasValue ?
                new ObjectParameter("end_datetime", end_datetime) :
                new ObjectParameter("end_datetime", typeof(System.DateTime));
    
            var iD_NUMParameter = iD_NUM.HasValue ?
                new ObjectParameter("ID_NUM", iD_NUM) :
                new ObjectParameter("ID_NUM", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<staff_timesheets_select_emls_for_ajax_selectbox_Result>("staff_timesheets_select_emls_for_ajax_selectbox", start_datetimeParameter, end_datetimeParameter, iD_NUMParameter);
        }
    
        public virtual ObjectResult<Nullable<System.DateTime>> staff_timesheets_select_end_datetimes(Nullable<int> eml, Nullable<int> iD_NUM)
        {
            var emlParameter = eml.HasValue ?
                new ObjectParameter("eml", eml) :
                new ObjectParameter("eml", typeof(int));
    
            var iD_NUMParameter = iD_NUM.HasValue ?
                new ObjectParameter("ID_NUM", iD_NUM) :
                new ObjectParameter("ID_NUM", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<System.DateTime>>("staff_timesheets_select_end_datetimes", emlParameter, iD_NUMParameter);
        }
    
        public virtual ObjectResult<staff_timesheets_select_fixed_status_shifts_Result> staff_timesheets_select_fixed_status_shifts(Nullable<int> iD_NUM)
        {
            var iD_NUMParameter = iD_NUM.HasValue ?
                new ObjectParameter("ID_NUM", iD_NUM) :
                new ObjectParameter("ID_NUM", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<staff_timesheets_select_fixed_status_shifts_Result>("staff_timesheets_select_fixed_status_shifts", iD_NUMParameter);
        }
    
        public virtual ObjectResult<staff_timesheets_select_hour_types_Result> staff_timesheets_select_hour_types()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<staff_timesheets_select_hour_types_Result>("staff_timesheets_select_hour_types");
        }
    
        public virtual ObjectResult<Nullable<int>> staff_timesheets_select_if_staff_has_paid_shifts(Nullable<int> iD_NUM)
        {
            var iD_NUMParameter = iD_NUM.HasValue ?
                new ObjectParameter("ID_NUM", iD_NUM) :
                new ObjectParameter("ID_NUM", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("staff_timesheets_select_if_staff_has_paid_shifts", iD_NUMParameter);
        }
    
        public virtual ObjectResult<staff_timesheets_select_supervisor_name_Result> staff_timesheets_select_supervisor_name(Nullable<int> supervisor)
        {
            var supervisorParameter = supervisor.HasValue ?
                new ObjectParameter("supervisor", supervisor) :
                new ObjectParameter("supervisor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<staff_timesheets_select_supervisor_name_Result>("staff_timesheets_select_supervisor_name", supervisorParameter);
        }
    
        public virtual int staff_timesheets_submit_job_shift(Nullable<int> iD_NUM, Nullable<int> eml, Nullable<System.DateTime> shift_end_datetime, Nullable<int> submitted_to, string last_changed_by)
        {
            var iD_NUMParameter = iD_NUM.HasValue ?
                new ObjectParameter("ID_NUM", iD_NUM) :
                new ObjectParameter("ID_NUM", typeof(int));
    
            var emlParameter = eml.HasValue ?
                new ObjectParameter("eml", eml) :
                new ObjectParameter("eml", typeof(int));
    
            var shift_end_datetimeParameter = shift_end_datetime.HasValue ?
                new ObjectParameter("shift_end_datetime", shift_end_datetime) :
                new ObjectParameter("shift_end_datetime", typeof(System.DateTime));
    
            var submitted_toParameter = submitted_to.HasValue ?
                new ObjectParameter("submitted_to", submitted_to) :
                new ObjectParameter("submitted_to", typeof(int));
    
            var last_changed_byParameter = last_changed_by != null ?
                new ObjectParameter("last_changed_by", last_changed_by) :
                new ObjectParameter("last_changed_by", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("staff_timesheets_submit_job_shift", iD_NUMParameter, emlParameter, shift_end_datetimeParameter, submitted_toParameter, last_changed_byParameter);
        }
    }
}
