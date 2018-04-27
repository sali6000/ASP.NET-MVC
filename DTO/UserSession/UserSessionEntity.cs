using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DTO
{
    public static class UserSessionEntity
    {
        public static MemberEntity CurrentUser
        {
            get { return (MemberEntity) HttpContext.Current.Session["CurrentUser"]; }
            set { HttpContext.Current.Session["CurrentUser"] = value; }
        }
    }
}