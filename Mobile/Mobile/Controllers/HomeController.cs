using System;
using System.Collections.Generic;
using System.Mvc;
using System.Text;

namespace Mobile.Controllers
{
    class HomeController : Controller
    {
        public ActionResult Default()
        {
            return View();
        }
    }
}
