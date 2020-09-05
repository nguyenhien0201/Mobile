using System;
using System.Collections.Generic;
using System.Mvc;
using System.Text;

namespace Mobile.Controllers
{
    class DeviceController: Controller
    {
        public ActionResult Default()
        {
            return View();
        }

        public ActionResult Current(string device)
        {
            return View(device);
        }
    }
}
