using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///ShopCar 的摘要说明
/// </summary>
/// 
namespace WeyiShow.MODELS
{
    public class ShopCar
    {
        //OrderId,ProductName,GoodId,Number,SumPrice,ImageUrl,UserName Price,Number,SumPrice
        public string OrderId { get; set; }
        public string ProductName { get; set; }
        public string GoodId { get; set; }
        public Int32 Number { get; set; }
        public double SumPrice { get; set; }
        public string ImageUrl { get; set; }
        public string UserName { get; set; }
        public double Price { get; set; }
    }
}