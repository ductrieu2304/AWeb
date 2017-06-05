using DoAn_Auction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn_Auction.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        QLDauGiaEntities ctx = new QLDauGiaEntities();
        public ActionResult Form()
        {
            var list = ctx.Categories
                    .Where(c => c.ParentID == 0).ToList();
            return PartialView("FormPartial", list);
        }

        // POST: Search
        //[HttpPost]
        //public ActionResult Form(string Content,int? CatID)
        //{
        //    var list = ctx.Auctions
        //            .Where(c => c.ProName.Contains(Content)).ToList();
        //    return PartialView("FormPartial", list);
        //}

        //GET: Search/Result
        public ActionResult Result(string Content, int? CatID, int page = 1)
        {
            var list=ctx.Auctions.ToList();
            //int n = 0;
            if (CatID.HasValue == false || CatID==0)
            {
                list= ctx.Auctions
                   .Where(c => c.ProName.Contains(Content)).ToList();
            }
            else
            {
                list = ctx.Auctions
                    .Where(c => c.ProName.Contains(Content) && c.CatID==CatID).ToList();
            }

            int n = list.Count();
            int RecordPerPage = 1;

            int nPages = n / RecordPerPage;

            int m = n % RecordPerPage;
            if (m > 0)
            {
                nPages++;
            }

            ViewBag.Pages = nPages;

            ViewBag.CurPage = page;

            list = list.OrderBy(p=>p.ProID)
                    .Skip((page - 1) * RecordPerPage)
                    .Take(RecordPerPage)
                    .ToList();
            ViewBag.Content = Content;
            ViewBag.CatID = CatID;
            return View(list);
        }
    }
}