using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn_Auction.Models
{
    public class RegisterVM
    {
        public string Username { get; set; }
        public string RawPWD { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string DOB { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}