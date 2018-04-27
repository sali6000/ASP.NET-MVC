using DAL.Connection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DAL
{
    public class AppConfig
    {
        public static string ConnectionStringAdo
        {
            get { return string.Format(ConfigurationManager.ConnectionStrings["DBHotel10"].ConnectionString, Resource.login, Resource.password); }
        }
    }
}