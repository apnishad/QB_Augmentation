﻿using System.Web;
using System.Web.Mvc;

namespace DoctorAppointment_Skeleton
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
