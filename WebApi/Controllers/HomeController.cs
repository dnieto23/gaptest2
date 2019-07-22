using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {

        private List<Models.RegisterModel> Students = new List<Models.RegisterModel>();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            Models.StudentsMock mockData = new Models.StudentsMock();
            Students.AddRange(mockData.GetMockData());
            return View();
        }


    }
}
