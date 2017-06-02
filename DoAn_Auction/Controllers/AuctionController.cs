using DoAn_Auction.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace DoAn_Auction.Controllers
{
    public class AuctionController : Controller
    {
        // GET: Auction/Add
        public ActionResult Add()
        {
            QLDauGiaEntities ctx = new QLDauGiaEntities();
            ViewBag.Parent = ctx.Categories
                    .Where(c => c.ParentID == 0).ToList();
            return View();
        }

        // Post: Auction/Add
        [HttpPost]
        //Quan trọng: upload picture, form bên view phải có encytype
        public ActionResult Add(AuctionVM avm)
        {
            Auction u = new Auction
            {
                ProName = avm.ProName,
                FullDes = avm.FullDes,
                PriceStarting = avm.PriceStarting,
                PriceBuy = avm.PriceBuy,
                Quantity=avm.Quantity,
                CatID=avm.CatID,
                PriceHighest=0,
                Customer=0,
                TimeStart=DateTime.Now,
                TimeEnd = DateTime.Now.AddDays(avm.TimeEnd),
                Adjourning=false,
                Status=true,
                Required=avm.Required,
                Step=avm.Step,
                Seller=1
            };

            using (QLDauGiaEntities atx = new QLDauGiaEntities())
            {
                atx.Auctions.Add(u);
                atx.SaveChanges();
                ViewBag.Success = "Đăng kí thành công";
            }
            QLDauGiaEntities ctx = new QLDauGiaEntities();
            ViewBag.Parent = ctx.Categories
                    .Where(c => c.ParentID == 0).ToList();
            return View();
        }

        public ActionResult AddPicture()
        {
            return View();
        }
         [HttpPost]
        public ActionResult AddPicture(HttpPostedFileBase mainPic, IEnumerable<HttpPostedFileBase> subPic)
        {
            if (mainPic != null && mainPic.ContentLength > 0 )
            {
                //tạo folder chứa hình Images/sp/[ID product]
                string spDirPath = Server.MapPath("~/Images/sp");
                string targetDirPath = Path.Combine(spDirPath, 1.ToString());

                string spLargeDirPath = Server.MapPath("~/Images/sp/Large");
                string targetLargeDirPath = Path.Combine(spLargeDirPath, 1.ToString());

                Directory.CreateDirectory(targetDirPath);
                Directory.CreateDirectory(targetLargeDirPath);

                //copy hình lên
                string mainFileName = Path.Combine(targetDirPath, "main.jpg");
                mainPic.SaveAs(mainFileName);
                //copy hình zoom
                string imgLargeName = Path.Combine(targetLargeDirPath, "main.jpg");
                WebImage imgLarge = new WebImage(mainPic.InputStream);
                imgLarge.Resize(1000, 1000);
                imgLarge.Save(imgLargeName, "jpg");

                int i = 0;
                foreach (var file in subPic)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        i++;

                        string subFileName = Path.Combine(targetDirPath, i.ToString()+".jpg");
                        file.SaveAs(subFileName);

                        string subimgLargeName = Path.Combine(targetLargeDirPath, i.ToString());
                        WebImage subimgLarge = new WebImage(file.InputStream);
                        subimgLarge.Resize(1000, 1000);
                        subimgLarge.Save(subimgLargeName, "jpg");
                    }
                }
                ViewBag.Success = "thành công" + i.ToString();
            }
            else
            {
                ViewBag.ErrorMsg = "ko thành công";
            }
            return View();
        }
    }
}