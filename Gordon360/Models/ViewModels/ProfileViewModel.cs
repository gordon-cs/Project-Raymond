﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gordon360.Models.ViewModels
{
    public class ProfileViewModel
    {
        public int Row_ID { get; set; }
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string EmailUserName { get; set; }
        public string OnOffCampus { get; set; }
        public string HomeStreet1 { get; set; }
        public string HomeStreet2 { get; set; }
        public string HomeCity { get; set; }
        public string HomeState { get; set; }
        public string HomePostalCode { get; set; }
        public string HomeCountry { get; set; }
        public string HomePhone { get; set; }
        public string Class { get; set; }
        public string KeepPrivate { get; set; }
        public string Major { get; set; }
        public string Barcode { get; set; }
        public string AdvisorIDs { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string MobilePhone { get; set; }
        public Nullable<bool> IsMobilePhonePrivate { get; set; }


        public static implicit operator ProfileViewModel(student_temp stu)
        {
            ProfileViewModel vm = new ProfileViewModel
            {
                Row_ID = stu.Row_ID,
                ID = stu.ID.Trim(),
                FirstName = stu.FirstName.Trim(),
                LastName = stu.LastName.Trim(), 
                NickName = stu.NickName.Trim() ?? "", // Just in case some random record has a null user_name 
                EmailUserName = stu.EmailUserName.Trim() ?? "", // Just in case some random record has a null email field
                OnOffCampus = stu.OnOffCampus.Trim() ?? "",
                HomeStreet1 = stu.HomeStreet1 ?? "",
                HomeStreet2 = stu.HomeStreet2 ?? "",
                HomeCity = stu.HomeCity.Trim() ?? "",
                HomeState = stu.HomeState.Trim() ?? "",
                HomePostalCode = stu.HomePostalCode.Trim() ?? "",
                HomeCountry = stu.HomeCountry.Trim() ?? "",
                HomePhone = stu.HomePhone ?? "",
                Class = stu.Class.Trim() ?? "",
                KeepPrivate = stu.KeepPrivate.Trim() ?? "",
                Major = stu.Major.Trim() ?? "",
                Email = stu.Email ?? "",
                Gender = stu.Gender.Trim() ?? "",
                MobilePhone = stu.MobilePhone ?? "",
                IsMobilePhonePrivate = stu.IsMobilePhonePrivate
            };

            return vm;
        }
    }
}