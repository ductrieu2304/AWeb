using DoAn_Auction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn_Auction.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        QLDauGiaEntities ctx = new QLDauGiaEntities();
        public ActionResult LoadTOPBID()
        {
            var list = ctx.Auctions.OrderByDescending(p => p.Customer).Take(4).ToList();
            return PartialView("TOPBIDPartial", list);
        }
    }
}