﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gordon360.Models.ViewModels
{
    public class ApartmentAppViewModel
    {
        public int AprtAppID { get; set; }
        public string Username { get; set; }
        public string [] Applicants { get; set; }
    }
}