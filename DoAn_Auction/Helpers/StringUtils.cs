﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace DoAn_Auction.Helpers
{
    public class StringUtils
    {
        public static string MD5(string strInput)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            byte[] input = Encoding.Default.GetBytes(strInput);
            byte[] output = md5.ComputeHash(input);
            string ret = BitConverter.ToString(output).Replace("-", "");
            return ret;

        }
    }
}