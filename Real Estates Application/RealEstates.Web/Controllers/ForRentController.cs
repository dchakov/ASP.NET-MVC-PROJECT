using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstates.Web.Controllers
{
    public class ForRentController : Controller
    {
        // GET: ForRent
        public ActionResult Index()
        {
            return View();
        }

        // GET: ForRent/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
