using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC = System.Mvc;

namespace Mobile.Controllers
{
    class Controller : Vst.Network.SocketController
    {
        public MVC.ActionResult GoFirst() { return RedirectToAction("default"); }
        //public MVC.ActionResult Message(string code)
        //{
        //    return View(new Views.Message(), code);
        //}
    }
}
