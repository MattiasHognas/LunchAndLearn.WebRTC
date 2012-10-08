using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebRTC.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Snapshot()
        {
            return View();
        }

        public ActionResult P2PVideoAudio()
        {
            return View();
        }

        public ActionResult P2PData()
        {
            return View();
        }
    }
}
