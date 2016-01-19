using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using CodedHomes.Web.Filters;
using System.Web.Http;

namespace CodedHomes.Web
{
    public class CustomGlobalConfig
    {
        public static void Customize(HttpConfiguration config)
        {
            config.Filters.Add(new ValidationActionFilter());
        }
    }
}