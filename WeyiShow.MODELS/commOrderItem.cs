using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///commOrderItem 的摘要说明
/// </summary>
/// 


namespace WeyiShow.MODELS
{
    public class commOrderItem
    {
        //public string ID;  //商品编号
        //public float Price;//顾客价格
        //public int Num;//商品数量
        //public float SumPrice;//小计   
        public string ProductId { get; set; }
        public string Price { get; set; }
        public string Num { get; set; }
        public string SumPrice { get; set; }
    }
}