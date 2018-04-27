using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Controllers
{
    public class LoginController : Controller
    {
        // GET: User/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(LoginEntity login)
        {
            if (ModelState.IsValid)
            {
                MemberEntity member = LoginManager.GetLogin(login);

                if (member != null)
                {
                    if(member.active == true || member.super_admin == true)
                    UserSession.CurrentUser = member;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "L'email, le mot de passe est invalide ou le compte a été désactivé";
                }
            }
            return View();
        }

        public ActionResult Delete()
        {
            try
            {
                UserSession.CurrentUser = null;
                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
