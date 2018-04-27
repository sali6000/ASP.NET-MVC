using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewModelManager viewModel = new ViewModelManager();
            viewModel.Hotels = HotelManager.GetList();
            viewModel.Rooms = RoomManager.GetList();
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}