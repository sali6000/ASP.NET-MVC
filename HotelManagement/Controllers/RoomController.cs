using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DTO;
using DAL;

namespace HotelManagement.Controllers
{
    public class RoomController : Controller
    {
        // Controller READ
        #region READ
        public ActionResult Index(string search)
        {
            if (search != null)
            {
                ViewModelManager viewModel = new ViewModelManager();
                List<RoomEntity> temp = viewModel.RoomGetListByTag(search);
                if (temp.Count > 0)
                {
                    return View(viewModel.RoomGetListByTag(search));
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View(RoomManager.GetList());
            }
            //RepositoryRoom repositoryRoom = new RepositoryRoom();
        }
        public ActionResult Details(int id)
        {
            return View(RoomManager.GetById(id));
        }
        #endregion

        // Controller CREATE
        #region CREATE (Protected by Admin)
        public ActionResult Create()
        {
            if(UserSession.CurrentUser != null)
            {
                if(UserSession.CurrentUser.admin == true)
                {
                    RoomEntity room = new RoomEntity();
                    room.hotel1 = HotelManager.GetList();
                    return View(room);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Create(RoomEntity room)
        {
            try
            {
                RoomManager.Add(room);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                room.hotel1 = HotelManager.GetList();
                return View(room);
            }
        }
        #endregion

        // Controller UPDATE
        #region UPDATE (Protected by Admin)
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (UserSession.CurrentUser != null)
            {
                if (UserSession.CurrentUser.admin == true)
                {
                    RoomEntity room = new RoomEntity();
                    room = RoomManager.GetById(id);
                    room.hotel1 = HotelManager.GetList();
                    return View(room);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(RoomEntity room)
        {
            try
            {
                RoomManager.Update(room);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        // Controller DELETE
        #region DELETE (Protected by Admin)
        public ActionResult Delete(int id)
        {
            if (UserSession.CurrentUser != null)
            {
                if (UserSession.CurrentUser.admin == true)
                {
                    return View(RoomManager.GetById(id));
                }
            }
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Toolbox.UtilitaireASP utilitaire = new Toolbox.UtilitaireASP();
                utilitaire.Update(AppConfig.ConnectionStringAdo, id, "ROOM", "ACTIVE", "0");
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion
    }
}