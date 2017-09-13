using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///commProduct 的摘要说明
/// </summary>
/// 
namespace WeyiShow.MODELS
{
    public class commProduct
    {
        //ProductId,ProductName,Introduce,Unit,ImageUrl,Price,Class,Special
        public string TJRGuid { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Title { get; set; }
        public string Decriptions { get; set; }
        public string ImageUrl { get; set; }
        public string Price { get; set; }
        public string Class { get; set; }
        public string Topceng { get; set; }
        public string dorpdown { get; set; }
        public string FBData { get; set; }
        

    }
}