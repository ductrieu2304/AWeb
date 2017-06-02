using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn_Auction.Models
{
    public class AuctionVM
    {
        public string ProName { get; set; }
        public string FullDes { get; set; }
        public decimal PriceStarting { get; set; }
        public decimal PriceBuy { get; set; }
        public int Quantity { get; set; }
        public int CatID { get; set; }
        public int TimeEnd { get; set; }
        public bool Adjourning { get; set; }
        public int Required { get; set; }
        public decimal Step { get; set; }
    }
}