using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Toolbox;
using BLL;
using DTO;
using DAL;

namespace HotelManagement.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index()
        {
            if (UserSession.CurrentUser != null)
            {
                return View(MemberManager.GetList());
            }
            else
            {
                return RedirectToAction("Create", "Login");
            }
        }

        public ActionResult Profil()
        {
            MemberEntity member = UserSession.CurrentUser;
            return View(member);
        }

        // GET: Member/Details/5
        public ActionResult Details(int id)
        {
            return View(MemberManager.GetById(id));
        }

        // GET: Member/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Member/Create
        [HttpPost]
        public ActionResult Create(MemberEntity member)
        {
            if (ModelState.IsValid)
            {
                bool error = false;

                if (MemberManager.UsernameExist(member))
                {
                    error = true;
                    ModelState.AddModelError(string.Empty, "Cette username existe déjà dans la base de donnée");
                }
                if (MemberManager.EmailExist(member))
                {
                    error = true;
                    ModelState.AddModelError(string.Empty, "Cette email existe déjà dans la base de donnée");
                }
                if(error == false)
                {
                    if (MemberManager.Add(member) > 0)
                    {
                        UserSession.CurrentUser = member;
                        return RedirectToAction("Index", "Home");
                    }
                }
                //ViewBag.Error = "Ce nom d'utilisateur existe déjà dans la base de donnée";
            }
            return View();
        }

        // GET: Member/Edit/5
        public ActionResult Edit(int id)
        {
            return View(MemberManager.GetById(id));
        }

        // POST: Member/Edit/5
        [HttpPost]
        public ActionResult Edit(MemberEntity member)
        {
            try
            {
                MemberManager.Update(member);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Member/Delete/5
        public ActionResult Delete(int id)
        {
            return View(MemberManager.GetById(id));
        }

        // POST: Member/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                UtilitaireASP utiliraire = new UtilitaireASP();
                utiliraire.Update(AppConfig.ConnectionStringAdo, id, "member", "active", "0");
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
