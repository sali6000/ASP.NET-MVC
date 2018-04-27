using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Controllers
{
    public class RentRoomMemberController : Controller
    {
        // GET: Reservation
        public ActionResult Index()
        {
            if (UserSession.CurrentUser != null && (UserSession.CurrentUser.admin == true || UserSession.CurrentUser.super_admin == true))
            {
                return View(RentRoomMemberManager.GetList());
            }
            else
            {
                return RedirectToAction("Create", "Login");
            }
        }

        public ActionResult IndexNotValidate(int id)
        {
            if (UserSession.CurrentUser != null && id == UserSession.CurrentUser.id)
            {
                ViewModelManager viewModel = new ViewModelManager();
                viewModel.RentRoomMemberNotValidates = RentRoomMemberManager.GetListNotValidateById(id);
                viewModel.Rooms = RoomManager.GetList();
                viewModel.Member = UserSession.CurrentUser;
                if (viewModel.RentRoomMemberNotValidates.Count() > 0)
                {
                    foreach (RoomEntity item in viewModel.Rooms)
                    {
                        viewModel.TotalPrice += item.price;
                    }
                }
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Create", "Login");
            }
        }

        public ActionResult IndexValidate(int id)
        {
            if(UserSession.CurrentUser != null && id == UserSession.CurrentUser.id)
            {
                ViewModelManager viewModel = new ViewModelManager();
                viewModel.RentRoomMemberValidates = RentRoomMemberManager.GetListValidateById(id);
                viewModel.Rooms = RoomManager.GetList();
                viewModel.Member = UserSession.CurrentUser;
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Create", "Login");
            }
        }

        // GET: Reservation/Details/5
        public ActionResult Details(int id)
        {
            if (UserSession.CurrentUser != null && (UserSession.CurrentUser.admin == true || id == UserSession.CurrentUser.id))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Create", "Login");
            }
        }

        // GET: Reservation/Create
        public ActionResult Create()
        {

            if (UserSession.CurrentUser != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Create", "Login");
            }
        }

        // POST: Reservation/Create
        [HttpPost]
        public ActionResult Create(int id, RentRoomMemberEntity rentRoomMember)
        {
            try
            {
                RentRoomMemberManager.Add(id, UserSession.CurrentUser.id, rentRoomMember.firstdate, rentRoomMember.lastdate, rentRoomMember.adult, rentRoomMember.child, rentRoomMember.price, rentRoomMember.assurance);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reservation/Edit/5
        public ActionResult Edit(int id)
        {

            if (UserSession.CurrentUser != null && (UserSession.CurrentUser.admin == true))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Create", "Login");
            }
        }

        // POST: Reservation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reservation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reservation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
    
}
