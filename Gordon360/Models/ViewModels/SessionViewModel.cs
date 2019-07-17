﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Gordon360.Models.ViewModels
{
    public class SessionViewModel
    {
        public string SessionCode { get; set; }
        public string SessionDescription { get; set; }
        public Nullable<System.DateTime> SessionBeginDate { get; set; }
        public Nullable<System.DateTime> SessionEndDate { get; set; }

        public static implicit operator SessionViewModel(CM_SESSION_MSTR sess)
        {
            SessionViewModel vm = new SessionViewModel
            {

                SessionCode = sess.SESS_CDE.Trim(),
                SessionDescription = sess.SESS_DESC ?? "",
                SessionBeginDate = sess.SESS_BEGN_DTE ?? DateTime.MinValue, 
                SessionEndDate = sess.SESS_END_DTE ?? DateTime.MaxValue
            };

            return vm;
        }
    }


}