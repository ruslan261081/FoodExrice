﻿using System.Web;
using System.Web.Mvc;

namespace _18092019_Food_Exam
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
