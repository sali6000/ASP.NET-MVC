using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LoginManager
    {
        public static MemberEntity GetLogin(LoginEntity member) { return new LoginProvider().SelectLogin(member); }
    }
}
