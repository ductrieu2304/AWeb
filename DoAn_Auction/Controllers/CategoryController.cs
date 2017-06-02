using DoAn_Auction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn_Auction.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        QLDauGiaEntities ctx = new QLDauGiaEntities();
        public ActionResult List()
        {
            //using (var ctx = new QLDauGiaEntities())
            //{
                var list = ctx.Categories
                    .Where(c=>c.ParentID==0).ToList();
                return PartialView("ListPartial",list);
            //}
        }
    }
}